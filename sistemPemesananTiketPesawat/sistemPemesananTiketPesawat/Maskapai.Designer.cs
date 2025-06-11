namespace sistemPemesananTiketPesawat
{
    partial class Maskapai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maskapai));
            this.logoToHome = new System.Windows.Forms.PictureBox();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.txtNgr = new System.Windows.Forms.TextBox();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblNgr = new System.Windows.Forms.Label();
            this.lblKode = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.dgvMaskapai = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaskapai)).BeginInit();
            this.SuspendLayout();
            // 
            // logoToHome
            // 
            this.logoToHome.BackColor = System.Drawing.Color.Transparent;
            this.logoToHome.Image = ((System.Drawing.Image)(resources.GetObject("logoToHome.Image")));
            this.logoToHome.Location = new System.Drawing.Point(12, 31);
            this.logoToHome.Name = "logoToHome";
            this.logoToHome.Size = new System.Drawing.Size(188, 136);
            this.logoToHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoToHome.TabIndex = 16;
            this.logoToHome.TabStop = false;
            this.logoToHome.Click += new System.EventHandler(this.logoToHome_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHapus.Location = new System.Drawing.Point(504, 120);
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
            this.btnRefresh.Location = new System.Drawing.Point(504, 42);
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
            this.btnUbah.Location = new System.Drawing.Point(284, 120);
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
            this.btnTambah.Location = new System.Drawing.Point(284, 42);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(161, 48);
            this.btnTambah.TabIndex = 17;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // txtNgr
            // 
            this.txtNgr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNgr.Location = new System.Drawing.Point(432, 444);
            this.txtNgr.Name = "txtNgr";
            this.txtNgr.Size = new System.Drawing.Size(378, 26);
            this.txtNgr.TabIndex = 28;
            // 
            // txtKode
            // 
            this.txtKode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKode.Location = new System.Drawing.Point(432, 373);
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(378, 26);
            this.txtKode.TabIndex = 27;
            // 
            // txtNama
            // 
            this.txtNama.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNama.Location = new System.Drawing.Point(432, 297);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(378, 26);
            this.txtNama.TabIndex = 26;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(432, 220);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(378, 26);
            this.txtID.TabIndex = 25;
            // 
            // lblNgr
            // 
            this.lblNgr.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNgr.AutoSize = true;
            this.lblNgr.BackColor = System.Drawing.Color.Transparent;
            this.lblNgr.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblNgr.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblNgr.Location = new System.Drawing.Point(286, 444);
            this.lblNgr.Name = "lblNgr";
            this.lblNgr.Size = new System.Drawing.Size(114, 21);
            this.lblNgr.TabIndex = 24;
            this.lblNgr.Text = "Negara Asal";
            // 
            // lblKode
            // 
            this.lblKode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKode.AutoSize = true;
            this.lblKode.BackColor = System.Drawing.Color.Transparent;
            this.lblKode.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblKode.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblKode.Location = new System.Drawing.Point(286, 378);
            this.lblKode.Name = "lblKode";
            this.lblKode.Size = new System.Drawing.Size(140, 21);
            this.lblKode.TabIndex = 23;
            this.lblKode.Text = "Kode Maskapai";
            // 
            // lblNama
            // 
            this.lblNama.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNama.AutoSize = true;
            this.lblNama.BackColor = System.Drawing.Color.Transparent;
            this.lblNama.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblNama.Location = new System.Drawing.Point(285, 302);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(145, 21);
            this.lblNama.TabIndex = 22;
            this.lblNama.Text = "Nama Maskapai";
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblID.Location = new System.Drawing.Point(286, 225);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(114, 21);
            this.lblID.TabIndex = 21;
            this.lblID.Text = "ID Maskapai";
            // 
            // dgvMaskapai
            // 
            this.dgvMaskapai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMaskapai.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.dgvMaskapai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaskapai.Location = new System.Drawing.Point(900, 12);
            this.dgvMaskapai.Name = "dgvMaskapai";
            this.dgvMaskapai.RowHeadersWidth = 62;
            this.dgvMaskapai.RowTemplate.Height = 28;
            this.dgvMaskapai.Size = new System.Drawing.Size(497, 458);
            this.dgvMaskapai.TabIndex = 30;
            this.dgvMaskapai.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaskapai_CellClick);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImport.Location = new System.Drawing.Point(284, 510);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(161, 48);
            this.btnImport.TabIndex = 32;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnalyze.Location = new System.Drawing.Point(504, 510);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(161, 48);
            this.btnAnalyze.TabIndex = 33;
            this.btnAnalyze.Text = "Analisis";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.lblMessage.Location = new System.Drawing.Point(896, 491);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 34;
            this.lblMessage.Text = "Message";
            // 
            // Maskapai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1409, 653);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvMaskapai);
            this.Controls.Add(this.txtNgr);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblNgr);
            this.Controls.Add(this.lblKode);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.logoToHome);
            this.Name = "Maskapai";
            this.Text = "Maskapai";
            this.Load += new System.EventHandler(this.Maskapai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaskapai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoToHome;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.TextBox txtNgr;
        private System.Windows.Forms.TextBox txtKode;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblNgr;
        private System.Windows.Forms.Label lblKode;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.DataGridView dgvMaskapai;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblMessage;
    }
}