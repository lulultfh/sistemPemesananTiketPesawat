using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemPemesananTiketPesawat
{
    public partial class Home : Form
    {
        private string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH; Initial Catalog=sistemPemesananTiketPesawat; Integrated Security=True";
        public Home()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

  
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pnlPilihan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnToUser_Click(object sender, EventArgs e)
        {
            users userForm = new users();
            userForm.Show();
            this.Hide();
        }

        private void btnToAdmin_Click(object sender, EventArgs e)
        {
            Admin adminForm = new Admin();
            adminForm.Show();
            this.Hide();
        }

        private void btnToMaskapai_Click(object sender, EventArgs e)
        {
            Maskapai maskapaiForm = new Maskapai();
            maskapaiForm.Show();
            this.Hide();
        }

        private void btnToTiket_Click(object sender, EventArgs e)
        {
            Tiket tiketForm = new Tiket();
            tiketForm.Show();
            this.Hide();
        }

        private void btnToPemesanan_Click(object sender, EventArgs e)
        {
            Pemesanan pemesananForm = new Pemesanan();
            pemesananForm.Show();
            this.Hide();
        }

        private void btnToPenerbangan_Click(object sender, EventArgs e)
        {
            Penerbangan penerbanganForm = new Penerbangan();
            penerbanganForm.Show();
            this.Hide();
        }

        private void btnToPenumpang_Click(object sender, EventArgs e)
        {
            Penumpang penumpangForm = new Penumpang();
            penumpangForm.Show();
            this.Hide();
        }

        private void btnToPembayaran_Click(object sender, EventArgs e)
        {
            Pembayaran pembayaranForm = new Pembayaran();
            pembayaranForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void logoToHome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }
    }
}
