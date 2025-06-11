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
    public partial class users : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5) };
        private const string CacheKey = "Users";
        public users()
        {
            InitializeComponent();
        }
        private void users_Load(object sender, EventArgs e)
        {
            EnsureIndexes();
            LoadData(sender, e);
        }

        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                    IF OBJECT_ID('dbo.pelanggan', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name='idx_pelanggan_email')
                            CREATE NONCLUSTERED INDEX idx_pelanggan_email ON dbo.pelanggan(email);
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
            txtTelp.Clear();
            txtID.Focus();
        }

        private string CapitalizeEachWord(string input)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
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
                    var query = "SELECT id_pelanggan, nama, email, passwd, noTelp FROM pelanggan";
                    var da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
                _cache.Add(CacheKey, dt, _policy);
            }

            dgvUsers.AutoGenerateColumns = true;
            dgvUsers.DataSource = dt;
            ClearForm();
        }
        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                lblMessage.Text = "Harap isi semua data!";
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    SqlTransaction transaction = null;
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    using (var cmd = new SqlCommand("addpelanggan", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pelanggan", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtMail.Text.Trim());
                        cmd.Parameters.AddWithValue("@passwd", txtPasswd.Text.Trim());
                        cmd.Parameters.AddWithValue("@noTelp", txtTelp.Text.Trim());

                        int result = cmd.ExecuteNonQuery();


                        if (result > 0)
                        {
                            transaction.Commit();
                            _cache.Remove(CacheKey);
                            lblMessage.Text = "Data berhasil ditambahkan!";
                            LoadData(sender, e);
                            ClearForm();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _cache.Remove(CacheKey);
            LoadData(sender, e);
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                lblMessage.Text = "Pilih data yang akan diubah!";
                return;
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("updatepelanggan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pelanggan", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtMail.Text.Trim());
                        cmd.Parameters.AddWithValue("@passwd", txtPasswd.Text.Trim());
                        cmd.Parameters.AddWithValue("@noTelp", txtTelp.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                _cache.Remove(CacheKey);
                lblMessage.Text = "Data berhasil diperbarui!";
                LoadData(sender, e);
                ClearForm();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error" + ex.Message;
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                var id_pelanggan = dgvUsers.SelectedRows[0].Cells["id_pelanggan"].Value.ToString();
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("deletepelanggan", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_pelanggan", id_pelanggan);
                        cmd.ExecuteNonQuery();
                    }
                }
                _cache.Remove(CacheKey);
                lblMessage.Text = "Data berhasil dihapus!";
                LoadData(sender, e);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Kesalahan");
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Rows.Count > 0)
            {
                try
                {
                    var selectedRow = dgvUsers.Rows[e.RowIndex];

                    var idValue = selectedRow.Cells["id_pelanggan"].Value;
                    if (idValue != null && idValue != DBNull.Value)
                    {
                        txtID.Text = idValue.ToString();
                        txtNama.Text = selectedRow.Cells["nama"].Value?.ToString() ?? string.Empty;
                        txtMail.Text = selectedRow.Cells["email"].Value?.ToString() ?? string.Empty;
                        txtPasswd.Text = selectedRow.Cells["passwd"].Value?.ToString() ?? string.Empty;
                        txtTelp.Text = selectedRow.Cells["noTelp"].Value?.ToString() ?? string.Empty;
                    }
                    else
                    {
                        lblMessage.Text = "Data ID pelanggan tidak valid.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat memilih data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTelp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void logoToHome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            var heavyQuery = "SELECT nama, email, passwd, noTelp FROM dbo.pelanggan WHERE Nama LIKE 'A%'";
            AnalyzeQuery(heavyQuery);
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

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                openFile.Filter = "Excel Files|*.xlsx;*.xlsm";
                if (openFile.ShowDialog() == DialogResult.OK)
                    PreviewForm(openFile.FileName);
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
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        int cellIndex = 0;
                        foreach (var cell in dataRow.Cells)
                            newRow[cellIndex++] = cell.ToString();
                        dt.Rows.Add(newRow);
                    }

                    PreviewForm PreviewForm = new PreviewForm(dt, "pelanggan");
                    PreviewForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
