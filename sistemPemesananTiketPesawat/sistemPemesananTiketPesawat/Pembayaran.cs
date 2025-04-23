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

namespace sistemPemesananTiketPesawat
{
    public partial class Pembayaran : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";

        public Pembayaran()
        {
            InitializeComponent();
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtJumlah.Clear();
            txtStatus.Clear();
            txtIDFK.Clear();
            txtID.Focus();
        }

        private void Pembayaran_Load(object sender, EventArgs e)
        {
            LoadData(sender, e);
        }

        private void LoadData(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_pembayaran, jumlah_bayar,  statusBayar, pemesanan_id FROM Pembayaran";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvPembayaran.AutoGenerateColumns = true;
                    dgvPembayaran.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(sender, e);
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtID.Text == "" || txtJumlah.Text == "" || txtStatus.Text == "" || txtIDFK.Text == "")
                    {
                        MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    conn.Open();    
                    string query = "INSERT INTO pembayaran (id_pembayaran, jumlah_bayar,  statusBayar, pemesanan_id) VALUES (@id_pembayaran, @jumlah_bayar, @statusBayar, @pemesanan_id)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_pembayaran", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@jumlah_bayar", txtJumlah.Text.Trim());
                        cmd.Parameters.AddWithValue("@statusBayar", txtStatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@pemesanan_id", txtIDFK.Text.Trim());

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Data berhasil ditambahkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(sender, e);
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menambahkan data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPembayaran.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string id = dgvPembayaran.SelectedRows[0].Cells["id_pembayaran"].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM pembayaran WHERE id_pembayaran = @id_pembayaran";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_pembayaran", id);
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
                else
                {
                    MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtJumlah.Text == "" || txtStatus.Text == "" || txtIDFK.Text == "")
            {
                MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE pembayaran SET jumlah_bayar = @jumlah_bayar, statusBayar = @statusBayar, pemesanan_id = @pemesanan_id WHERE id_pembayaran = @id_pembayaran";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_pembayaran", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@jumlah_bayar", txtJumlah.Text.Trim());
                        cmd.Parameters.AddWithValue("@statusBayar", txtStatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@pemesanan_id", txtIDFK.Text.Trim());

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

        private void dgvPembayaran_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPembayaran.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtJumlah.Text = row.Cells[1].Value.ToString();
                txtStatus.Text = row.Cells[2].Value.ToString();
                txtIDFK.Text = row.Cells[3].Value.ToString();
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
