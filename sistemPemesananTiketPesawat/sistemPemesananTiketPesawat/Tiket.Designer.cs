namespace sistemPemesananTiketPesawat
{
    partial class Tiket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tiket));
            this.logoToHome = new System.Windows.Forms.PictureBox();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblKode = new System.Windows.Forms.Label();
            this.lblIDFKTerbang = new System.Windows.Forms.Label();
            this.lblIDPesan = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.dgvTiket = new System.Windows.Forms.DataGridView();
            this.lblPenumpang = new System.Windows.Forms.Label();
            this.cmbIDPsn = new System.Windows.Forms.ComboBox();
            this.cmbIDPnmp = new System.Windows.Forms.ComboBox();
            this.cmbIDPnb = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).BeginInit();
            this.SuspendLayout();
            // 
            // logoToHome
            // 
            this.logoToHome.BackColor = System.Drawing.Color.Transparent;
            this.logoToHome.Image = ((System.Drawing.Image)(resources.GetObject("logoToHome.Image")));
            this.logoToHome.Location = new System.Drawing.Point(12, 26);
            this.logoToHome.Name = "logoToHome";
            this.logoToHome.Size = new System.Drawing.Size(188, 136);
            this.logoToHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoToHome.TabIndex = 16;
            this.logoToHome.TabStop = false;
            this.logoToHome.Click += new System.EventHandler(this.logoToHome_Click);
            // 
            // txtKode
            // 
            this.txtKode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKode.Location = new System.Drawing.Point(437, 531);
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(387, 26);
            this.txtKode.TabIndex = 28;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(437, 238);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(387, 26);
            this.txtID.TabIndex = 25;
            // 
            // lblKode
            // 
            this.lblKode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKode.AutoSize = true;
            this.lblKode.BackColor = System.Drawing.Color.Transparent;
            this.lblKode.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblKode.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblKode.Location = new System.Drawing.Point(291, 531);
            this.lblKode.Name = "lblKode";
            this.lblKode.Size = new System.Drawing.Size(103, 21);
            this.lblKode.TabIndex = 24;
            this.lblKode.Text = "Kode Tiket";
            // 
            // lblIDFKTerbang
            // 
            this.lblIDFKTerbang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDFKTerbang.AutoSize = true;
            this.lblIDFKTerbang.BackColor = System.Drawing.Color.Transparent;
            this.lblIDFKTerbang.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDFKTerbang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblIDFKTerbang.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblIDFKTerbang.Location = new System.Drawing.Point(291, 465);
            this.lblIDFKTerbang.Name = "lblIDFKTerbang";
            this.lblIDFKTerbang.Size = new System.Drawing.Size(148, 21);
            this.lblIDFKTerbang.TabIndex = 23;
            this.lblIDFKTerbang.Text = "ID Penerbangan";
            // 
            // lblIDPesan
            // 
            this.lblIDPesan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDPesan.AutoSize = true;
            this.lblIDPesan.BackColor = System.Drawing.Color.Transparent;
            this.lblIDPesan.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDPesan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblIDPesan.Location = new System.Drawing.Point(290, 317);
            this.lblIDPesan.Name = "lblIDPesan";
            this.lblIDPesan.Size = new System.Drawing.Size(134, 21);
            this.lblIDPesan.TabIndex = 22;
            this.lblIDPesan.Text = "ID Pemesanan";
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblID.Location = new System.Drawing.Point(291, 240);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(77, 21);
            this.lblID.TabIndex = 21;
            this.lblID.Text = "ID Tiket";
            // 
            // btnHapus
            // 
            this.btnHapus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHapus.Location = new System.Drawing.Point(514, 104);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(161, 48);
            this.btnHapus.TabIndex = 20;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Location = new System.Drawing.Point(514, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(161, 48);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUbah.Location = new System.Drawing.Point(294, 104);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(161, 48);
            this.btnUbah.TabIndex = 18;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTambah.Location = new System.Drawing.Point(294, 26);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(161, 48);
            this.btnTambah.TabIndex = 17;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // dgvTiket
            // 
            this.dgvTiket.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvTiket.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.dgvTiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiket.Location = new System.Drawing.Point(900, 12);
            this.dgvTiket.Name = "dgvTiket";
            this.dgvTiket.RowHeadersWidth = 62;
            this.dgvTiket.RowTemplate.Height = 28;
            this.dgvTiket.Size = new System.Drawing.Size(497, 554);
            this.dgvTiket.TabIndex = 30;
            this.dgvTiket.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTiket_CellClick);
            // 
            // lblPenumpang
            // 
            this.lblPenumpang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPenumpang.AutoSize = true;
            this.lblPenumpang.BackColor = System.Drawing.Color.Transparent;
            this.lblPenumpang.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPenumpang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblPenumpang.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblPenumpang.Location = new System.Drawing.Point(291, 397);
            this.lblPenumpang.Name = "lblPenumpang";
            this.lblPenumpang.Size = new System.Drawing.Size(136, 21);
            this.lblPenumpang.TabIndex = 31;
            this.lblPenumpang.Text = "ID Penumpang";
            // 
            // cmbIDPsn
            // 
            this.cmbIDPsn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbIDPsn.FormattingEnabled = true;
            this.cmbIDPsn.Location = new System.Drawing.Point(437, 310);
            this.cmbIDPsn.Name = "cmbIDPsn";
            this.cmbIDPsn.Size = new System.Drawing.Size(387, 28);
            this.cmbIDPsn.TabIndex = 33;
            // 
            // cmbIDPnmp
            // 
            this.cmbIDPnmp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbIDPnmp.FormattingEnabled = true;
            this.cmbIDPnmp.Location = new System.Drawing.Point(437, 397);
            this.cmbIDPnmp.Name = "cmbIDPnmp";
            this.cmbIDPnmp.Size = new System.Drawing.Size(387, 28);
            this.cmbIDPnmp.TabIndex = 34;
            // 
            // cmbIDPnb
            // 
            this.cmbIDPnb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbIDPnb.FormattingEnabled = true;
            this.cmbIDPnb.Location = new System.Drawing.Point(437, 463);
            this.cmbIDPnb.Name = "cmbIDPnb";
            this.cmbIDPnb.Size = new System.Drawing.Size(387, 28);
            this.cmbIDPnb.TabIndex = 35;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImport.Location = new System.Drawing.Point(706, 26);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(161, 48);
            this.btnImport.TabIndex = 36;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(706, 103);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(161, 49);
            this.btnAnalyze.TabIndex = 37;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.lblMessage.Location = new System.Drawing.Point(910, 598);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 38;
            this.lblMessage.Text = "Message";
            // 
            // Tiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1409, 653);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cmbIDPnb);
            this.Controls.Add(this.cmbIDPnmp);
            this.Controls.Add(this.cmbIDPsn);
            this.Controls.Add(this.lblPenumpang);
            this.Controls.Add(this.dgvTiket);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblKode);
            this.Controls.Add(this.lblIDFKTerbang);
            this.Controls.Add(this.lblIDPesan);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.logoToHome);
            this.Name = "Tiket";
            this.Text = "Tiket";
            this.Load += new System.EventHandler(this.Tiket_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoToHome;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblKode;
        private System.Windows.Forms.Label lblIDFKTerbang;
        private System.Windows.Forms.Label lblIDPesan;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.DataGridView dgvTiket;
        private System.Windows.Forms.Label lblPenumpang;
        private System.Windows.Forms.ComboBox cmbIDPsn;
        private System.Windows.Forms.ComboBox cmbIDPnmp;
        private System.Windows.Forms.ComboBox cmbIDPnb;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblMessage;
    }
}