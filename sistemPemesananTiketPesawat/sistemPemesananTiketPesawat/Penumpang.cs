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
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Runtime.Caching;

namespace sistemPemesananTiketPesawat
{
    public partial class Penumpang : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };
        private const string PenumpangCacheKey = "PenumpangData";
        public Penumpang()
        {
            InitializeComponent();
        }
        private string CapitalizeEachWord(string input)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtNama.Clear();
            dtTgl.Value = DateTime.Now;
            if (cmbJK.Items.Count > 0) cmbJK.SelectedIndex = 0;
            txtKwn.Clear();

            txtID.Focus();

        }
        private void LoadData(object sender, EventArgs e)
        {
            DataTable dt;

            if (_cache.Contains(PenumpangCacheKey))
            {
                dt = _cache.Get(PenumpangCacheKey) as DataTable;
            }
            else
            {
                dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string query = "SELECT id_Penumpang, namaLengkap, tanggalLahir, jnsKelamin, kewarganegaraan FROM penumpang";
                        SqlDataAdapter da = new SqlDataAdapter(query, connection);
                        da.Fill(dt);

                        _cache.Add(PenumpangCacheKey, dt, _policy);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            dgvPenumpang.AutoGenerateColumns = true;
            dgvPenumpang.DataSource = dt;
            ClearForm();
        }

        private void Penumpang_Load(object sender, EventArgs e)
        {
            LoadData(sender, e);
            LoadComboBoxData();
            EnsureIndexes();
        }

        private void LoadComboBoxData()
        {
            List<string> jkList = new List<string>
            {
                "perempuan", "laki-laki"
            };
            cmbJK.DataSource = jkList;
        }
 

        private void lblKode_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _cache.Remove(PenumpangCacheKey);
            LoadData(sender, e);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPenumpang.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlTransaction transaction = null;

                        try
                        {
                            string id = dgvPenumpang.SelectedRows[0].Cells["id_Penumpang"].Value.ToString();
                            conn.Open();
                            transaction = conn.BeginTransaction();
                            using (SqlCommand cmd = new SqlCommand("deletePenumpang", conn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@id_Penumpang", id);
                                int rows = cmd.ExecuteNonQuery();

                                if (rows > 0)
                                {
                                    transaction.Commit();
                                    lblMessage.Text = "Data berhasil dihapus!";
                                    _cache.Remove(PenumpangCacheKey);
                                    LoadData(sender, e);
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

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtNama.Text == "" || cmbJK.SelectedIndex == -1 || txtKwn.Text == "")
            {
                lblMessage.Text = "Silahkan isi semua data!";
                return;
            }
            string nama = txtNama.Text.Trim();
            if (!Regex.IsMatch(nama, @"^[a-zA-Z'\s]+$"))
            {
                lblMessage.Text = "Nama hanya boleh berisi huruf, spasi, dan tanda petik (') saja!";
                return;
            }
            nama = CapitalizeEachWord(nama);
            string kwn = txtKwn.Text.Trim();
            if (!Regex.IsMatch(kwn, @"^[a-zA-Z\s]+$"))
            {
                lblMessage.Text = "Kewarganegaraan hanya boleh berisi huruf dan spasi!";
                return;
            }
            kwn = CapitalizeEachWord(kwn);
            if (dtTgl.Value >= DateTime.Now)
            {
                lblMessage.Text = "Tanggal lahir penumpang tidak boleh di hari ini!";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("updatePenumpang", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_Penumpang", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@namaLengkap", nama);
                        cmd.Parameters.AddWithValue("@tanggalLahir", dtTgl.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@jnsKelamin", cmbJK.SelectedValue.ToString().Trim());
                        cmd.Parameters.AddWithValue("@kewarganegaraan", kwn);


                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            transaction.Commit();
                            lblMessage.Text = "Data berhasil diubah!";
                            _cache.Remove(PenumpangCacheKey);
                            LoadData(sender, e);
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

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;

                try
                {
                    if (txtID.Text == "" || txtNama.Text == "" || cmbJK.SelectedIndex == -1 || txtKwn.Text == "")
                    {
                        lblMessage.Text = "Silahkan isi semua data!";
                        return;
                    }
                    string nama = txtNama.Text.Trim();
                    if (!Regex.IsMatch(nama, @"^[a-zA-Z'\s]+$"))
                    {
                        lblMessage.Text = "Nama hanya boleh berisi huruf, spasi, dan tanda petik (') saja!";
                        return;
                    }
                    nama = CapitalizeEachWord(nama);

                    string kwn = txtKwn.Text.Trim();
                    if (!Regex.IsMatch(kwn, @"^[a-zA-Z\s]+$"))
                    {
                        lblMessage.Text = "Kewarganegaraan hanya boleh berisi huruf dan spasi!";
                        return;
                    }
                    kwn = CapitalizeEachWord(kwn);

                    if (dtTgl.Value >= DateTime.Now)
                    {
                        lblMessage.Text = "Tanggal lahir penumpang tidak boleh hari ini!";
                        return;
                    }
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    string checkQuery = "SELECT COUNT(*) FROM penumpang WHERE id_Penumpang = @id_Penumpang";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id_Penumpang", txtID.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            lblMessage.Text = "ID penumpang sudah digunakan!";
                            return;
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("addPenumpang", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_Penumpang", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@namaLengkap", nama);
                        cmd.Parameters.AddWithValue("@tanggalLahir", dtTgl.Value.ToString("yyyy-MM-dd").Trim());
                        cmd.Parameters.AddWithValue("@jnsKelamin", cmbJK.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@kewarganegaraan", kwn);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            transaction.Commit();
                            lblMessage.Text = "Data berhasil ditambahkan!";
                            _cache.Remove(PenumpangCacheKey);
                            LoadData(sender, e);
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

        private void logoToHome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void dgvPenumpang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPenumpang.Rows.Count - 1)
            {
                try
                {
                    DataGridViewRow row = dgvPenumpang.Rows[e.RowIndex];

                    var idValue = row.Cells["id_Penumpang"].Value;
                    txtID.Text = idValue != null && idValue != DBNull.Value ? idValue.ToString() : "";

                    var namaValue = row.Cells["namaLengkap"].Value;
                    txtNama.Text = namaValue != null && namaValue != DBNull.Value ? namaValue.ToString() : "";

                    var tglValue = row.Cells["tanggalLahir"].Value;
                    if (tglValue != null && tglValue != DBNull.Value)
                    {
                        dtTgl.Value = Convert.ToDateTime(tglValue);
                    }

                    var jkValue = row.Cells["jnsKelamin"].Value;
                    if (jkValue != null && jkValue != DBNull.Value)
                    {
                        cmbJK.SelectedItem = jkValue.ToString();
                    }
                    else
                    {
                        cmbJK.SelectedIndex = -1;
                    }

                    var kwnValue = row.Cells["kewarganegaraan"].Value;
                    txtKwn.Text = kwnValue != null && kwnValue != DBNull.Value ? kwnValue.ToString() : "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error saat mengambil data penumpang: " + ex.Message;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
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

                    PreviewForm previewForm = new PreviewForm(dt, "penumpang");
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
                    IF OBJECT_ID('dbo.penumpang', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_Penumpang_NamaLengkap')
                            CREATE NONCLUSTERED INDEX idx_Penumpang_NamaLengkap ON dbo.penumpang(namaLengkap);
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_Penumpang_Kewarganegaraan')
                            CREATE NONCLUSTERED INDEX idx_Penumpang_Kewarganegaraan ON dbo.penumpang(kewarganegaraan);
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
            var heavyQuery = "SELECT id_Penumpang, namaLengkap, kewarganegaraan FROM dbo.penumpang WHERE namaLengkap LIKE 'A%' AND kewarganegaraan = 'Indonesia'";
            AnalyzeQuery(heavyQuery);
        }
    }
}
