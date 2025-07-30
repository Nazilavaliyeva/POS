namespace POS
{
    partial class Frm_login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblad
            // 
            this.lblad.AutoSize = true;
            this.lblad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblad.Location = new System.Drawing.Point(28, 79);
            this.lblad.Name = "lblad";
            this.lblad.Size = new System.Drawing.Size(111, 23);
            this.lblad.TabIndex = 0;
            this.lblad.Text = "İstifadəçi Adı";
            // 
            // lblsifre
            // 
            this.lblsifre.AutoSize = true;
            this.lblsifre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblsifre.Location = new System.Drawing.Point(28, 155);
            this.lblsifre.Name = "lblsifre";
            this.lblsifre.Size = new System.Drawing.Size(45, 23);
            this.lblsifre.TabIndex = 2;
            this.lblsifre.Text = "Şifrə";
            // 
            // txtAd
            // 
            this.txtAd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAd.ForeColor = System.Drawing.Color.Black;
            this.txtAd.Location = new System.Drawing.Point(32, 105);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(260, 34);
            this.txtAd.TabIndex = 1;
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifre.ForeColor = System.Drawing.Color.Black;
            this.txtSifre.Location = new System.Drawing.Point(32, 181);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '●';
            this.txtSifre.Size = new System.Drawing.Size(260, 34);
            this.txtSifre.TabIndex = 2;
            // 
            // btngiris
            // 
            this.btngiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btngiris.FlatAppearance.BorderSize = 0;
            this.btngiris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngiris.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngiris.ForeColor = System.Drawing.Color.White;
            this.btngiris.Location = new System.Drawing.Point(32, 238);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(260, 45);
            this.btngiris.TabIndex = 3;
            this.btngiris.Text = "Giriş";
            this.btngiris.UseVisualStyleBackColor = false;
            this.btngiris.Click += new System.EventHandler(this.btngiris_Click);
            // 
            // btncixis
            // 
            this.btncixis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btncixis.FlatAppearance.BorderSize = 0;
            this.btncixis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncixis.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncixis.ForeColor = System.Drawing.Color.White;
            this.btncixis.Location = new System.Drawing.Point(32, 289);
            this.btncixis.Name = "btncixis";
            this.btncixis.Size = new System.Drawing.Size(260, 45);
            this.btncixis.TabIndex = 4;
            this.btncixis.Text = "Çıxış";
            this.btncixis.UseVisualStyleBackColor = false;
            this.btncixis.Click += new System.EventHandler(this.btncixis_Click);
            // 
            // btnQeydiyyatOl
            // 
            this.btnQeydiyyatOl.BackColor = System.Drawing.Color.Transparent;
            this.btnQeydiyyatOl.FlatAppearance.BorderSize = 0;
            this.btnQeydiyyatOl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQeydiyyatOl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQeydiyyatOl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnQeydiyyatOl.Location = new System.Drawing.Point(90, 350);
            this.btnQeydiyyatOl.Name = "btnQeydiyyatOl";
            this.btnQeydiyyatOl.Size = new System.Drawing.Size(145, 39);
            this.btnQeydiyyatOl.TabIndex = 5;
            this.btnQeydiyyatOl.Text = "Hesabınız yoxdur?";
            this.btnQeydiyyatOl.UseVisualStyleBackColor = false;
            this.btnQeydiyyatOl.Click += new System.EventHandler(this.btnQeydiyyatOl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(54, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sistemə Daxil Ol";
            // 
            // Frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(322, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQeydiyyatOl);
            this.Controls.Add(this.btncixis);
            this.Controls.Add(this.btngiris);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.lblsifre);
            this.Controls.Add(this.lblad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
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
        private System.Windows.Forms.Label label1;
    }
}