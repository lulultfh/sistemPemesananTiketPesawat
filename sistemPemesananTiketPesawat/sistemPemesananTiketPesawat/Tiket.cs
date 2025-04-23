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
    public partial class Tiket : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";

        public Tiket()
        {
            InitializeComponent();
        }


        private void ClearForm()
        {
            txtID.Clear();
            txtIDPesan.Clear();
            txtIDPnmp.Clear();
            txtIDTerbang.Clear();
            txtKode.Clear();
            txtID.Focus();
        }

        private void LoadData(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id_tiket, pemesanan_id, id_penumpang, id_penerbangan, kodeTiket FROM tiket";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTiket.AutoGenerateColumns = true;
                    dgvTiket.DataSource = dt;
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtID.Text == "" || txtIDPesan.Text == "" || txtIDPnmp.Text == "" || txtIDTerbang.Text == "" || txtKode.Text == "")
                    {
                        MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    conn.Open();
                    string query = "INSERT INTO tiket (id_tiket, pemesanan_id, id_penumpang, id_penerbangan, kodeTiket) VALUES (@id_tiket, @pemesanan_id, @id_penumpang, @id_penerbangan, @kodeTiket)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_tiket", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@pemesanan_id", txtIDPesan.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_penumpang", txtIDPnmp.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_penerbangan", txtIDTerbang.Text.Trim());
                        cmd.Parameters.AddWithValue("@kodeTiket", txtKode.Text.Trim());

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(sender, e);
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtIDPesan.Text == "" || txtIDPnmp.Text == "" || txtIDTerbang.Text == "" || txtKode.Text == "")
            {
                MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tiket SET pemesanan_id=@pemesanan_id, id_penumpang=@id_penumpang, id_penerbangan=@id_penerbangan, kodeTiket=@kodeTiket WHERE id_tiket=@id_tiket";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_tiket", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@pemesanan_id", txtIDPesan.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_penumpang", txtIDPnmp.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_penerbangan", txtIDTerbang.Text.Trim());
                        cmd.Parameters.AddWithValue("@kodeTiket", txtKode.Text.Trim());


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

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvTiket.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string id = dgvTiket.SelectedRows[0].Cells["id_tiket"].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM tiket WHERE id_tiket = @id_tiket";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_tiket", id);
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


        private void logoToHome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }

        private void dgvTiket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTiket.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtIDPesan.Text = row.Cells[1].Value.ToString();
                txtIDPnmp.Text = row.Cells[2].Value.ToString();
                txtIDTerbang.Text = row.Cells[3].Value.ToString();
                txtKode.Text = row.Cells[4].Value.ToString();
                
            }
        }

        private void Tiket_Load_1(object sender, EventArgs e)
        {
            LoadData(sender, e);
        }

        private void txtIDPnmp_Click(object sender, EventArgs e)
        {
            
        }
    }
}
