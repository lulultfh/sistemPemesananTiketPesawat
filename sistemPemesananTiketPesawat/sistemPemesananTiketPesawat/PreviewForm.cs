using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace sistemPemesananTiketPesawat
{
    public partial class PreviewForm : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        private string targetTable;

        public PreviewForm(DataTable data, string tableName)
        {
            InitializeComponent();
            dgvPrev.DataSource = data;
            targetTable = tableName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin mengimpor data ke database?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (targetTable == "tiket")
                    ImportTiketToDatabase();
                else if (targetTable == "penerbangan")
                    ImportPenerbanganToDatabase();
                else if (targetTable == "penumpang")
                    ImportPenumpangToDatabase();
                else if (targetTable == "pemesanan")
                    ImportPemesananToDatabase();
                else if (targetTable == "maskapai")
                    ImportMaskapaiToDatabase();
                else if (targetTable == "admin")
                    ImportAdminToDatabase();
                else if (targetTable == "pelanggan")
                    ImportPelangganToDatabase();
                else if (targetTable == "pembayaran")
                    ImportPembayaranToDatabase();
                else
                    MessageBox.Show("Tabel tidak dikenali.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            dgvPrev.AutoResizeColumns();
            if (dgvPrev.Columns.Contains("waktuBrgkt"))
                dgvPrev.Columns["waktuBrgkt"].DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm";

            if (dgvPrev.Columns.Contains("waktuKedatangan"))
                dgvPrev.Columns["waktuKedatangan"].DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm";
        }

        private bool ValidateRow(DataRow row)
        {
            if (targetTable == "tiket")
            {
                string id_tiket = row["id_tiket"].ToString();
                if (id_tiket.Length > 10)
                {
                    MessageBox.Show("ID Tiket tidak boleh lebih dari 10 karakter.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if(targetTable == "penerbangan")
            {
                //string waktuBrgkt = row["waktuBrgkt"].ToString();
                //string waktuKedatangan = row["waktuKedatangan"].ToString();

                //MessageBox.Show("waktuBrgkt: " + row["waktuBrgkt"].ToString());
                //MessageBox.Show("waktuKedatangan: " + row["waktuKedatangan"].ToString());
                string id_penerbangan = row["id_penerbangan"].ToString();
                if (id_penerbangan.Length > 10)
                {
                    MessageBox.Show("ID Penerbangan tidak boleh lebih dari 10 karakter.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!decimal.TryParse(row["harga"].ToString(), out decimal harga) || harga <= 0)
                {
                    MessageBox.Show("Harga harus berupa angka positif.", "Kesalahan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                DateTime waktuBrgkt;
                DateTime waktuKedatangan;
                if (row["waktuBrgkt"] == DBNull.Value || string.IsNullOrWhiteSpace(row["waktuBrgkt"].ToString()))
                {
                    MessageBox.Show("Waktu keberangkatan tidak boleh kosong.", "Kesalahan validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (row["waktuKedatangan"] == DBNull.Value || string.IsNullOrWhiteSpace(row["waktuKedatangan"].ToString()))
                {
                    MessageBox.Show("Waktu kedatangan tidak boleh kosong.", "Kesalahan validasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (DateTime.TryParse(row["waktuBrgkt"].ToString(), out waktuBrgkt) &&
                    DateTime.TryParse(row["waktuKedatangan"].ToString(), out waktuKedatangan))
                {
                    if (waktuKedatangan <= waktuBrgkt)
                    {
                        MessageBox.Show("Waktu kedatangan tidak boleh sebelum waktu keberangkatan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    row["waktuBrgkt"] = waktuBrgkt;
                    row["waktuKedatangan"] = waktuKedatangan;
                }
                else
                {
                    MessageBox.Show("Format tanggal/jam tidak sesuai ketentuan.", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (targetTable == "pemesanan")
            {
                string id = row["pemesanan_id"].ToString();
                if (id.Length != 8)
                {
                    MessageBox.Show("ID Pemesanan harus tepat 8 karakter.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!DateTime.TryParse(row["waktuPesan"].ToString(), out DateTime waktuPesan))
                {
                    MessageBox.Show("Format Waktu Pesan tidak valid.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (waktuPesan < DateTime.Now)
                {
                    MessageBox.Show("Waktu Pemesanan tidak boleh di masa lalu.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string status = row["statusPesan"].ToString().ToLower();
                if (status != "pending" && status != "confirmed" && status != "canceled")
                {
                    MessageBox.Show("Status Pemesanan hanya boleh 'pending', 'confirmed', atau 'canceled'.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!int.TryParse(row["id_pelanggan"].ToString(), out int idPelanggan) || idPelanggan <= 0)
                {
                    MessageBox.Show("ID Pelanggan harus berupa angka positif.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (targetTable == "penumpang")
            {
                string idPenumpang = row["id_Penumpang"].ToString();
                if (idPenumpang.Length > 10)
                {
                    MessageBox.Show("ID Penumpang tidak boleh lebih dari 10 karakter.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string nama = row["namaLengkap"].ToString();
                if (nama.Length == 0 || nama.Length > 75 ||
                    !Regex.IsMatch(nama, @"^[a-zA-Z'\s]+$"))
                {
                    MessageBox.Show("Nama lengkap wajib diisi, ≤ 75 karakter, dan hanya huruf/spasi/tanda petik.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!DateTime.TryParse(row["tanggalLahir"].ToString(), out DateTime tglLahir))
                {
                    MessageBox.Show("Format Tanggal Lahir tidak valid.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (tglLahir >= DateTime.Today)
                {
                    MessageBox.Show("Tanggal lahir harus di masa lalu.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string jk = row["jnsKelamin"].ToString().ToLower();
                if (jk != "perempuan" && jk != "laki-laki")
                {
                    MessageBox.Show("Jenis Kelamin harus 'perempuan' atau 'laki-laki'.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string kwn = row["kewarganegaraan"].ToString();
                if (kwn.Length == 0 || kwn.Length > 20 || !Regex.IsMatch(kwn, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Kewarganegaraan wajib diisi, ≤ 20 karakter, dan hanya huruf/spasi.",
                                    "Kesalahan Validasi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (targetTable == "maskapai")
            {
                string id = row["id_maskapai"].ToString().Trim();
                string nama = row["nama_maskapai"].ToString().Trim();
                string kode = row["kode_maskapai"].ToString().Trim();
                string negara = row["negara_asal"].ToString().Trim();

                if (string.IsNullOrWhiteSpace(id) || id.Length > 7)
                {
                    MessageBox.Show("ID Maskapai tidak boleh kosong dan maksimal 7 karakter.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(nama) || !System.Text.RegularExpressions.Regex.IsMatch(nama, @"^[a-zA-Z'\s]+$"))
                {
                    MessageBox.Show("Nama maskapai tidak valid.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(kode) || kode.Length > 5 || !System.Text.RegularExpressions.Regex.IsMatch(kode, @"^[A-Z]+$"))
                {
                    MessageBox.Show("Kode maskapai harus huruf kapital, maksimal 5 karakter.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(negara) || !System.Text.RegularExpressions.Regex.IsMatch(negara, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Negara asal tidak valid.");
                    return false;
                }
            }
            if (targetTable == "admin")
            {
                string id = row["id_admin"].ToString().Trim();
                string nama = row["nama"].ToString().Trim();
                string email = row["email"].ToString().Trim();
                string password = row["password"].ToString().Trim();

                if (!int.TryParse(id, out _))
                {
                    MessageBox.Show("ID Admin harus berupa angka.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(nama) || !System.Text.RegularExpressions.Regex.IsMatch(nama, @"^[a-zA-Z'\s]+$"))
                {
                    MessageBox.Show("Nama admin tidak valid.");
                    return false;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Format email tidak valid.");
                    return false;
                }

                if (password.Length < 8)
                {
                    MessageBox.Show("Password harus minimal 8 karakter.");
                    return false;
                }
            }
            else if (targetTable == "pembayaran")
            {
                if (!row.Table.Columns.Contains("id_pembayaran") || !row.Table.Columns.Contains("jumlah_bayar"))
                {
                    MessageBox.Show("Kolom tidak ditemukan di DataTable.");
                    return false;
                }

                string id = row["id_pembayaran"].ToString().Trim();
                string jumlah = row["jumlah_bayar"].ToString().Trim();
                string tanggal = row["tanggal_bayar"].ToString().Trim();
                string status = row["statusBayar"].ToString().Trim();
                string pemesananId = row["pemesanan_id"].ToString().Trim();

                if (!int.TryParse(id, out _))
                {
                    MessageBox.Show("ID Pembayaran harus berupa angka.");
                    return false;
                }

                if (!decimal.TryParse(jumlah, out _))
                {
                    MessageBox.Show("Jumlah bayar harus berupa angka desimal.");
                    return false;
                }

                if (!DateTime.TryParse(tanggal, out _))
                {
                    MessageBox.Show("Format tanggal tidak sesuai.");
                    return false;
                }

                string[] statusValid = { "Pending", "Berhasil", "Gagal" };
                if (!statusValid.Contains(status))
                {
                    MessageBox.Show("Status bayar tidak valid. Harus 'Pending', 'Berhasil', atau 'Gagal'.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(pemesananId) || pemesananId.Length != 8)
                {
                    MessageBox.Show("ID Pemesanan harus 8 karakter.");
                    return false;
                }
            }

            else if (targetTable == "pelanggan")
            {
                string id = row["id_pelanggan"].ToString().Trim();
                string nama = row["nama"].ToString().Trim();
                string email = row["email"].ToString().Trim();
                string password = row["passwd"].ToString().Trim();
                string noTelp = row["noTelp"].ToString().Trim();

                if (!int.TryParse(id, out _))
                {
                    MessageBox.Show("ID Pelanggan harus berupa angka.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(nama))
                {
                    MessageBox.Show("Nama tidak boleh kosong.");
                    return false;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Format email tidak valid.");
                    return false;
                }

                if (password.Length < 8)
                {
                    MessageBox.Show("Password harus minimal 8 karakter.");
                    return false;
                }

                if (!noTelp.StartsWith("+62") || noTelp.Length < 11 || noTelp.Length > 14)
                {
                    MessageBox.Show("Nomor telepon harus awalan '+62' dan panjang 11–14 karakter.");
                    return false;
                }
            }
            return true;
        }
        private void ImportTiketToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPrev.DataSource;
                int importedRows = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (!ValidateRow(row))
                    {
                        continue;
                    }

                    string query = "INSERT INTO tiket (id_tiket, pemesanan_id, id_penumpang, id_penerbangan, kodeTiket) VALUES (@id_tiket, @pemesanan_id, @id_penumpang, @id_penerbangan, @kodeTiket)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_tiket", row["id_tiket"]);
                            cmd.Parameters.AddWithValue("@pemesanan_id", row["pemesanan_id"]);
                            cmd.Parameters.AddWithValue("@id_penumpang", row["id_penumpang"]);
                            cmd.Parameters.AddWithValue("@id_penerbangan", row["id_penerbangan"]);
                            cmd.Parameters.AddWithValue("@kodeTiket", row["kodeTiket"]);
                            cmd.ExecuteNonQuery();
                            importedRows++;
                        }
                    }
                }
                if (importedRows > 0)
                {
                    MessageBox.Show($"{importedRows} data berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tidak ada data yang valid untuk diimpor.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportPenerbanganToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPrev.DataSource;
                int importedRows = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (!ValidateRow(row)) { 
                        continue; 
                    }

                    /*DateTime waktuBrgkt = (DateTime)row["waktuBrgkt"];
                    DateTime waktuKedatangan = (DateTime)row["waktuKedatangan"];*/

                    DateTime waktuBrgkt = Convert.ToDateTime(row["waktuBrgkt"]); //ini untuk mengkonversi string ke DateTime
                    DateTime waktuKedatangan = Convert.ToDateTime(row["waktuKedatangan"]);

                    string query = "insert into penerbangan(id_penerbangan, noPenerbangan, tujuan, asal, waktuBrgkt, waktuKedatangan, harga, id_maskapai)" +
                        "values(@id_penerbangan, @noPenerbangan, @tujuan, @asal, @waktuBrgkt, @waktuKedatangan, @harga, @id_maskapai)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_penerbangan", row["id_penerbangan"]);
                            cmd.Parameters.AddWithValue("@noPenerbangan", row["noPenerbangan"]);
                            cmd.Parameters.AddWithValue("@tujuan", row["tujuan"]);
                            cmd.Parameters.AddWithValue("@asal", row["asal"]);
                            cmd.Parameters.AddWithValue("@waktuBrgkt", waktuBrgkt.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@waktuKedatangan", waktuKedatangan.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@harga", Convert.ToDecimal(row["harga"]));
                            cmd.Parameters.AddWithValue("@id_maskapai", row["id_maskapai"]);
                            cmd.ExecuteNonQuery();
                            importedRows++;
                        }
                    }
                }
                if (importedRows > 0)
                {
                    MessageBox.Show($"{importedRows} data penerbangan berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tidak ada data penerbangan yang valid untuk diimpor.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //MessageBox.Show("Data penerbaangan berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data penerbangan: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
        private void ImportPenumpangToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPrev.DataSource;
                foreach (DataRow row in dt.Rows)
                {
                    if (!ValidateRow(row))
                        continue;

                    string query = "INSERT INTO penumpang (id_penumpang, namaLengkap, tanggalLahir, jnsKelamin, kewarganegaraan) " +
                                   "VALUES (@id_penumpang, @namaLengkap, @tanggalLahir, @jnsKelamin, @kewarganegaraan)";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_penumpang", row["id_penumpang"]);
                            cmd.Parameters.AddWithValue("@namaLengkap", row["namaLengkap"]);
                            cmd.Parameters.AddWithValue("@tanggalLahir", row["tanggalLahir"]);
                            cmd.Parameters.AddWithValue("@jnsKelamin", row["jnsKelamin"]);
                            cmd.Parameters.AddWithValue("@kewarganegaraan", row["kewarganegaraan"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Data penumpang berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data penumpang: " + ex.Message,
                                "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ImportPemesananToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPrev.DataSource;
                foreach (DataRow row in dt.Rows)
                {
                    if (!ValidateRow(row))
                        continue;

                    string query = "INSERT INTO pemesanan (pemesanan_id, waktuPesan, statusPesan, id_pelanggan) " +
                                   "VALUES (@pemesanan_id, @waktuPesan, @statusPesan, @id_pelanggan)";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@pemesanan_id", row["pemesanan_id"]);
                            cmd.Parameters.AddWithValue("@waktuPesan", row["waktuPesan"]);
                            cmd.Parameters.AddWithValue("@statusPesan", row["statusPesan"]);
                            cmd.Parameters.AddWithValue("@id_pelanggan", row["id_pelanggan"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Data pemesanan berhasil diimpor ke database.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengimpor data pemesanan: " + ex.Message,
                                "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ImportMaskapaiToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPrev.DataSource;
                foreach (DataRow row in dt.Rows)
                {
                    if (!ValidateRow(row)) continue;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO maskapai (id_maskapai, nama_maskapai, kode_maskapai, negara_asal) VALUES (@id, @nama, @kode, @negara)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", row["id_maskapai"]);
                            cmd.Parameters.AddWithValue("@nama", row["nama_maskapai"]);
                            cmd.Parameters.AddWithValue("@kode", row["kode_maskapai"]);
                            cmd.Parameters.AddWithValue("@negara", row["negara_asal"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Data maskapai berhasil diimpor.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal impor maskapai: " + ex.Message);
            }
        }
        private void ImportAdminToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPrev.DataSource;
                foreach (DataRow row in dt.Rows)
                {
                    if (!ValidateRow(row)) continue;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO admin (id_admin, nama, email, password) VALUES (@id, @nama, @email, @pass)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", row["id_admin"]);
                            cmd.Parameters.AddWithValue("@nama", row["nama"]);
                            cmd.Parameters.AddWithValue("@email", row["email"]);
                            cmd.Parameters.AddWithValue("@pass", row["password"]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Data admin berhasil diimpor.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal impor admin: " + ex.Message);
            }
        }
        private void ImportPembayaranToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPrev.DataSource;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk diimpor.");
                    return;
                }

                int sukses = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (!ValidateRow(row)) continue;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO pembayaran (id_pembayaran, jumlah_bayar, statusBayar, tanggal_bayar, pemesanan_id) " +
                                       "VALUES (@id, @jumlah, @status, @tanggal, @pemesanan)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", row["id_pembayaran"]);
                            cmd.Parameters.AddWithValue("@jumlah", Convert.ToDecimal(row["jumlah_bayar"]));
                            cmd.Parameters.AddWithValue("@status", row["statusBayar"]);
                            cmd.Parameters.AddWithValue("@tanggal", Convert.ToDateTime(row["tanggal_bayar"]));
                            cmd.Parameters.AddWithValue("@pemesanan", row["pemesanan_id"]);
                            cmd.ExecuteNonQuery();
                        }
                        sukses++;
                    }
                }

                MessageBox.Show($"Impor selesai. {sukses} baris berhasil dimasukkan.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal impor pembayaran: " + ex.Message);
            }
        }
        private void ImportPelangganToDatabase()
        {
            try
            {
                DataTable dt = (DataTable)dgvPrev.DataSource;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk diimpor.");
                    return;
                }

                int sukses = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (!ValidateRow(row)) continue;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO pelanggan (id_pelanggan, nama, email, passwd, noTelp) " +
                                       "VALUES (@id, @nama, @email, @passwd, @telp)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", row["id_pelanggan"]);
                            cmd.Parameters.AddWithValue("@nama", row["nama"]);
                            cmd.Parameters.AddWithValue("@email", row["email"]);
                            cmd.Parameters.AddWithValue("@passwd", row["passwd"]);
                            cmd.Parameters.AddWithValue("@telp", row["noTelp"]);
                            cmd.ExecuteNonQuery();
                        }
                        sukses++;
                    }
                }

                MessageBox.Show($"Impor selesai. {sukses} baris berhasil dimasukkan.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal impor pelanggan: " + ex.Message);
            }
        }
    }
}
