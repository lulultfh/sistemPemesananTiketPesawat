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

namespace sistemPemesananTiketPesawat
{
    public partial class Pemesanan : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
        public Pemesanan()
        {
            InitializeComponent();
        }
        private void Pemesanan_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ClearForm()
        {
            txtID.Clear();
            txtWaktu.Clear();
            txtStatus.Clear();
            txtIDFK.Clear();
            txtID.Focus();
        }


        private void dgvPemesanan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPemesanan.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtWaktu.Text = row.Cells[1].Value.ToString();
                txtStatus.Text = row.Cells[2].Value.ToString();
                txtIDFK.Text = row.Cells[3].Value.ToString();
            }

        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtWaktu.Text == "" || txtStatus.Text == "" || txtIDFK.Text == "")
            {
                MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE pemesanan SET waktuPesan = @waktuPesan, statusPesan = @statusPesan, id_user = @id_user WHERE pemesanan_id = @pemesanan_id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pemesanan_id", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuPesan", txtWaktu.Text.Trim());
                        cmd.Parameters.AddWithValue("@statusPesan", txtStatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_user", txtIDFK.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Data berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if(dgvPemesanan.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using(SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string id = dgvPemesanan.SelectedRows[0].Cells["pemesanan_id"].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM pemesanan WHERE pemesanan_id = @pemesanan_id";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@pemesanan_id", id);
                                int rows = cmd.ExecuteNonQuery();

                                if (rows > 0)
                                {
                                    MessageBox.Show("Data berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadData();
                                }
                            }
                        }
                        catch(Exception ex)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtID.Text == "" || txtWaktu.Text == "" || txtStatus.Text == "" || txtIDFK.Text == "")
                    {
                        MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    conn.Open();
                    string query = "INSERT INTO pemesanan (pemesanan_id, waktuPesan, statusPesan, id_user) VALUES (@pemesanan_id, @waktuPesan, @statusPesan, @id_user)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pemesanan_id", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuPesan", txtWaktu.Text.Trim());
                        cmd.Parameters.AddWithValue("@statusPesan", txtStatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_user", txtIDFK.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

           private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT pemesanan_id, waktuPesan, statusPesan, id_user FROM pemesanan";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPemesanan.AutoGenerateColumns = true;
                    dgvPemesanan.DataSource = dt;
                    ClearForm();
                }
                catch(Exception ex)
                {
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
    }
}
