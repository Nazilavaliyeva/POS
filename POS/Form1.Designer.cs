namespace POS
{
    partial class Frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_login));
            this.lblad = new System.Windows.Forms.Label();
            this.lblsifre = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.btngiris = new System.Windows.Forms.Button();
            this.btncixis = new System.Windows.Forms.Button();
            this.btnQeydiyyatOl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblad
            // 
            this.lblad.AutoSize = true;
            this.lblad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblad.Font = new System.Drawing.Font("Poor Richard", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblad.ForeColor = System.Drawing.Color.White;
            this.lblad.Location = new System.Drawing.Point(12, 23);
            this.lblad.Name = "lblad";
            this.lblad.Size = new System.Drawing.Size(141, 26);
            this.lblad.TabIndex = 0;
            this.lblad.Text = "İstifadəçi Adı";
            // 
            // lblsifre
            // 
            this.lblsifre.AutoSize = true;
            this.lblsifre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblsifre.Font = new System.Drawing.Font("Poor Richard", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsifre.ForeColor = System.Drawing.Color.White;
            this.lblsifre.Location = new System.Drawing.Point(12, 102);
            this.lblsifre.Name = "lblsifre";
            this.lblsifre.Size = new System.Drawing.Size(59, 26);
            this.lblsifre.TabIndex = 2;
            this.lblsifre.Text = "Şifrə";
            // 
            // txtAd
            // 
            this.txtAd.Font = new System.Drawing.Font("Poor Richard", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAd.ForeColor = System.Drawing.Color.Black;
            this.txtAd.Location = new System.Drawing.Point(17, 52);
            this.txtAd.Multiline = true;
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(218, 35);
            this.txtAd.TabIndex = 1;
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Poor Richard", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifre.ForeColor = System.Drawing.Color.Black;
            this.txtSifre.Location = new System.Drawing.Point(17, 131);
            this.txtSifre.Multiline = true;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(218, 35);
            this.txtSifre.TabIndex = 2;
            // 
            // btngiris
            // 
            this.btngiris.BackColor = System.Drawing.Color.Green;
            this.btngiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngiris.Font = new System.Drawing.Font("Poor Richard", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngiris.ForeColor = System.Drawing.Color.White;
            this.btngiris.Location = new System.Drawing.Point(17, 188);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(218, 39);
            this.btngiris.TabIndex = 3;
            this.btngiris.Text = "Giriş";
            this.btngiris.UseVisualStyleBackColor = false;
            this.btngiris.Click += new System.EventHandler(this.btngiris_Click);
            // 
            // btncixis
            // 
            this.btncixis.BackColor = System.Drawing.Color.Red;
            this.btncixis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncixis.Font = new System.Drawing.Font("Poor Richard", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncixis.ForeColor = System.Drawing.Color.White;
            this.btncixis.Location = new System.Drawing.Point(17, 233);
            this.btncixis.Name = "btncixis";
            this.btncixis.Size = new System.Drawing.Size(218, 39);
            this.btncixis.TabIndex = 4;
            this.btncixis.Text = "Çıxış";
            this.btncixis.UseVisualStyleBackColor = false;
            this.btncixis.Click += new System.EventHandler(this.btncixis_Click);
            // 
            // btnQeydiyyatOl
            // 
            this.btnQeydiyyatOl.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnQeydiyyatOl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQeydiyyatOl.Font = new System.Drawing.Font("Poor Richard", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQeydiyyatOl.ForeColor = System.Drawing.Color.White;
            this.btnQeydiyyatOl.Location = new System.Drawing.Point(17, 291);
            this.btnQeydiyyatOl.Name = "btnQeydiyyatOl";
            this.btnQeydiyyatOl.Size = new System.Drawing.Size(218, 39);
            this.btnQeydiyyatOl.TabIndex = 5;
            this.btnQeydiyyatOl.Text = "Qeydiyyat Ol";
            this.btnQeydiyyatOl.UseVisualStyleBackColor = false;
            this.btnQeydiyyatOl.Click += new System.EventHandler(this.btnQeydiyyatOl_Click);
            // 
            // Frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(252, 353);
            this.Controls.Add(this.btnQeydiyyatOl);
            this.Controls.Add(this.btncixis);
            this.Controls.Add(this.btngiris);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.lblsifre);
            this.Controls.Add(this.lblad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Frm_login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblad;
        private System.Windows.Forms.Label lblsifre;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Button btngiris;
        private System.Windows.Forms.Button btncixis;
        private System.Windows.Forms.Button btnQeydiyyatOl;
    }
}