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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblIstifadeciAdi
            // 
            this.lblIstifadeciAdi.AutoSize = true;
            this.lblIstifadeciAdi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIstifadeciAdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblIstifadeciAdi.Location = new System.Drawing.Point(28, 79);
            this.lblIstifadeciAdi.Name = "lblIstifadeciAdi";
            this.lblIstifadeciAdi.Size = new System.Drawing.Size(111, 23);
            this.lblIstifadeciAdi.TabIndex = 0;
            this.lblIstifadeciAdi.Text = "İstifadəçi Adı";
            // 
            // txtIstifadeciAdi
            // 
            this.txtIstifadeciAdi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIstifadeciAdi.Location = new System.Drawing.Point(32, 105);
            this.txtIstifadeciAdi.Name = "txtIstifadeciAdi";
            this.txtIstifadeciAdi.Size = new System.Drawing.Size(260, 34);
            this.txtIstifadeciAdi.TabIndex = 1;
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSifre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSifre.Location = new System.Drawing.Point(28, 155);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(45, 23);
            this.lblSifre.TabIndex = 2;
            this.lblSifre.Text = "Şifrə";
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifre.Location = new System.Drawing.Point(32, 181);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '●';
            this.txtSifre.Size = new System.Drawing.Size(260, 34);
            this.txtSifre.TabIndex = 2;
            // 
            // lblSifreTekrar
            // 
            this.lblSifreTekrar.AutoSize = true;
            this.lblSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSifreTekrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSifreTekrar.Location = new System.Drawing.Point(28, 231);
            this.lblSifreTekrar.Name = "lblSifreTekrar";
            this.lblSifreTekrar.Size = new System.Drawing.Size(99, 23);
            this.lblSifreTekrar.TabIndex = 4;
            this.lblSifreTekrar.Text = "Şifrə Təkrar";
            // 
            // txtSifreTekrar
            // 
            this.txtSifreTekrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSifreTekrar.Location = new System.Drawing.Point(32, 257);
            this.txtSifreTekrar.Name = "txtSifreTekrar";
            this.txtSifreTekrar.PasswordChar = '●';
            this.txtSifreTekrar.Size = new System.Drawing.Size(260, 34);
            this.txtSifreTekrar.TabIndex = 3;
            // 
            // btnQeydiyyat
            // 
            this.btnQeydiyyat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnQeydiyyat.FlatAppearance.BorderSize = 0;
            this.btnQeydiyyat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQeydiyyat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQeydiyyat.ForeColor = System.Drawing.Color.White;
            this.btnQeydiyyat.Location = new System.Drawing.Point(32, 314);
            this.btnQeydiyyat.Name = "btnQeydiyyat";
            this.btnQeydiyyat.Size = new System.Drawing.Size(260, 45);
            this.btnQeydiyyat.TabIndex = 4;
            this.btnQeydiyyat.Text = "Qeydiyyatdan Keç";
            this.btnQeydiyyat.UseVisualStyleBackColor = false;
            this.btnQeydiyyat.Click += new System.EventHandler(this.btnQeydiyyat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(82, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 38);
            this.label1.TabIndex = 7;
            this.label1.Text = "Qeydiyyat";
            // 
            // Frm_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(322, 393);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQeydiyyat);
            this.Controls.Add(this.txtSifreTekrar);
            this.Controls.Add(this.lblSifreTekrar);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.txtIstifadeciAdi);
            this.Controls.Add(this.lblIstifadeciAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.Label label1;
    }
}