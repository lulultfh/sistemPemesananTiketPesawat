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
    public partial class Penerbangan : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";

        public Penerbangan()
        {
            InitializeComponent();
        }

        private void Penerbangan_Load(object sender, EventArgs e)
        {
            LoadData(sender, e);
        }

        private void ClearForm()
        {
            txtID.Clear();
            txtNoPenerbangan.Clear();
            txtTujuan.Clear();
            txtAsal.Clear();
            txtBerangkat.Clear();
            txtKedatangan.Clear();
            txtHarga.Clear();
            txtIDFK.Clear();
            txtID.Focus();
        }

        private void LoadData(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT id_penerbangan, noPenerbangan, tujuan, asal, waktuBrgkt, waktuKedatangan, harga, id_maskapai FROM penerbangan";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPenerbangan.AutoGenerateColumns = true;
                    dgvPenerbangan.DataSource = dt;
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtNoPenerbangan.Text == "" || txtTujuan.Text == "" || txtAsal.Text == "" || txtBerangkat.Text == "" || txtKedatangan.Text == "" || txtHarga.Text == "" || txtIDFK.Text == "")
            {
                MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE penerbangan SET noPenerbangan = @noPenerbangan, tujuan=@tujuan, asal = @asal, waktuBrgkt = @waktuBrgkt, waktuKedatangan = @waktuKedatangan, harga = @harga, id_maskapai = @id_maskapai WHERE id_penerbangan = @id_penerbangan";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_penerbangan", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@noPenerbangan", txtNoPenerbangan.Text.Trim());
                        cmd.Parameters.AddWithValue("@tujuan", txtTujuan.Text.Trim());
                        cmd.Parameters.AddWithValue("@asal", txtAsal.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuBrgkt", txtBerangkat.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuKedatangan", txtKedatangan.Text.Trim());
                        cmd.Parameters.AddWithValue("@harga", txtHarga.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_maskapai", txtIDFK.Text.Trim());


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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData(sender, e);
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvPenerbangan.SelectedRows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            string id = dgvPenerbangan.SelectedRows[0].Cells["id_penerbangan"].Value.ToString();
                            conn.Open();
                            string query = "DELETE FROM penerbangan WHERE id_penerbangan = @id_penerbangan";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id_penerbangan", id);
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

        private void dgvPenerbangan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPenerbangan.Rows[e.RowIndex];
                txtID.Text = row.Cells[0].Value.ToString();
                txtNoPenerbangan.Text = row.Cells[1].Value.ToString();
                txtTujuan.Text = row.Cells[2].Value.ToString();
                txtAsal.Text = row.Cells[3].Value.ToString();
                txtBerangkat.Text = row.Cells[4].Value.ToString();
                txtKedatangan.Text = row.Cells[5].Value.ToString();
                txtHarga.Text = row.Cells[6].Value.ToString();

                txtIDFK.Text = row.Cells[7].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {

        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    if (txtID.Text == "" || txtNoPenerbangan.Text == "" || txtTujuan.Text == "" || txtAsal.Text == "" || txtBerangkat.Text == "" || txtKedatangan.Text == "" || txtHarga.Text == "" || txtIDFK.Text == "")
                    {
                        MessageBox.Show("Silahkan isi semua data!", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    conn.Open();
                    string query = "INSERT INTO penerbangan (id_penerbangan, noPenerbangan, tujuan, asal, waktuBrgkt, waktuKedatangan, harga, id_maskapai) VALUES (@id_penerbangan, @noPenerbangan, @tujuan, @asal, @waktuBrgkt, @waktuKedatangan, @harga, @id_maskapai)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_penerbangan", txtID.Text.Trim());
                        cmd.Parameters.AddWithValue("@noPenerbangan", txtNoPenerbangan.Text.Trim());
                        cmd.Parameters.AddWithValue("@tujuan", txtTujuan.Text.Trim());
                        cmd.Parameters.AddWithValue("@asal", txtAsal.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuBrgkt", txtBerangkat.Text.Trim());
                        cmd.Parameters.AddWithValue("@waktuKedatangan", txtKedatangan.Text.Trim());
                        cmd.Parameters.AddWithValue("@harga", txtHarga.Text.Trim());
                        cmd.Parameters.AddWithValue("@id_maskapai", txtIDFK.Text.Trim());

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
    }
}
