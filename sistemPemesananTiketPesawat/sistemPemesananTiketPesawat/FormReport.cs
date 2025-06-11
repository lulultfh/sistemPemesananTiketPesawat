using Microsoft.Reporting.WinForms;
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
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            SetupReportViewer();
            this.reportViewer1.RefreshReport();
        }
        private void SetupReportViewer()
        {
            string connectionString = "Data Source=LAPTOP-3EEN1RAM\\LULULUTHFIAH;Initial Catalog=sistemPemesananTiketPesawat;Integrated Security=True";
            string query = @"
                SELECT
                    p.pemesanan_id,
                    pel.email AS email_pelanggan,
                    p.waktuPesan,
                    p.statusPesan,
                    t.kodeTiket,
                    pn.namaLengkap AS nama_penumpang,
                    pnb.noPenerbangan,
                    pnb.asal,
                    pnb.tujuan,
                    pnb.waktuBrgkt,
                    m.nama_maskapai,
                    pnb.harga
                FROM 
                    pemesanan p
                JOIN pelanggan pel ON p.id_pelanggan = pel.id_pelanggan
                JOIN tiket t ON p.pemesanan_id = t.pemesanan_id
                JOIN penumpang pn ON t.id_penumpang = pn.id_penumpang
                JOIN penerbangan pnb ON t.id_penerbangan = pnb.id_penerbangan
                JOIN maskapai m ON pnb.id_maskapai = m.id_maskapai
                ORDER BY p.waktuPesan DESC;";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            ReportDataSource rds = new ReportDataSource("DataSet1", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.LocalReport.ReportPath = @"E:\\Kuliah\\Semester 4\\Pengembangan Aplikasi Basis Data\\Project PABD E11\\sistemPemesananTiketPesawat\\sistemPemesananTiketPesawat\\ReportPemesananTiket.rdlc";
            reportViewer1.RefreshReport();
        }

        private void logoToHome_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Hide();
        }
    }
}
