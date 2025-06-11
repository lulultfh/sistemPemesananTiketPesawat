using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Caching;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace sistemPemesananTiketPesawat
{
    public partial class Pembayaran : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };
        private const string CacheKey = "Pembayaran";

        public Pembayaran()
        {
            EnsureIndexes();
            InitializeComponent();
        }
        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                    IF OBJECT_ID('dbo.pelanggan', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_pembayaran_pemesanan_id')
                            CREATE NONCLUSTERED INDEX idx_pembayaran_pemesanan_id ON dbo.pembayaran(pemesanan_id);
                    END";
                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void AnalyzeQuery(string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.InfoMessage += (s, e) => MessageBox.Show(e.Message, "STATISTICS INFO");
                conn.Open();

                var wrapped = $@"
                    SET STATISTICS IO ON;
                    SET STATISTICS TIME ON;
                    {sqlQuery};
                    SET STATISTICS IO OFF;
                    SET STATISTICS TIME OFF;";

                using (var cmd = new SqlCommand(wrapped, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void ClearForm()
        {
            txtID.Clear();
            txtJumlah.Clear();
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            dtBayar.Value = DateTime.Now;
            if (cmbIDFK.Items.Count > 0) cmbIDFK.SelectedIndex = 0;
            txtID.Focus();
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadData(sender, e);
        }

        private void LoadData(object sender, EventArgs e)
        {
            DataTable dt;

            if (_cache.Contains(CacheKey))
            {
                dt = _cache.Get(CacheKey) as DataTable;
            }
            else
            {
                dt = new DataTable();
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    var query = "SELECT id_pembayaran, jumlah_bayar, statusBayar, tanggal_bayar, pemesanan_id FROM pembayaran";
                    var da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }

                _cache.Add(CacheKey, dt, _policy);
            }

            dgvPembayaran.AutoGenerateColumns = true;
            dgvPembayaran.DataSource = dt;
            ClearForm();
        }

        private void LoadComboBoxData()
        {
            cmbStatus.DataSource = new List<string> { "Pending", "Berhasil", "Gagal" };

            // ID Pemesanan
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT pemesanan_id FROM pemesanan", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbIDFK.DataSource = dt;
                cmbIDFK.DisplayMember = "pemesanan_id";
                cmbIDFK.ValueMember = "pemesanan_id";
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            LoadData(sender, e);
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || string.IsNullOrWhiteSpace(txtJumlah.Text))
            {
                MessageBox.Show("Harap isi semua data!", "Peringatan");
                return;
            }
            if (dtBayar.Value > DateTime.Now)
            {
                MessageBox.Show("Tanggal bayar tidak boleh setelah waktu sekarang!", "Peringatan");
                return;
            }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("Addpembayaran", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pembayaran", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@jumlah_bayar", txtJumlah.Text.Trim());
                        cmd.Parameters.AddWithValue("@statusBayar", cmbStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@tanggal_bayar", dtBayar.Value);
                        cmd.Parameters.AddWithValue("@pemesanan_id", cmbIDFK.SelectedValue.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }

                _cache.Remove(CacheKey);
                MessageBox.Show("Data berhasil ditambahkan!", "Sukses");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan");
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPembayaran.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                var id = dgvPembayaran.SelectedRows[0].Cells["id_pembayaran"].Value.ToString();
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("deletepembayaran", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pembayaran", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                _cache.Remove(CacheKey);
                MessageBox.Show("Data berhasil dihapus!", "Sukses");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan");
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (dgvPembayaran.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan diubah!", "Peringatan");
                return;
            }
            if (dtBayar.Value > DateTime.Now)
            {
                MessageBox.Show("Tanggal bayar tidak boleh setelah waktu sekarang!", "Peringatan");
                return;
            }
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("updatepembayaran", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pembayaran", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@jumlah_bayar", txtJumlah.Text.Trim());
                        cmd.Parameters.AddWithValue("@statusBayar", cmbStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@tanggal_bayar", dtBayar.Value);
                        cmd.Parameters.AddWithValue("@pemesanan_id", cmbIDFK.SelectedValue.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }

                _cache.Remove(CacheKey);
                MessageBox.Show("Data berhasil diperbarui!", "Sukses");
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan");
            }
        }

        private void dgvPembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvPembayaran.Rows[e.RowIndex];
            {

                txtID.Text = row.Cells[0].Value?.ToString();
                txtJumlah.Text = row.Cells[1].Value?.ToString();
                cmbStatus.SelectedItem = row.Cells[2].Value?.ToString();
                cmbIDFK.SelectedValue = row.Cells[4].Value?.ToString();
                if (row.Cells[3].Value != DBNull.Value)
                    dtBayar.Value = Convert.ToDateTime(row.Cells[3].Value);
                else
                    dtBayar.Value = DateTime.Now;

            }
        }

        private void logoToHome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home(); 
            homeForm.Show();
            this.Hide();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                openFile.Filter = "Excel Files|*.xlsx;*.xlsm";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PreviewForm(openFile.FileName);
                    _cache.Remove(CacheKey); // Reset cache
                    LoadData(null, null);
                }
            }
        }
        private void PreviewForm(string filePath)
        {
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    IWorkbook workbook = new XSSFWorkbook(fs);
                    ISheet sheet = workbook.GetSheetAt(0);
                    DataTable dt = new DataTable();

                    // Header
                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                        dt.Columns.Add(cell.ToString());

                    // Data rows
                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        for (int j = 0; j < dataRow.Cells.Count; j++)
                        {
                            newRow[j] = dataRow.Cells[j].ToString();
                        }
                        dt.Rows.Add(newRow);
                    }

                    PreviewForm previewForm = new PreviewForm(dt, "pembayaran");
                    previewForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            var heavyQuery = "SELECT nama, email, passwd, noTelp FROM dbo.pelanggan WHERE Nama LIKE 'A%'";
            AnalyzeQuery(heavyQuery);
        }
    }
}
