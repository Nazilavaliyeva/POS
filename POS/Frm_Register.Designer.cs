namespace POS
{
    partial class Frm_Register
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
            this.lblIstifadeciAdi = new System.Windows.Forms.Label();
            this.txtIstifadeciAdi = new System.Windows.Forms.TextBox();
            this.lblSifre = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.lblSifreTekrar = new System.Windows.Forms.Label();
            this.txtSifreTekrar = new System.Windows.Forms.TextBox();
            this.btnQeydiyyat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIstifadeciAdi
            // 
            this.lblIstifadeciAdi.AutoSize = true;
            this.lblIstifadeciAdi.Font = new System.Drawing.Font("Poor Richard", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIstifadeciAdi.ForeColor = System.Drawing.Color.White;
            this.lblIstifadeciAdi.Location = new System.Drawing.Point(12, 9);
            this.lblIstifadeciAdi.Name = "lblIstifadeciAdi";
            this.lblIstifadeciAdi.Size = new System.Drawing.Size(135, 26);
            this.lblIstifadeciAdi.TabIndex = 0;
            this.lblIstifadeciAdi.Text = "İstifadəçi Adı";
            // 
            // txtIstifadeciAdi
            // 
            this.txtIstifadeciAdi.Font = new System.Drawing.Font("Poor Richard", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIstifadeciAdi.Location = new System.Drawing.Point(17, 38);
            this.txtIstifadeciAdi.Multiline = true;
            this.txtIstifadeciAdi.Name = "txtIstifadeciAdi";
            this.txtIstifadeciAdi.Size = new System.Drawing.Size(218, 35);
            this.txtIstifadeciAdi.TabIndex = 1;
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new System.Drawing.Font("Poor Richard", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSifre.ForeColor = System.Drawing.Color.White;
            this.lblSifre.Location = new System.Drawing.Point(12, 85);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(59, 26);
            this.lblSifre.TabIndex = 2;
            this.lblSifre.Text = "Şifrə";
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Poor Richard", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifre.Location = new System.Drawing.Point(17, 114);
            this.txtSifre.Multiline = true;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(218, 35);
            this.txtSifre.TabIndex = 2;
            // 
            // lblSifreTekrar
            // 
            this.lblSifreTekrar.AutoSize = true;
            this.lblSifreTekrar.Font = new System.Drawing.Font("Poor Richard", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSifreTekrar.ForeColor = System.Drawing.Color.White;
            this.lblSifreTekrar.Location = new System.Drawing.Point(12, 161);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new System.Drawing.Size(131, 26);
            this.lblSifreTekrar.TabIndex = 4;
            this.lblSifreTekrar.Text = "Şifrə Təkrar";
            // 
            // txtSifreTekrar
            // 
            this.txtSifreTekrar.Font = new System.Drawing.Font("Poor Richard", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifreTekrar.Location = new System.Drawing.Point(17, 190);
            this.txtSifreTekrar.Multiline = true;
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.PasswordChar = '*';
            this.txtSifreTekrar.Size = new System.Drawing.Size(218, 35);
            this.txtSifreTekrar.TabIndex = 3;
            // 
            // btnQeydiyyat
            // 
            this.btnQeydiyyat.BackColor = System.Drawing.Color.Green;
            this.btnQeydiyyat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQeydiyyat.Font = new System.Drawing.Font("Poor Richard", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQeydiyyat.ForeColor = System.Drawing.Color.White;
            this.btnQeydiyyat.Location = new System.Drawing.Point(17, 240);
            this.btnQeydiyyat.Name = "btnQeydiyyat";
            this.btnQeydiyyat.Size = new System.Drawing.Size(218, 39);
            this.btnQeydiyyat.TabIndex = 4;
            this.btnQeydiyyat.Text = "Qeydiyyat";
            this.btnQeydiyyat.UseVisualStyleBackColor = false;
            this.btnQeydiyyat.Click += new System.EventHandler(this.btnQeydiyyat_Click);
            // 
            // Frm_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(252, 303);
            this.Controls.Add(this.btnQeydiyyat);
            this.Controls.Add(this.txtSifreTekrar);
            this.Controls.Add(this.lblSifreTekrar);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.txtIstifadeciAdi);
            this.Controls.Add(this.lblIstifadeciAdi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qeydiyyat";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblIstifadeciAdi;
        private System.Windows.Forms.TextBox txtIstifadeciAdi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label lblSifreTekrar;
        private System.Windows.Forms.TextBox txtSifreTekrar;
        private System.Windows.Forms.Button btnQeydiyyat;
    }
}