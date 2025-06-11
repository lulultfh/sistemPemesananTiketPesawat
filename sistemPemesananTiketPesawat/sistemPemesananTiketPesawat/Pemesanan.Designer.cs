namespace sistemPemesananTiketPesawat
{
    partial class Pemesanan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pemesanan));
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblIDFK = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblWaktu = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.logoToHome = new System.Windows.Forms.PictureBox();
            this.dgvPemesanan = new System.Windows.Forms.DataGridView();
            this.cmbIDPel = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.waktu = new System.Windows.Forms.DateTimePicker();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemesanan)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(427, 253);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(378, 26);
            this.txtID.TabIndex = 23;
            // 
            // lblIDFK
            // 
            this.lblIDFK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDFK.AutoSize = true;
            this.lblIDFK.BackColor = System.Drawing.Color.Transparent;
            this.lblIDFK.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDFK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblIDFK.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblIDFK.Location = new System.Drawing.Point(281, 477);
            this.lblIDFK.Name = "lblIDFK";
            this.lblIDFK.Size = new System.Drawing.Size(124, 21);
            this.lblIDFK.TabIndex = 22;
            this.lblIDFK.Text = "ID Pelanggan";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblStatus.Location = new System.Drawing.Point(281, 411);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 21);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Status Pesan";
            // 
            // lblWaktu
            // 
            this.lblWaktu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblWaktu.AutoSize = true;
            this.lblWaktu.BackColor = System.Drawing.Color.Transparent;
            this.lblWaktu.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaktu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblWaktu.Location = new System.Drawing.Point(280, 335);
            this.lblWaktu.Name = "lblWaktu";
            this.lblWaktu.Size = new System.Drawing.Size(123, 21);
            this.lblWaktu.TabIndex = 20;
            this.lblWaktu.Text = "Waktu Pesan";
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblID.Location = new System.Drawing.Point(281, 258);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(134, 21);
            this.lblID.TabIndex = 19;
            this.lblID.Text = "ID Pemesanan";
            // 
            // btnHapus
            // 
            this.btnHapus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHapus.Location = new System.Drawing.Point(504, 122);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(161, 48);
            this.btnHapus.TabIndex = 18;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Location = new System.Drawing.Point(504, 44);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(161, 48);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUbah.Location = new System.Drawing.Point(284, 122);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(161, 48);
            this.btnUbah.TabIndex = 16;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTambah.Location = new System.Drawing.Point(284, 44);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(161, 48);
            this.btnTambah.TabIndex = 15;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // logoToHome
            // 
            this.logoToHome.BackColor = System.Drawing.Color.Transparent;
            this.logoToHome.Image = ((System.Drawing.Image)(resources.GetObject("logoToHome.Image")));
            this.logoToHome.Location = new System.Drawing.Point(12, 23);
            this.logoToHome.Name = "logoToHome";
            this.logoToHome.Size = new System.Drawing.Size(188, 136);
            this.logoToHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoToHome.TabIndex = 29;
            this.logoToHome.TabStop = false;
            this.logoToHome.Click += new System.EventHandler(this.logoToHome_Click);
            // 
            // dgvPemesanan
            // 
            this.dgvPemesanan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPemesanan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.dgvPemesanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPemesanan.Location = new System.Drawing.Point(900, 12);
            this.dgvPemesanan.Name = "dgvPemesanan";
            this.dgvPemesanan.RowHeadersWidth = 62;
            this.dgvPemesanan.RowTemplate.Height = 28;
            this.dgvPemesanan.Size = new System.Drawing.Size(497, 527);
            this.dgvPemesanan.TabIndex = 28;
            this.dgvPemesanan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPemesanan_CellClick);
            // 
            // cmbIDPel
            // 
            this.cmbIDPel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbIDPel.FormattingEnabled = true;
            this.cmbIDPel.Location = new System.Drawing.Point(427, 477);
            this.cmbIDPel.Name = "cmbIDPel";
            this.cmbIDPel.Size = new System.Drawing.Size(378, 28);
            this.cmbIDPel.TabIndex = 30;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(427, 411);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(378, 28);
            this.cmbStatus.TabIndex = 31;
            // 
            // waktu
            // 
            this.waktu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.waktu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.waktu.Location = new System.Drawing.Point(427, 331);
            this.waktu.Name = "waktu";
            this.waktu.Size = new System.Drawing.Size(378, 26);
            this.waktu.TabIndex = 32;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.lblMessage.Location = new System.Drawing.Point(904, 575);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 33;
            this.lblMessage.Text = "Message";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImport.Location = new System.Drawing.Point(284, 536);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(161, 48);
            this.btnImport.TabIndex = 34;
            this.btnImport.Text = "Import Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnalyze.Location = new System.Drawing.Point(504, 536);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(161, 48);
            this.btnAnalyze.TabIndex = 35;
            this.btnAnalyze.Text = "Analisis";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // Pemesanan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1409, 653);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.waktu);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cmbIDPel);
            this.Controls.Add(this.logoToHome);
            this.Controls.Add(this.dgvPemesanan);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblIDFK);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblWaktu);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnTambah);
            this.Name = "Pemesanan";
            this.Text = "Pemesanan";
            this.Load += new System.EventHandler(this.Pemesanan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPemesanan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblIDFK;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblWaktu;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.PictureBox logoToHome;
        private System.Windows.Forms.DataGridView dgvPemesanan;
        private System.Windows.Forms.ComboBox cmbIDPel;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker waktu;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAnalyze;
    }
}