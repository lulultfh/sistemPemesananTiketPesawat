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
using System.Text.RegularExpressions;
using System.Runtime.Caching;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace sistemPemesananTiketPesawat
{
    public partial class Admin : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };
        private const string CacheKey = "Admin";
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadData();
            EnsureIndexes();
        }
        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                    IF OBJECT_ID('dbo.admin','U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_Admin_Nama')
                            CREATE NONCLUSTERED INDEX idx_Admin_Nama ON dbo.admin(nama);
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
            txtMail.Clear();
            txtPasswd.Clear();
            txtID.Focus();
        }

        private string CapitalizeEachWord(string input)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private void LoadData()
        {
            if(_cache.Contains(CacheKey))
            {
                dgvAdmin.DataSource = (DataTable)_cache.Get(CacheKey);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_admin, nama, email, password FROM admin";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    _cache.Add(CacheKey, dt, _policy);
                    dgvAdmin.DataSource = dt;
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
            if (txtID.Text == "" || txtNama.Text == "" || txtMail.Text == "" || txtPasswd.Text == "")
            {
                lblMessage.Text = ("Silakan lengkapi semua data!");
                return;
            }

            if (!Regex.IsMatch(txtNama.Text, @"^[a-zA-Z'\s]+$"))
            {
                lblMessage.Text = ("Nama hanya boleh berisi huruf, spasi, dan tanda petik (')!");
                return;
            }

            if (!Regex.IsMatch(txtMail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMessage.Text = ("Format email tidak valid!");
                return;
            }

            if (txtPasswd.Text.Length < 8)
            {
                lblMessage.Text = ("Password minimal 8 karakter!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();

                    using (SqlCommand cmd = new SqlCommand("Addadmin", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_admin", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", CapitalizeEachWord(txtNama.Text.Trim()));
                        cmd.Parameters.AddWithValue("@email", txtMail.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPasswd.Text);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            transaction.Commit();
                            _cache.Remove(CacheKey);
                            lblMessage.Text = ("Data berhasil ditambahkan!");
                            LoadData();
                            ClearForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = ("Gagal tambah data: " + ex.Message);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _cache.Remove(CacheKey);
            LoadData();
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

                    using (SqlCommand cmd = new SqlCommand("Updateadmin", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_admin", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", CapitalizeEachWord(txtNama.Text.Trim()));
                        cmd.Parameters.AddWithValue("@email", txtMail.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPasswd.Text);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            transaction.Commit();
                            _cache.Remove(CacheKey);
                            lblMessage.Text = ("Data berhasil diubah!");
                            LoadData();
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvAdmin.SelectedRows.Count == 0)
            {
                lblMessage.Text = ("Pilih data yang akan dihapus!");
                return;
            }

            var result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string id = dgvAdmin.SelectedRows[0].Cells["id_admin"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlTransaction transaction = null;
                    try
                    {
                        conn.Open();
                        transaction = conn.BeginTransaction();

                        using (SqlCommand cmd = new SqlCommand("Deleteadmin", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_admin", id);
                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                transaction.Commit();
                                _cache.Remove(CacheKey);
                                lblMessage.Text = ("Data berhasil dihapus!");
                                LoadData();
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

  
        private void dgvAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAdmin.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtNama.Text = row.Cells[1].Value.ToString();
                txtMail.Text = row.Cells[2].Value.ToString();
                txtPasswd.Text = row.Cells[3].Value.ToString();
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

                    PreviewForm preview = new PreviewForm(dt, "admin");
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
            var sql = "SELECT nama FROM dbo.admin WHERE nama LIKE 'a%'";
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
