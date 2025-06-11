using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.Caching;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemPemesananTiketPesawat
{
    public partial class Penerbangan : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };
        private const string CacheKey = "penerbanganData";

        public Penerbangan()
        {
            InitializeComponent();
        }

        private void Penerbangan_Load(object sender, EventArgs e)
        {
            EnsureIndexes();
            LoadComboBoxData();
            LoadData(sender, e);
        }

        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                IF OBJECT_ID('dbo.tiket', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_noPnbAsalTujuan')
                            CREATE NONCLUSTERED INDEX idx_noPnbAsalTujuan ON dbo.penerbanagan(noPenerbangan);
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_noPnbAsalTujuan')
                            CREATE NONCLUSTERED INDEX idx_noPnbAsalTujuan ON dbo.penerbanagan(asal);
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_noPnbAsalTujuan')
                            CREATE NONCLUSTERED INDEX idx_noPnbAsalTujuan ON dbo.penerbanagan(tujuan);
                    END";
                using(var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtNoPenerbangan.Clear();
            txtTujuan.Clear();
            txtAsal.Clear();
            dtBerangkat.Value = DateTime.Now;
            dtKedatangan.Value = DateTime.Now;
            txtHarga.Clear();
            if (cmbIDFK.Items.Count > 0) cmbIDFK.SelectedIndex = 0;
            dgvPenerbangan.ClearSelection();
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
                    var query = "SELECT id_penerbangan, noPenerbangan, tujuan, asal, waktuBrgkt, waktuKedatangan, harga, id_maskapai FROM penerbangan";
                    var da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
                _cache.Add(CacheKey, dt, _policy);
            }
            dgvPenerbangan.AutoGenerateColumns = true;
            dgvPenerbangan.DataSource = dt;
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

        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDataAdapter daPesan = new SqlDataAdapter("SELECT id_maskapai FROM maskapai", conn);
                DataTable dtPesan = new DataTable();
                daPesan.Fill(dtPesan);
                cmbIDFK.DataSource = dtPesan;
                cmbIDFK.DisplayMember = "id_maskapai";
                cmbIDFK.ValueMember = "id_maskapai";
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {

            SqlTransaction transaction = null;
            if (dgvPenerbangan.SelectedRows.Count == 0)
            {
                lblMessage.Text = "Pilih data yang akan diubah!";
                return;
            }
            if (txtID.Text == "" || txtNoPenerbangan.Text == "" || txtTujuan.Text == "" || txtAsal.Text == "" || txtHarga.Text == "" || cmbIDFK.SelectedIndex == -1)
            {
                lblMessage.Text = "Silahkan isi semua data!";
                return;
            }
            if (!decimal.TryParse(txtHarga.Text.Trim(), out decimal hargaDecimal))
            {
                lblMessage.Text = "Harga harus berupa angka desimal!";
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    using (var cmd = new SqlCommand("updatePenerbangan", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_penerbangan", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@noPenerbangan", txtNoPenerbangan.Text.Trim());
                        cmd.Parameters.AddWithValue("@tujuan", txtTujuan.Text.Trim());
                        cmd.Parameters.AddWithValue("@asal", txtAsal.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuBrgkt", dtBerangkat.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@waktuKedatangan", dtKedatangan.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@harga", hargaDecimal);
                        cmd.Parameters.AddWithValue("@id_maskapai", cmbIDFK.SelectedValue.ToString());
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    _cache.Remove(CacheKey);
                    lblMessage.Text = "Data berhasil diubah!";
                    LoadData(sender, e);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _cache.Remove(CacheKey);
            LoadData(sender, e);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            if (dgvPenerbangan.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            try{
                var id = dgvPenerbangan.SelectedRows[0].Cells["id_penerbangan"].Value.ToString();
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("deletePenerbangan", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_penerbangan", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
                _cache.Remove(CacheKey);
                lblMessage.Text = "Data berhasil dihapus!";
                LoadData(sender, e);
                ClearForm();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Error: " + ex.Message, "Kesalahan");
            }
        }

        private void dgvPenerbangan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvPenerbangan.Rows[e.RowIndex];
            txtID.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
            txtNoPenerbangan.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
            txtTujuan.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
            txtAsal.Text = row.Cells[3].Value.ToString() ?? string.Empty;
            dtBerangkat.Value = Convert.ToDateTime(row.Cells[4].Value);
            dtKedatangan.Value = Convert.ToDateTime(row.Cells[5].Value);
            txtHarga.Text = row.Cells[6].Value?.ToString() ?? string.Empty;
            cmbIDFK.SelectedValue = row.Cells[7].Value?.ToString() ?? string.Empty;    
        }
        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    if (txtID.Text == "" || txtNoPenerbangan.Text == "" || txtHarga.Text == "" || cmbIDFK.SelectedIndex == -1)
                    {
                        lblMessage.Text = "Silahkan isi semua data!";
                        return;
                    }
                    if (!decimal.TryParse(txtHarga.Text.Trim(), out decimal hargaDecimal))
                    {
                        lblMessage.Text = "Harga harus berupa angka desimal!";
                        return;
                    }
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("addPenerbangan", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_penerbangan", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@noPenerbangan", txtNoPenerbangan.Text.Trim());
                        cmd.Parameters.AddWithValue("@tujuan", txtTujuan.Text.Trim());
                        cmd.Parameters.AddWithValue("@asal", txtAsal.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuBrgkt", dtBerangkat.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@waktuKedatangan", dtKedatangan.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@harga", hargaDecimal);
                        cmd.Parameters.AddWithValue("@id_maskapai", cmbIDFK.SelectedValue.ToString());
                        cmd.ExecuteNonQuery();
                        int rows = cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    _cache.Remove(CacheKey);
                    lblMessage.Text = "Data berhasil ditambahkan!";
                    LoadData(sender, e);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                PreviewForm(filePath);
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

                    IRow headerRow = sheet.GetRow(0);
                    foreach (var cell in headerRow.Cells)
                    {
                        dt.Columns.Add(cell.ToString());
                    }
                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();

                        for (int j = 0; j<headerRow.LastCellNum; j++)
                        {
                            ICell cell = dataRow.GetCell(j);
                            if (cell != null)
                            {
                                if ((j == 4 || j == 5) && cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell))
                                {
                                    newRow[j] = cell.DateCellValue;
                                }
                                else
                                {
                                    newRow[j] = cell.ToString();
                                }
                            }
                            else
                            {
                                newRow[j] = DBNull.Value; // Handle null cells
                            }
                        }
                        dt.Rows.Add(newRow);
                    }
                    PreviewForm previewForm = new PreviewForm(dt, "penerbangan");
                    previewForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var heavyQuery = "SELECT noPenerbangan, asal, tujuan FROM dbo.penerbangan WHERE noPenerbangan LIKE 'GA%' AND asal='Yogyakarta' AND tujuan='Jakarta'";
            AnalyzeQuery(heavyQuery);
        }
    }
}
