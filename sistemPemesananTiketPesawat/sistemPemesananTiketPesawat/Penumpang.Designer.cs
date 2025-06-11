namespace sistemPemesananTiketPesawat
{
    partial class Penumpang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Penumpang));
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblJK = new System.Windows.Forms.Label();
            this.lblIDFKTerbang = new System.Windows.Forms.Label();
            this.lblNama = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUbah = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.txtKwn = new System.Windows.Forms.TextBox();
            this.lblKwn = new System.Windows.Forms.Label();
            this.dgvPenumpang = new System.Windows.Forms.DataGridView();
            this.logoToHome = new System.Windows.Forms.PictureBox();
            this.cmbJK = new MetroFramework.Controls.MetroComboBox();
            this.dtTgl = new System.Windows.Forms.DateTimePicker();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenumpang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNama
            // 
            this.txtNama.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNama.Location = new System.Drawing.Point(449, 274);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(378, 26);
            this.txtNama.TabIndex = 38;
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtID.Location = new System.Drawing.Point(449, 224);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(378, 26);
            this.txtID.TabIndex = 37;
            // 
            // lblJK
            // 
            this.lblJK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblJK.AutoSize = true;
            this.lblJK.BackColor = System.Drawing.Color.Transparent;
            this.lblJK.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblJK.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblJK.Location = new System.Drawing.Point(273, 381);
            this.lblJK.Name = "lblJK";
            this.lblJK.Size = new System.Drawing.Size(130, 21);
            this.lblJK.TabIndex = 36;
            this.lblJK.Text = "Jenis Kelamin";
            this.lblJK.Click += new System.EventHandler(this.lblKode_Click);
            // 
            // lblIDFKTerbang
            // 
            this.lblIDFKTerbang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIDFKTerbang.AutoSize = true;
            this.lblIDFKTerbang.BackColor = System.Drawing.Color.Transparent;
            this.lblIDFKTerbang.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDFKTerbang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblIDFKTerbang.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblIDFKTerbang.Location = new System.Drawing.Point(273, 333);
            this.lblIDFKTerbang.Name = "lblIDFKTerbang";
            this.lblIDFKTerbang.Size = new System.Drawing.Size(126, 21);
            this.lblIDFKTerbang.TabIndex = 35;
            this.lblIDFKTerbang.Text = "Tanggal Lahir";
            // 
            // lblNama
            // 
            this.lblNama.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNama.AutoSize = true;
            this.lblNama.BackColor = System.Drawing.Color.Transparent;
            this.lblNama.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblNama.Location = new System.Drawing.Point(272, 279);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(133, 21);
            this.lblNama.TabIndex = 34;
            this.lblNama.Text = "NamaLengkap";
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblID.Location = new System.Drawing.Point(273, 229);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(136, 21);
            this.lblID.TabIndex = 33;
            this.lblID.Text = "ID Penumpang";
            // 
            // btnHapus
            // 
            this.btnHapus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHapus.Location = new System.Drawing.Point(528, 138);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(161, 48);
            this.btnHapus.TabIndex = 32;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Location = new System.Drawing.Point(528, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(161, 48);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUbah
            // 
            this.btnUbah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUbah.Location = new System.Drawing.Point(308, 138);
            this.btnUbah.Name = "btnUbah";
            this.btnUbah.Size = new System.Drawing.Size(161, 48);
            this.btnUbah.TabIndex = 30;
            this.btnUbah.Text = "Ubah";
            this.btnUbah.UseVisualStyleBackColor = true;
            this.btnUbah.Click += new System.EventHandler(this.btnUbah_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTambah.Location = new System.Drawing.Point(308, 60);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(161, 48);
            this.btnTambah.TabIndex = 29;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // txtKwn
            // 
            this.txtKwn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtKwn.Location = new System.Drawing.Point(449, 429);
            this.txtKwn.Name = "txtKwn";
            this.txtKwn.Size = new System.Drawing.Size(378, 26);
            this.txtKwn.TabIndex = 41;
            this.txtKwn.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblKwn
            // 
            this.lblKwn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKwn.AutoSize = true;
            this.lblKwn.BackColor = System.Drawing.Color.Transparent;
            this.lblKwn.Font = new System.Drawing.Font("Inter SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKwn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblKwn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblKwn.Location = new System.Drawing.Point(274, 429);
            this.lblKwn.Name = "lblKwn";
            this.lblKwn.Size = new System.Drawing.Size(166, 21);
            this.lblKwn.TabIndex = 42;
            this.lblKwn.Text = "Kewarganegaraan";
            // 
            // dgvPenumpang
            // 
            this.dgvPenumpang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPenumpang.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.dgvPenumpang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPenumpang.Location = new System.Drawing.Point(900, 12);
            this.dgvPenumpang.Name = "dgvPenumpang";
            this.dgvPenumpang.RowHeadersWidth = 62;
            this.dgvPenumpang.RowTemplate.Height = 28;
            this.dgvPenumpang.Size = new System.Drawing.Size(497, 568);
            this.dgvPenumpang.TabIndex = 43;
            this.dgvPenumpang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPenumpang_CellClick);
            // 
            // logoToHome
            // 
            this.logoToHome.BackColor = System.Drawing.Color.Transparent;
            this.logoToHome.Image = ((System.Drawing.Image)(resources.GetObject("logoToHome.Image")));
            this.logoToHome.Location = new System.Drawing.Point(12, 50);
            this.logoToHome.Name = "logoToHome";
            this.logoToHome.Size = new System.Drawing.Size(188, 136);
            this.logoToHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoToHome.TabIndex = 44;
            this.logoToHome.TabStop = false;
            this.logoToHome.Click += new System.EventHandler(this.logoToHome_Click);
            // 
            // cmbJK
            // 
            this.cmbJK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbJK.FormattingEnabled = true;
            this.cmbJK.ItemHeight = 23;
            this.cmbJK.Location = new System.Drawing.Point(449, 373);
            this.cmbJK.Name = "cmbJK";
            this.cmbJK.Size = new System.Drawing.Size(378, 29);
            this.cmbJK.TabIndex = 45;
            this.cmbJK.UseSelectable = true;
            // 
            // dtTgl
            // 
            this.dtTgl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtTgl.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTgl.Location = new System.Drawing.Point(449, 328);
            this.dtTgl.Name = "dtTgl";
            this.dtTgl.Size = new System.Drawing.Size(378, 26);
            this.dtTgl.TabIndex = 46;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImport.Location = new System.Drawing.Point(308, 513);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(161, 48);
            this.btnImport.TabIndex = 48;
            this.btnImport.Text = "Import Data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnalyze.Location = new System.Drawing.Point(528, 513);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(161, 48);
            this.btnAnalyze.TabIndex = 49;
            this.btnAnalyze.Text = "Analisis";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(222)))));
            this.lblMessage.Location = new System.Drawing.Point(905, 609);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 50;
            this.lblMessage.Text = "Message";
            // 
            // Penumpang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1409, 653);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dtTgl);
            this.Controls.Add(this.cmbJK);
            this.Controls.Add(this.logoToHome);
            this.Controls.Add(this.dgvPenumpang);
            this.Controls.Add(this.lblKwn);
            this.Controls.Add(this.txtKwn);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblJK);
            this.Controls.Add(this.lblIDFKTerbang);
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUbah);
            this.Controls.Add(this.btnTambah);
            this.Name = "Penumpang";
            this.Text = "Penumpang";
            this.Load += new System.EventHandler(this.Penumpang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenumpang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoToHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblJK;
        private System.Windows.Forms.Label lblIDFKTerbang;
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUbah;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.TextBox txtKwn;
        private System.Windows.Forms.Label lblKwn;
        private System.Windows.Forms.DataGridView dgvPenumpang;
        private System.Windows.Forms.PictureBox logoToHome;
        private MetroFramework.Controls.MetroComboBox cmbJK;
        private System.Windows.Forms.DateTimePicker dtTgl;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblMessage;
    }
}