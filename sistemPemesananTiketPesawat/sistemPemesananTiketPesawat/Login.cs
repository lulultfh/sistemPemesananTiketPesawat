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
    public partial class FromLogin : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH; Initial Catalog=sistemPemesananTiketPesawat; Integrated Security=True";

        public FromLogin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUname.Text;
            string password = txtPasswd.Text;
            string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH; Initial Catalog=sistemPemesananTiketPesawat; Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM admin WHERE email = @Email AND password = @Password";
                    using (SqlCommand cekCmd = new SqlCommand(query, conn))
                    {
                        cekCmd.Parameters.AddWithValue("@Email", username);
                        cekCmd.Parameters.AddWithValue("@Password", password);

                        int count = (int)cekCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            Home form2 = new Home();
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Email atau password salah", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Terjadi kesalahan saat menghubungi database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FromLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
