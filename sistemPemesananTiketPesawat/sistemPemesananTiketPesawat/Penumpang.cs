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

namespace sistemPemesananTiketPesawat
{
    public partial class Penumpang : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=DB_PemesananTiketPesawat;Integrated Security=True";

        public Penumpang()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtNama.Clear();
            txtTgl.Clear();
            txtJK.Clear();
            txtKwn.Clear();

            txtID.Focus();

        }
        private void LoadData(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id_Penumpang, namaLengkap, tanggalLahir, jnsKelamin, kewarganegaraan  * FROM penumpang";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPenumpang.AutoGenerateColumns = true;
                    dgvPenumpang.DataSource = dt;
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Penumpang_Load(object sender, EventArgs e)
        {
            LoadData(sender, e);
        }

        private void txtKode_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblKode_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
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
                        try
                        {
                            string id = dgvPenumpang.SelectedRows[0].Cells["id_Penumpang"].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM penumpang WHERE id_Penumpang = @id_Penumpang";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_Penumpang", id);
                                int rows = cmd.ExecuteNonQuery();

                                if (rows > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData(sender, e);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtNama.Text == "" || txtTgl.Text == "" || txtJK.Text == "" || txtKwn.Text == "")
            {
                MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE penumpang SET namaLengkap = @namaLengkap, tanggalLahir = @tanggalLahir, jnsKelamin = @jnsKelamin, kewarganegaraan = @kewarganegaraan WHERE id_Penumpang = @id_Penumpang";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_Penumpang", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@namaLengkap", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@tanggalLahir", txtTgl.Text.Trim());
                        cmd.Parameters.AddWithValue("@jnsKelamin", txtJK.Text.Trim());
                        cmd.Parameters.AddWithValue("@kewarganegaraan", txtKwn.Text.Trim());


                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Data berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Data tidak ditemukan!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtID.Text == "" || txtNama.Text == "" || txtTgl.Text == "" || txtJK.Text == "" || txtKwn.Text == "")
                    {
                        MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    conn.Open();
                    string query = "INSERT INTO pemesanan (id_Penumpang, namaLengkap, tanggalLahir, jnsKelamin, kewarganegaraan) VALUES (@id_Penumpang, @namaLengkap, @tanggalLahir, @jnsKelamin, @kewarganegaraan)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_Penumpang", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@namaLengkap", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@tanggalLahir", txtTgl.Text.Trim());
                        cmd.Parameters.AddWithValue("@jnsKelamin", txtJK.Text.Trim());
                        cmd.Parameters.AddWithValue("@kewarganegaraan", txtKwn.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void logoToHome_Click(object sender, EventArgs e)
        {

        }

        private void dgvPenumpang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPenumpang.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtNama.Text = row.Cells[1].Value.ToString();
                txtTgl.Text = row.Cells[2].Value.ToString();
                txtJK.Text = row.Cells[3].Value.ToString();
                txtKwn.Text = row.Cells[4].Value.ToString();

            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

        }
    }
}
