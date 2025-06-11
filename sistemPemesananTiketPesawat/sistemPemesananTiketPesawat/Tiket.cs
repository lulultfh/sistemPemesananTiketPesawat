using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace sistemPemesananTiketPesawat
{
    public partial class Tiket : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        private readonly MemoryCache _cache = MemoryCache.Default;
        private readonly CacheItemPolicy _policy = new CacheItemPolicy
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
        };
        private const string CacheKey = "tiketData";
        public Tiket()
        {
            InitializeComponent();
        }


        private void ClearForm()
        {
            txtID.Clear();
            if (cmbIDPsn.Items.Count > 0) cmbIDPsn.SelectedIndex = 0;
            if (cmbIDPnmp.Items.Count > 0) cmbIDPnmp.SelectedIndex = 0;
            if (cmbIDPnb.Items.Count > 0) cmbIDPnb.SelectedIndex = 0;
            txtKode.Clear();
            dgvTiket.ClearSelection();
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
                    var query = "SELECT id_tiket as [id_tiket], pemesanan_id, id_penumpang, id_penerbangan, kodeTiket FROM dbo.tiket";
                    var da = new SqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
                _cache.Add(CacheKey, dt, _policy);
            }
            dgvTiket.AutoGenerateColumns = true;
            dgvTiket.DataSource = dt;
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        connection.Open();

            //        string query = "SELECT id_tiket, pemesanan_id, id_penumpang, id_penerbangan, kodeTiket FROM tiket";
            //        SqlDataAdapter da = new SqlDataAdapter(query, connection);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);

            //        dgvTiket.AutoGenerateColumns = true;
            //        dgvTiket.DataSource = dt;
            //        ClearForm();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        private void LoadComboBoxData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //untuk pemesanan_id
                SqlDataAdapter daPesan = new SqlDataAdapter("SELECT pemesanan_id FROM pemesanan", conn);
                DataTable dtPesan = new DataTable();
                daPesan.Fill(dtPesan);
                cmbIDPsn.DataSource = dtPesan;
                cmbIDPsn.DisplayMember = "pemesanan_id";
                cmbIDPsn.ValueMember = "pemesanan_id";

                //untuk id_penumpang
                SqlDataAdapter daPnmp = new SqlDataAdapter("SELECT id_penumpang FROM penumpang", conn);
                DataTable dtPnmp = new DataTable();
                daPnmp.Fill(dtPnmp);
                cmbIDPnmp.DataSource = dtPnmp;
                cmbIDPnmp.DisplayMember = "id_penumpang";
                cmbIDPnmp.ValueMember = "id_penumpang";

                //untuk id_penerbangan
                SqlDataAdapter daPnb = new SqlDataAdapter("SELECT id_penerbangan FROM penerbangan", conn);
                DataTable dtPnb = new DataTable();
                daPnb.Fill(dtPnb);
                cmbIDPnb.DataSource = dtPnb;
                cmbIDPnb.DisplayMember = "id_penerbangan";
                cmbIDPnb.ValueMember = "id_penerbangan";
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlTransaction transaction = null;
                try
                {
                    using (var baru = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        if (txtID.Text == "" || cmbIDPsn.SelectedIndex == -1 || cmbIDPnmp.SelectedIndex == -1 || cmbIDPnb.SelectedIndex == -1 || txtKode.Text == "")
                        {
                            lblMessage.Text = "Silahkan isi semua data!";
                            return;
                        }
                        if (txtID.Text.Length > 10)
                        {
                            lblMessage.Text = "ID Tiket maksimal 10 karakter!";
                            return;
                        }
                        string kode;
                        kode = txtKode.Text.Trim().ToUpper();
                        if (kode.Length > 7)
                        {
                            lblMessage.Text = "Kode Tiket maksimal 7 karakter!";
                            return;
                        }
                        if (!System.Text.RegularExpressions.Regex.IsMatch(kode, @"^[A-Z0-9]+$"))
                        {
                            lblMessage.Text = "Kode Tiket hanya boleh berisi huruf kapital dan angka!";
                            return;
                        }
                        conn.Open();
                        transaction = conn.BeginTransaction();
                        using (SqlCommand cmd = new SqlCommand("addTiket", conn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@id_tiket", txtID.Text.Trim());
                            cmd.Parameters.AddWithValue("@pemesanan_id", cmbIDPsn.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@id_penumpang", cmbIDPnmp.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@id_penerbangan", cmbIDPnb.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@kodeTiket", kode);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        _cache.Remove(CacheKey);
                        lblMessage.Text = "Data berhasil ditambahkan!";
                        LoadData(sender, e);
                        ClearForm();
                    }               
                }
                catch (Exception ex)
                {
                    transaction?.Rollback();
                    lblMessage.Text = "Error: " + ex.Message;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _cache.Remove(CacheKey);
            LoadData(sender, e);
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            if (dgvTiket.SelectedRows.Count == 0)
            {
                lblMessage.Text = "Pilih data yang akan diubah!";
                return;
            }
            if (txtID.Text == "" || cmbIDPsn.SelectedIndex == -1 || cmbIDPnmp.SelectedIndex == -1 || cmbIDPnb.SelectedIndex == -1 || txtKode.Text == "")
            {
                lblMessage.Text = "Silahkan isi semua data!";
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                try
                {
                    if (txtID.Text.Length > 10)
                    {
                       lblMessage.Text = "ID Tiket maksimal 10 karakter!";
                        return;
                    }

                    string kode;
                    kode = txtKode.Text.Trim().ToUpper();
                    if (kode.Length > 7)
                    {
                        lblMessage.Text = "Kode Tiket maksimal 7 karakter! Silakan input yang benar!";
                        return;
                    }
                    if (!System.Text.RegularExpressions.Regex.IsMatch(kode, @"^[A-Z0-9]+$"))
                    {
                        lblMessage.Text = "Kode Tiket hanya boleh berisi huruf kapital dan angka!";
                        return;
                    }

                    conn.Open();
                    //string query = "UPDATE tiket SET pemesanan_id=@pemesanan_id, id_penumpang=@id_penumpang, id_penerbangan=@id_penerbangan, kodeTiket=@kodeTiket WHERE id_tiket=@id_tiket";
                    using (SqlCommand cmd = new SqlCommand("updateTiket", conn, transaction))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_tiket", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@pemesanan_id", cmbIDPsn.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@id_penumpang", cmbIDPnmp.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@id_penerbangan", cmbIDPnb.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@kodeTiket", kode);
                        cmd.ExecuteNonQuery();
                        int rows = cmd.ExecuteNonQuery();
                    }
                    transaction = conn.BeginTransaction();
                    _cache.Remove(CacheKey);
                    lblMessage.Text = "Data berhasil diperbarui!";
                    LoadData(sender, e);
                    ClearForm();
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
            if (dgvTiket.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            SqlTransaction transaction = null;
            try
            {
                var id = dgvTiket.SelectedRows[0].Cells["id_tiket"].Value.ToString();
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    transaction = conn.BeginTransaction();
                    using (var cmd = new SqlCommand("deleteTiket", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_tiket", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
                _cache.Remove(CacheKey);
                lblMessage.Text = "Data berhasil dihapus!";
                LoadData(sender, e);
                ClearForm();
            }
            catch(Exception ex)
            {
                transaction?.Rollback();
                lblMessage.Text = "Error: " + ex.Message;
            }
        }


        private void logoToHome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void dgvTiket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTiket.Rows.Count > 0) { 
                var row = dgvTiket.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                cmbIDPsn.SelectedValue = row.Cells[1].Value?.ToString() ?? string.Empty;
                cmbIDPnmp.SelectedValue = row.Cells[2].Value?.ToString() ?? string.Empty;
                cmbIDPnb.SelectedValue = row.Cells[3].Value?.ToString() ?? string.Empty;
                txtKode.Text = row.Cells[4].Value?.ToString() ?? string.Empty;
            }
        }

        private void Tiket_Load_1(object sender, EventArgs e)
        {
            EnsureIndexes();
            LoadData(sender, e);
            LoadComboBoxData();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xlsm";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
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
                    foreach(var cell in headerRow.Cells)
                    {
                        dt.Columns.Add(cell.ToString());
                    }
                    for (int i=1; i <= sheet.LastRowNum; i++)
                    {
                        IRow dataRow = sheet.GetRow(i);
                        DataRow newRow = dt.NewRow();
                        int cellIndex = 0;
                        foreach (var cell in dataRow.Cells)
                        {
                            newRow[cellIndex++] = cell.ToString();
                        }
                        dt.Rows.Add(newRow);
                    }
                    PreviewForm previewForm = new PreviewForm(dt, "tiket");
                    previewForm.ShowDialog();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error reading the Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        
        private void EnsureIndexes()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var indexScript = @"
                IF OBJECT_ID('dbo.tiket', 'U') IS NOT NULL
                    BEGIN
                        IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'idx_tiket_kodeTiket')
                        CREATE NONCLUSTERED INDEX idx_tiket_kodeTiket ON dbo.tiket(kodeTiket);
                    END";
                using (var cmd = new SqlCommand(indexScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var heavyQuery = "SELECT kodeTiket FROM dbo.tiket WHERE kodeTiket LIKE 'GA%'";
            AnalyzeQuery(heavyQuery);
        }
    }
}
