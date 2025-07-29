namespace POS
{
    partial class Frm_Reports
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
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnHesabatiGoster = new System.Windows.Forms.Button();
            this.dgvSalesReport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblXalisQazanc = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMayaDeyeri = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUmumiGelir = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBaslangic.Location = new System.Drawing.Point(157, 12);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(200, 27);
            this.dtpBaslangic.TabIndex = 0;
            // 
            // dtpBitis
            // 
            this.dtpBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBitis.Location = new System.Drawing.Point(472, 12);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(200, 27);
            this.dtpBitis.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Başlanğıc Tarix:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(363, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bitiş Tarix:";
            // 
            // btnHesabatiGoster
            // 
            this.btnHesabatiGoster.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnHesabatiGoster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHesabatiGoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHesabatiGoster.ForeColor = System.Drawing.Color.White;
            this.btnHesabatiGoster.Location = new System.Drawing.Point(692, 12);
            this.btnHesabatiGoster.Name = "btnHesabatiGoster";
            this.btnHesabatiGoster.Size = new System.Drawing.Size(217, 34);
            this.btnHesabatiGoster.TabIndex = 4;
            this.btnHesabatiGoster.Text = "Hesabatı Göstər";
            this.btnHesabatiGoster.UseVisualStyleBackColor = false;
            this.btnHesabatiGoster.Click += new System.EventHandler(this.btnHesabatiGoster_Click);
            // 
            // dgvSalesReport
            // 
            this.dgvSalesReport.AllowUserToAddRows = false;
            this.dgvSalesReport.AllowUserToDeleteRows = false;
            this.dgvSalesReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSalesReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesReport.Location = new System.Drawing.Point(16, 61);
            this.dgvSalesReport.Name = "dgvSalesReport";
            this.dgvSalesReport.ReadOnly = true;
            this.dgvSalesReport.RowHeadersWidth = 51;
            this.dgvSalesReport.RowTemplate.Height = 24;
            this.dgvSalesReport.Size = new System.Drawing.Size(893, 375);
            this.dgvSalesReport.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lblXalisQazanc);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblMayaDeyeri);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblUmumiGelir);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(16, 451);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 76);
            this.panel1.TabIndex = 6;
            // 
            // lblXalisQazanc
            // 
            this.lblXalisQazanc.AutoSize = true;
            this.lblXalisQazanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXalisQazanc.ForeColor = System.Drawing.Color.Green;
            this.lblXalisQazanc.Location = new System.Drawing.Point(753, 26);
            this.lblXalisQazanc.Name = "lblXalisQazanc";
            this.lblXalisQazanc.Size = new System.Drawing.Size(82, 25);
            this.lblXalisQazanc.TabIndex = 5;
            this.lblXalisQazanc.Text = "0.00 ₼";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(593, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Xalis Qazanc:";
            // 
            // lblMayaDeyeri
            // 
            this.lblMayaDeyeri.AutoSize = true;
            this.lblMayaDeyeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMayaDeyeri.ForeColor = System.Drawing.Color.Red;
            this.lblMayaDeyeri.Location = new System.Drawing.Point(448, 29);
            this.lblMayaDeyeri.Name = "lblMayaDeyeri";
            this.lblMayaDeyeri.Size = new System.Drawing.Size(67, 20);
            this.lblMayaDeyeri.TabIndex = 3;
            this.lblMayaDeyeri.Text = "0.00 ₼";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(298, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ümumi Xərc (Maya Dəyəri):";
            // 
            // lblUmumiGelir
            // 
            this.lblUmumiGelir.AutoSize = true;
            this.lblUmumiGelir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUmumiGelir.Location = new System.Drawing.Point(125, 29);
            this.lblUmumiGelir.Name = "lblUmumiGelir";
            this.lblUmumiGelir.Size = new System.Drawing.Size(67, 20);
            this.lblUmumiGelir.TabIndex = 1;
            this.lblUmumiGelir.Text = "0.00 ₼";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ümumi Gəlir:";
            // 
            // Frm_Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 545);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSalesReport);
            this.Controls.Add(this.btnHesabatiGoster);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpBitis);
            this.Controls.Add(this.dtpBaslangic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Satış və Qazanc Hesabatları";
            this.Load += new System.EventHandler(this.Frm_Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHesabatiGoster;
        private System.Windows.Forms.DataGridView dgvSalesReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblXalisQazanc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMayaDeyeri;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUmumiGelir;
        private System.Windows.Forms.Label label3;
    }
}