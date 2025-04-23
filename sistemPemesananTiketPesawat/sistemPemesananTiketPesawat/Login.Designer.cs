namespace sistemPemesananTiketPesawat
{
    partial class FromLogin
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
            this.txtUname = new System.Windows.Forms.TextBox();
            this.lblUname = new System.Windows.Forms.Label();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.lblPasswd = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUname
            // 
            this.txtUname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtUname.Location = new System.Drawing.Point(807, 190);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(492, 26);
            this.txtUname.TabIndex = 0;
            this.txtUname.TextChanged += new System.EventHandler(this.txtUname_TextChanged);
            // 
            // lblUname
            // 
            this.lblUname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUname.AutoSize = true;
            this.lblUname.BackColor = System.Drawing.Color.Transparent;
            this.lblUname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUname.Font = new System.Drawing.Font("Inter Medium", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblUname.Location = new System.Drawing.Point(950, 147);
            this.lblUname.Name = "lblUname";
            this.lblUname.Size = new System.Drawing.Size(210, 26);
            this.lblUname.TabIndex = 1;
            this.lblUname.Text = "Username / Email";
            this.lblUname.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtPasswd
            // 
            this.txtPasswd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPasswd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtPasswd.Location = new System.Drawing.Point(807, 329);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Size = new System.Drawing.Size(492, 26);
            this.txtPasswd.TabIndex = 2;
            // 
            // lblPasswd
            // 
            this.lblPasswd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPasswd.AutoSize = true;
            this.lblPasswd.BackColor = System.Drawing.Color.Transparent;
            this.lblPasswd.Font = new System.Drawing.Font("Inter Medium", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.lblPasswd.Location = new System.Drawing.Point(996, 291);
            this.lblPasswd.Name = "lblPasswd";
            this.lblPasswd.Size = new System.Drawing.Size(124, 26);
            this.lblPasswd.TabIndex = 3;
            this.lblPasswd.Text = "Password";
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnLogin.Font = new System.Drawing.Font("Inter Medium", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(51)))), ((int)(((byte)(107)))));
            this.btnLogin.Location = new System.Drawing.Point(998, 431);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(144, 42);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FromLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::sistemPemesananTiketPesawat.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(1409, 653);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblPasswd);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.lblUname);
            this.Controls.Add(this.txtUname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FromLogin";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FromLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.Label lblUname;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.Label lblPasswd;
        private System.Windows.Forms.Button btnLogin;
    }
}

