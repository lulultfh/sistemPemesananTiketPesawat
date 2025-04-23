namespace sistemPemesananTiketPesawat
{
    partial class Penerbangan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Penerbangan));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.dgvPenerbangan = new System.Windows.Forms.DataGridView();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblNoP = new System.Windows.Forms.Label();
            this.txtNoPenerbangan = new System.Windows.Forms.TextBox();
            this.lblTujuan = new System.Windows.Forms.Label();
            this.txtTujuan = new System.Windows.Forms.TextBox();
            this.lblAsal = new System.Windows.Forms.Label();
            this.txtAsal = new System.Windows.Forms.TextBox();
            this.lblBerangkat = new System.Windows.Forms.Label();
            this.txtBerangkat = new System.Windows.Forms.TextBox();
            this.lblDatang = new System.Windows.Forms.Label();
            this.txtKedatangan = new System.Windows.Forms.TextBox();
            this.lblHarga = new System.Windows.Forms.Label();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.lblIDFK = new System.Windows.Forms.Label();
            this.txtIDFK = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenerbangan)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnTambah
            // 
            this.btnTambah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTambah.Location = new System.Drawing.Point(291, 38);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(161, 48);
            this.btnTambah.TabIndex = 3;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUbah.Location = new System.Drawing.Point(291, 111);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(161, 48);
            this.btnUbah.TabIndex = 4;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Location = new System.Drawing.Point(506, 38);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(161, 48);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHapus.Location = new System.Drawing.Point(506, 111);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(161, 48);
            this.btnHapus.TabIndex = 6;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // dgvPenerbangan
            // 
            this.dgvPenerbangan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPenerbangan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.dgvPenerbangan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPenerbangan.Location = new System.Drawing.Point(900, 12);
            this.dgvPenerbangan.Name = "dgvPenerbangan";
            this.dgvPenerbangan.RowHeadersWidth = 62;
            this.dgvPenerbangan.RowTemplate.Height = 28;
            this.dgvPenerbangan.Size = new System.Drawing.Size(497, 629);
            this.dgvPenerbangan.TabIndex = 7;
            this.dgvPenerbangan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPenerbangan_CellClick);
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblID.Location = new System.Drawing.Point(260, 180);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(148, 21);
            this.lblID.TabIndex = 8;
            this.lblID.Text = "ID Penerbangan";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(451, 175);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(378, 26);
            this.txtID.TabIndex = 11;
            // 
            // lblNoP
            // 
            this.lblNoP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoP.AutoSize = true;
            this.lblNoP.BackColor = System.Drawing.Color.Transparent;
            this.lblNoP.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblNoP.Location = new System.Drawing.Point(260, 229);
            this.lblNoP.Name = "lblNoP";
            this.lblNoP.Size = new System.Drawing.Size(154, 21);
            this.lblNoP.TabIndex = 12;
            this.lblNoP.Text = "No Penerbangan";
            this.lblNoP.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtNoPenerbangan
            // 
            this.txtNoPenerbangan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNoPenerbangan.Location = new System.Drawing.Point(451, 224);
            this.txtNoPenerbangan.Name = "txtNoPenerbangan";
            this.txtNoPenerbangan.Size = new System.Drawing.Size(378, 26);
            this.txtNoPenerbangan.TabIndex = 13;
            // 
            // lblTujuan
            // 
            this.lblTujuan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTujuan.AutoSize = true;
            this.lblTujuan.BackColor = System.Drawing.Color.Transparent;
            this.lblTujuan.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTujuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblTujuan.Location = new System.Drawing.Point(260, 282);
            this.lblTujuan.Name = "lblTujuan";
            this.lblTujuan.Size = new System.Drawing.Size(69, 21);
            this.lblTujuan.TabIndex = 14;
            this.lblTujuan.Text = "Tujuan";
            // 
            // txtTujuan
            // 
            this.txtTujuan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTujuan.Location = new System.Drawing.Point(451, 277);
            this.txtTujuan.Name = "txtTujuan";
            this.txtTujuan.Size = new System.Drawing.Size(378, 26);
            this.txtTujuan.TabIndex = 15;
            // 
            // lblAsal
            // 
            this.lblAsal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAsal.AutoSize = true;
            this.lblAsal.BackColor = System.Drawing.Color.Transparent;
            this.lblAsal.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblAsal.Location = new System.Drawing.Point(260, 337);
            this.lblAsal.Name = "lblAsal";
            this.lblAsal.Size = new System.Drawing.Size(48, 21);
            this.lblAsal.TabIndex = 16;
            this.lblAsal.Text = "Asal";
            // 
            // txtAsal
            // 
            this.txtAsal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAsal.Location = new System.Drawing.Point(451, 332);
            this.txtAsal.Name = "txtAsal";
            this.txtAsal.Size = new System.Drawing.Size(378, 26);
            this.txtAsal.TabIndex = 17;
            // 
            // lblBerangkat
            // 
            this.lblBerangkat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBerangkat.AutoSize = true;
            this.lblBerangkat.BackColor = System.Drawing.Color.Transparent;
            this.lblBerangkat.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBerangkat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblBerangkat.Location = new System.Drawing.Point(260, 394);
            this.lblBerangkat.Name = "lblBerangkat";
            this.lblBerangkat.Size = new System.Drawing.Size(158, 21);
            this.lblBerangkat.TabIndex = 18;
            this.lblBerangkat.Text = "Waktu Berangkat";
            // 
            // txtBerangkat
            // 
            this.txtBerangkat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBerangkat.Location = new System.Drawing.Point(451, 389);
            this.txtBerangkat.Name = "txtBerangkat";
            this.txtBerangkat.Size = new System.Drawing.Size(378, 26);
            this.txtBerangkat.TabIndex = 19;
            // 
            // lblDatang
            // 
            this.lblDatang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDatang.AutoSize = true;
            this.lblDatang.BackColor = System.Drawing.Color.Transparent;
            this.lblDatang.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblDatang.Location = new System.Drawing.Point(260, 447);
            this.lblDatang.Name = "lblDatang";
            this.lblDatang.Size = new System.Drawing.Size(172, 21);
            this.lblDatang.TabIndex = 20;
            this.lblDatang.Text = "Waktu Kedatangan";
            // 
            // txtKedatangan
            // 
            this.txtKedatangan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKedatangan.Location = new System.Drawing.Point(451, 444);
            this.txtKedatangan.Name = "txtKedatangan";
            this.txtKedatangan.Size = new System.Drawing.Size(378, 26);
            this.txtKedatangan.TabIndex = 21;
            // 
            // lblHarga
            // 
            this.lblHarga.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHarga.AutoSize = true;
            this.lblHarga.BackColor = System.Drawing.Color.Transparent;
            this.lblHarga.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHarga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblHarga.Location = new System.Drawing.Point(260, 500);
            this.lblHarga.Name = "lblHarga";
            this.lblHarga.Size = new System.Drawing.Size(61, 21);
            this.lblHarga.TabIndex = 22;
            this.lblHarga.Text = "Harga";
            // 
            // txtHarga
            // 
            this.txtHarga.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtHarga.Location = new System.Drawing.Point(451, 498);
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.Size = new System.Drawing.Size(378, 26);
            this.txtHarga.TabIndex = 23;
            // 
            // lblIDFK
            // 
            this.lblIDFK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDFK.AutoSize = true;
            this.lblIDFK.BackColor = System.Drawing.Color.Transparent;
            this.lblIDFK.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDFK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblIDFK.Location = new System.Drawing.Point(260, 554);
            this.lblIDFK.Name = "lblIDFK";
            this.lblIDFK.Size = new System.Drawing.Size(114, 21);
            this.lblIDFK.TabIndex = 24;
            this.lblIDFK.Text = "ID Maskapai";
            // 
            // txtIDFK
            // 
            this.txtIDFK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDFK.Location = new System.Drawing.Point(451, 552);
            this.txtIDFK.Name = "txtIDFK";
            this.txtIDFK.Size = new System.Drawing.Size(378, 26);
            this.txtIDFK.TabIndex = 25;
            // 
            // Penerbangan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1409, 653);
            this.Controls.Add(this.txtIDFK);
            this.Controls.Add(this.lblIDFK);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.lblHarga);
            this.Controls.Add(this.txtKedatangan);
            this.Controls.Add(this.lblDatang);
            this.Controls.Add(this.txtBerangkat);
            this.Controls.Add(this.lblBerangkat);
            this.Controls.Add(this.txtAsal);
            this.Controls.Add(this.lblAsal);
            this.Controls.Add(this.txtTujuan);
            this.Controls.Add(this.lblTujuan);
            this.Controls.Add(this.txtNoPenerbangan);
            this.Controls.Add(this.lblNoP);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.dgvPenerbangan);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Penerbangan";
            this.Text = "penebangan";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenerbangan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.DataGridView dgvPenerbangan;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblNoP;
        private System.Windows.Forms.TextBox txtNoPenerbangan;
        private System.Windows.Forms.Label lblTujuan;
        private System.Windows.Forms.TextBox txtTujuan;
        private System.Windows.Forms.Label lblAsal;
        private System.Windows.Forms.TextBox txtAsal;
        private System.Windows.Forms.Label lblBerangkat;
        private System.Windows.Forms.TextBox txtBerangkat;
        private System.Windows.Forms.Label lblDatang;
        private System.Windows.Forms.TextBox txtKedatangan;
        private System.Windows.Forms.Label lblHarga;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.Label lblIDFK;
        private System.Windows.Forms.TextBox txtIDFK;
    }
}