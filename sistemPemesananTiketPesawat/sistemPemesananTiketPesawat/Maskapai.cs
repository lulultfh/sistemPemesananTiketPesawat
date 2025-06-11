using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.Caching;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace sistemPemesananTiketPesawat
{
    public partial class Maskapai : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy

        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };
        private const string CacheKey = "Maskapai";
        public Maskapai()
        {
            InitializeComponent();
        }
        private void Maskapai_Load(object sender, EventArgs e)
        {
            LoadData(sender, e);
            EnsureIndexes();
        }
        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                    IF OBJECT_ID('dbo.maskapai','U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Maskapai_Nama')
                            CREATE NONCLUSTERED INDEX idx_Maskapai_Nama ON dbo.maskapai(nama_maskapai);
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Maskapai_Negara')
                            CREATE NONCLUSTERED INDEX idx_Maskapai_Negara ON dbo.maskapai(negara_asal);
                    END";
                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void ClearForm()
        {
            txtID.Clear();
            txtNama.Clear();
            txtKode.Clear();
            txtNgr.Clear();
            txtID.Focus();
        }

        private string CapitalizeEachWord(string input)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private void LoadData(object sender, EventArgs e)
        {
            if (_cache.Contains(CacheKey))
            {
                dgvMaskapai.DataSource = (DataTable)_cache.Get(CacheKey);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_maskapai, nama_maskapai, kode_maskapai, negara_asal FROM maskapai";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    _cache.Add(CacheKey, dt, _policy);
                    dgvMaskapai.DataSource = dt;
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal load data: " + ex.Message);
                }
            }
        
        }
        private void logoToHome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtNama.Text == "" || txtKode.Text == "" || txtNgr.Text == "")
            {
                lblMessage.Text = ("Silakan lengkapi semua data!");
                return;
            }

            if (txtID.Text.Length > 7)
            {
                lblMessage.Text = ("ID Maskapai maksimal 7 karakter!");
                return;
            }

            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z'\s]+$"))
            {
                lblMessage.Text = ("Nama maskapai hanya boleh huruf dan spasi!");
                return;
            }

            if (!Regex.IsMatch(txtKode.Text, @"^[a-zA-Z]{1,5}$"))
            {
                lblMessage.Text = ("Kode maskapai hanya boleh huruf (maks 5 karakter)!");
                return;
            }

            if (!Regex.IsMatch(txtNgr.Text, @"^[a-zA-Z\s]+$"))
            {
                lblMessage.Text = ("Negara asal hanya boleh huruf dan spasi!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();



                    using (SqlCommand cmd = new SqlCommand("AddMaskapai", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_maskapai", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama_maskapai", CapitalizeEachWord(txtNama.Text.Trim()));
                        cmd.Parameters.AddWithValue("@kode_maskapai", txtKode.Text.Trim().ToUpper());
                        cmd.Parameters.AddWithValue("@negara_asal", CapitalizeEachWord(txtNgr.Text.Trim()));

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            transaction.Commit();
                            _cache.Remove(CacheKey);
                            lblMessage.Text = ("Data berhasil ditambahkan!");
                            LoadData(sender, e);
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = "Gagal tambah data: " + ex.Message;
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                lblMessage.Text = ("Pilih data yang ingin diubah!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand("Updatemaskapai", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_maskapai", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama_maskapai", CapitalizeEachWord(txtNama.Text.Trim()));
                        cmd.Parameters.AddWithValue("@kode_maskapai", txtKode.Text.Trim().ToUpper());
                        cmd.Parameters.AddWithValue("@negara_asal", CapitalizeEachWord(txtNgr.Text.Trim()));

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            transaction.Commit();
                            _cache.Remove(CacheKey);
                            lblMessage.Text = ("Data berhasil diubah!");
                            LoadData(sender, e);
                            ClearForm();
                        }
                        else
                        {
                            transaction?.Rollback();
                            lblMessage.Text = ("Data tidak ditemukan.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = ("Gagal ubah data: " + ex.Message);
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
            if (dgvMaskapai.SelectedRows.Count == 0)
            {
                lblMessage.Text = ("Pilih data yang akan dihapus!");
                return;
            }

            var result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string id = dgvMaskapai.SelectedRows[0].Cells["id_maskapai"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        using (SqlCommand cmd = new SqlCommand("Deletemaskapai", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_maskapai", id);
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                transaction.Commit();
                                _cache.Remove(CacheKey);
                                lblMessage.Text = ("Data berhasil dihapus!");
                                LoadData(sender, e);
                            }
                            else
                            {
                                transaction.Rollback();
                                lblMessage.Text = ("Data gagal dihapus!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        lblMessage.Text = ("Gagal hapus data: " + ex.Message);
                    }
                }

            }
        }

        private void dgvMaskapai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMaskapai.Rows[e.RowIndex];
                txtID.Text = row.Cells["id_maskapai"].Value.ToString();
                txtNama.Text = row.Cells["nama_maskapai"].Value.ToString();
                txtKode.Text = row.Cells["kode_maskapai"].Value.ToString();
                txtNgr.Text = row.Cells["negara_asal"].Value.ToString();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel Files|*.xls;*.xlsx";
            if (open.ShowDialog() == DialogResult.OK)
            {
                PreviewForm(open.FileName);
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
                        dt.Columns.Add(cell.ToString());

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        for (int j = 0; j < row.Cells.Count; j++)
                            newRow[j] = row.Cells[j].ToString();
                        dt.Rows.Add(newRow);
                    }

                    PreviewForm preview = new PreviewForm(dt, "maskapai");
                    preview.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal membaca file Excel: " + ex.Message);
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var sql = "SELECT nama_maskapai, negara_asal FROM dbo.maskapai WHERE nama_maskapai LIKE 'a%' AND negara_asal = 'Indonesia'";
            AnalyzeQuery(sql);
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
    }
}
