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
using System.Drawing.Text;
using System.Runtime.Caching;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace sistemPemesananTiketPesawat
{
    public partial class Pemesanan : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };
        private const string PemesananCacheKey = "PemesananData";
        public Pemesanan()
        {
            InitializeComponent();
        }
        private void Pemesanan_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxData();
            EnsureIndexes();
        }
        private void ClearForm()
        {
            txtID.Clear();
            waktu.Value = DateTime.Now;
            if (cmbIDPel.Items.Count > 0) cmbIDPel.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            txtID.Focus();
        }

        private void LoadComboBoxData()
        {
            //untuk status
            List<string> statusList = new List<string>
            { 
                "Pending", 
                "Berhasil", 
                "Gagal"
            };
            cmbStatus.DataSource = statusList;

            //untuk id_pelanggan
            using (SqlConnection conn = new SqlConnection(connectionString))
            {                
                conn.Open();

                SqlDataAdapter daPesan = new SqlDataAdapter("SELECT id_pelanggan FROM pelanggan", conn);
                DataTable dtPesan = new DataTable();
                daPesan.Fill(dtPesan);
                cmbIDPel.DataSource = dtPesan;
                cmbIDPel.DisplayMember = "id_pelanggan";
                cmbIDPel.ValueMember = "id_pelanggan";
            }

        }


        private void dgvPemesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPemesanan.Rows.Count - 1)
            {
                try
                {
                    DataGridViewRow row = dgvPemesanan.Rows[e.RowIndex];

                    var idValue = row.Cells["pemesanan_id"].Value;
                    txtID.Text = idValue != null && idValue != DBNull.Value ? idValue.ToString() : "";

                    var waktuValue = row.Cells["waktuPesan"].Value;
                    if (waktuValue != null && waktuValue != DBNull.Value)
                    {
                        waktu.Value = Convert.ToDateTime(waktuValue);
                    }

                    var statusValue = row.Cells["statusPesan"].Value;
                    if (statusValue != null && statusValue != DBNull.Value)
                    {
                        cmbStatus.SelectedItem = statusValue.ToString();
                    }
                    else
                    {
                        cmbStatus.SelectedIndex = -1;
                    }

                    var idPelangganValue = row.Cells["id_pelanggan"].Value;
                    if (idPelangganValue != null && idPelangganValue != DBNull.Value)
                    {
                        cmbIDPel.SelectedValue = idPelangganValue.ToString();
                    }
                    else
                    {
                        cmbIDPel.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error saat mengambil data pemesanan: " + ex.Message;
                }
            }

        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || cmbStatus.SelectedIndex == -1 || cmbIDPel.SelectedIndex == -1)
            {
                lblMessage.Text = "Silahkan isi semua data!";
                return;
            }
            if (waktu.Value < DateTime.Now)
            {
                lblMessage.Text = "Waktu pemesanan tidak boleh di masa lalu!";
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("updatePemesanan", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@pemesanan_id", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuPesan", waktu.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@statusPesan", cmbStatus.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@id_pelanggan", cmbIDPel.SelectedValue.ToString());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            transaction.Commit();
                            lblMessage.Text = "Data berhasil diubah!";
                            _cache.Remove(PemesananCacheKey);
                            LoadData();
                            ClearForm();
                        }
                        else
                        {
                            lblMessage.Text = "Data tidak ditemukan!";
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPemesanan.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlTransaction transaction = null;

                        try
                        {
                            string id = dgvPemesanan.SelectedRows[0].Cells["pemesanan_id"].Value.ToString();
                            conn.Open();
                            transaction = conn.BeginTransaction();
                            using (SqlCommand cmd = new SqlCommand("deletePemesanan", conn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@pemesanan_id", id);
                                int rows = cmd.ExecuteNonQuery();

                                if (rows > 0)
                                {
                                    transaction.Commit();
                                    lblMessage.Text = "Data berhasil dihapus!";
                                    _cache.Remove(PemesananCacheKey);
                                    LoadData();
                                    ClearForm();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction?.Rollback();
                            lblMessage.Text = "Error: " + ex.Message;
                        }
                    }
                }
            }
            else
            {
                lblMessage.Text = "Pilih data yang akan dihapus!";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _cache.Remove(PemesananCacheKey);
            LoadData();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    if (txtID.Text == "" || cmbStatus.SelectedIndex == -1 || cmbIDPel.SelectedIndex == -1)
                    {
                        lblMessage.Text = "Silahkan isi semua data!";
                        return;
                    }
                    string checkQuery = "SELECT COUNT(*) FROM pemesanan WHERE pemesanan_id = @pemesanan_id";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@pemesanan_id", txtID.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            lblMessage.Text = "ID pemesanan sudah digunakan!";
                            return;
                        }
                    }

                    if (waktu.Value < DateTime.Now)
                    {
                        lblMessage.Text = "Waktu pemesanan tidak boleh di masa lalu!";
                        return;
                    }

                    using (SqlCommand cmd = new SqlCommand("addPemesanan", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@pemesanan_id", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuPesan", waktu.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@statusPesan", cmbStatus.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@id_pelanggan", cmbIDPel.SelectedValue.ToString());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            transaction.Commit();
                            lblMessage.Text = "Data berhasil ditambahkan!";
                            _cache.Remove(PemesananCacheKey);
                            LoadData();
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

           private void LoadData()
           {
            DataTable dt;

            if (_cache.Contains(PemesananCacheKey))
            {
                dt = _cache.Get(PemesananCacheKey) as DataTable;
            }
            else
            {
                dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "SELECT pemesanan_id, waktuPesan, statusPesan, id_pelanggan FROM pemesanan";
                        SqlDataAdapter da = new SqlDataAdapter(query, connection);
                        da.Fill(dt);

                        _cache.Add(PemesananCacheKey, dt, _policy);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            dgvPemesanan.AutoGenerateColumns = true;
            dgvPemesanan.DataSource = dt;
            ClearForm();
        }

        private void logoToHome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using(var openFile = new OpenFileDialog())
            {
                openFile.Filter = "Excel Files|*.xlsx;*.xlsm";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    PreviewForm(openFile.FileName);
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

                    // Header kolom
                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                        dt.Columns.Add(cell.ToString());

                    // Baris data
                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        int cellIndex = 0;

                        foreach (var cell in row.Cells)
                        {
                            newRow[cellIndex++] = cell.ToString();
                        }

                        dt.Rows.Add(newRow);
                    }

                    PreviewForm previewForm = new PreviewForm(dt, "pemesanan");
                    previewForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string indexScript = @"
                    -- Cek dan buat index untuk tabel pemesanan
                    IF OBJECT_ID('dbo.pemesanan', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_statusPesan')
                            CREATE NONCLUSTERED INDEX idx_statusPesan ON dbo.pemesanan(statusPesan);
                    END
                ";

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
                var wrapped = @"
                SET STATISTICS IO ON;
                SET STATISTICS TIME ON;
                " + sqlQuery + @"
                SET STATISTICS IO OFF;
                SET STATISTICS TIME OFF;";
                using (var cmd = new SqlCommand(wrapped, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var heavyQuery = "SELECT pemesanan_id, waktuPesan, statusPesan FROM dbo.pemesanan WHERE statusPesan = 'confirmed'";
            AnalyzeQuery(heavyQuery);
        }
    }
}
