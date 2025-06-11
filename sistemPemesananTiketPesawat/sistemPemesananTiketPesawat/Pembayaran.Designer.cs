namespace sistemPemesananTiketPesawat
{
    partial class Pembayaran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pembayaran));
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblIDFk = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblJumlah = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.dgvPembayaran = new System.Windows.Forms.DataGridView();
            this.logoToHome = new System.Windows.Forms.PictureBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbIDFK = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnAnalisis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtBayar = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).BeginInit();
            this.SuspendLayout();
            // 
            // txtJumlah
            // 
            this.txtJumlah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtJumlah.Location = new System.Drawing.Point(475, 310);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.Size = new System.Drawing.Size(378, 26);
            this.txtJumlah.TabIndex = 50;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(475, 260);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(378, 26);
            this.txtID.TabIndex = 49;
            // 
            // lblIDFk
            // 
            this.lblIDFk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDFk.AutoSize = true;
            this.lblIDFk.BackColor = System.Drawing.Color.Transparent;
            this.lblIDFk.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDFk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblIDFk.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblIDFk.Location = new System.Drawing.Point(299, 455);
            this.lblIDFk.Name = "lblIDFk";
            this.lblIDFk.Size = new System.Drawing.Size(134, 21);
            this.lblIDFk.TabIndex = 48;
            this.lblIDFk.Text = "ID Pemesanan";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblStatus.Location = new System.Drawing.Point(299, 369);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(179, 21);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "Status Pembayaran";
            // 
            // lblJumlah
            // 
            this.lblJumlah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblJumlah.AutoSize = true;
            this.lblJumlah.BackColor = System.Drawing.Color.Transparent;
            this.lblJumlah.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJumlah.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblJumlah.Location = new System.Drawing.Point(298, 315);
            this.lblJumlah.Name = "lblJumlah";
            this.lblJumlah.Size = new System.Drawing.Size(126, 21);
            this.lblJumlah.TabIndex = 46;
            this.lblJumlah.Text = "Jumlah Bayar";
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblID.Location = new System.Drawing.Point(299, 265);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(140, 21);
            this.lblID.TabIndex = 45;
            this.lblID.Text = "ID Pembayaran";
            // 
            // btnHapus
            // 
            this.btnHapus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHapus.Location = new System.Drawing.Point(554, 174);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(161, 48);
            this.btnHapus.TabIndex = 44;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Location = new System.Drawing.Point(554, 96);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(161, 48);
            this.btnRefresh.TabIndex = 43;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUbah.Location = new System.Drawing.Point(334, 174);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(161, 48);
            this.btnUbah.TabIndex = 42;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTambah.Location = new System.Drawing.Point(334, 96);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(161, 48);
            this.btnTambah.TabIndex = 41;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // dgvPembayaran
            // 
            this.dgvPembayaran.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPembayaran.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.dgvPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembayaran.Location = new System.Drawing.Point(900, 12);
            this.dgvPembayaran.Name = "dgvPembayaran";
            this.dgvPembayaran.RowHeadersWidth = 62;
            this.dgvPembayaran.RowTemplate.Height = 28;
            this.dgvPembayaran.Size = new System.Drawing.Size(497, 435);
            this.dgvPembayaran.TabIndex = 53;
            this.dgvPembayaran.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPembayaran_CellClick);
            // 
            // logoToHome
            // 
            this.logoToHome.BackColor = System.Drawing.Color.Transparent;
            this.logoToHome.Image = ((System.Drawing.Image)(resources.GetObject("logoToHome.Image")));
            this.logoToHome.Location = new System.Drawing.Point(12, 27);
            this.logoToHome.Name = "logoToHome";
            this.logoToHome.Size = new System.Drawing.Size(188, 136);
            this.logoToHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoToHome.TabIndex = 55;
            this.logoToHome.TabStop = false;
            this.logoToHome.Click += new System.EventHandler(this.logoToHome_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(475, 362);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(378, 28);
            this.cmbStatus.TabIndex = 56;
            // 
            // cmbIDFK
            // 
            this.cmbIDFK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbIDFK.FormattingEnabled = true;
            this.cmbIDFK.Location = new System.Drawing.Point(475, 448);
            this.cmbIDFK.Name = "cmbIDFK";
            this.cmbIDFK.Size = new System.Drawing.Size(378, 28);
            this.cmbIDFK.TabIndex = 57;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImport.Location = new System.Drawing.Point(334, 504);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(161, 48);
            this.btnImport.TabIndex = 59;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAnalisis
            // 
            this.btnAnalisis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnalisis.Location = new System.Drawing.Point(554, 504);
            this.btnAnalisis.Name = "btnAnalisis";
            this.btnAnalisis.Size = new System.Drawing.Size(161, 48);
            this.btnAnalisis.TabIndex = 60;
            this.btnAnalisis.Text = "Analisis";
            this.btnAnalisis.UseVisualStyleBackColor = true;
            this.btnAnalisis.Click += new System.EventHandler(this.btnAnalisis_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Location = new System.Drawing.Point(299, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 61;
            this.label1.Text = "Tanggal Bayar";
            // 
            // dtBayar
            // 
            this.dtBayar.AllowDrop = true;
            this.dtBayar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtBayar.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBayar.Location = new System.Drawing.Point(475, 407);
            this.dtBayar.Name = "dtBayar";
            this.dtBayar.Size = new System.Drawing.Size(378, 26);
            this.dtBayar.TabIndex = 62;
            // 
            // Pembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1409, 653);
            this.Controls.Add(this.dtBayar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAnalisis);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cmbIDFK);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.logoToHome);
            this.Controls.Add(this.dgvPembayaran);
            this.Controls.Add(this.txtJumlah);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblIDFk);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblJumlah);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnTambah);
            this.Name = "Pembayaran";
            this.Text = "Pembayaran";
            this.Load += new System.EventHandler(this.Pembayaran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtJumlah;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblIDFk;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblJumlah;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.DataGridView dgvPembayaran;
        private System.Windows.Forms.PictureBox logoToHome;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbIDFK;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAnalisis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtBayar;
    }
}