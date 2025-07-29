namespace POS
{
    partial class Frm_ProductDetails
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
            this.lblMehsulAd = new System.Windows.Forms.Label();
            this.txtMehsulAd = new System.Windows.Forms.TextBox();
            this.lblMiqdar = new System.Windows.Forms.Label();
            this.lblAlisQiymeti = new System.Windows.Forms.Label();
            this.txtAlisQiymeti = new System.Windows.Forms.TextBox();
            this.lblSatisQiymeti = new System.Windows.Forms.Label();
            this.txtSatisQiymeti = new System.Windows.Forms.TextBox();
            this.lblKateqoriya = new System.Windows.Forms.Label();
            this.cmbKateqoriya = new System.Windows.Forms.ComboBox();
            this.btnYaddaSaxla = new System.Windows.Forms.Button();
            this.btnLegvEt = new System.Windows.Forms.Button();
            this.picMehsulSekli = new System.Windows.Forms.PictureBox();
            this.btnSekilSec = new System.Windows.Forms.Button();
            this.lblBarkod = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.lblTevsir = new System.Windows.Forms.Label();
            this.txtTevsir = new System.Windows.Forms.TextBox();
            this.lblMinStok = new System.Windows.Forms.Label();
            this.lblOlcuVahidi = new System.Windows.Forms.Label();
            this.cmbOlcuVahidi = new System.Windows.Forms.ComboBox();
            this.lblIstehsalTarixi = new System.Windows.Forms.Label();
            this.dtpIstehsalTarixi = new System.Windows.Forms.DateTimePicker();
            this.numMiqdar = new System.Windows.Forms.NumericUpDown();
            this.numMinStok = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.picMehsulSekli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiqdar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStok)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMehsulAd
            // 
            this.lblMehsulAd.AutoSize = true;
            this.lblMehsulAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMehsulAd.Location = new System.Drawing.Point(12, 59);
            this.lblMehsulAd.Name = "lblMehsulAd";
            this.lblMehsulAd.Size = new System.Drawing.Size(97, 20);
            this.lblMehsulAd.TabIndex = 0;
            this.lblMehsulAd.Text = "Məhsul Adı:";
            // 
            // txtMehsulAd
            // 
            this.txtMehsulAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMehsulAd.Location = new System.Drawing.Point(170, 56);
            this.txtMehsulAd.Name = "txtMehsulAd";
            this.txtMehsulAd.Size = new System.Drawing.Size(232, 27);
            this.txtMehsulAd.TabIndex = 2;
            // 
            // lblMiqdar
            // 
            this.lblMiqdar.AutoSize = true;
            this.lblMiqdar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiqdar.Location = new System.Drawing.Point(12, 199);
            this.lblMiqdar.Name = "lblMiqdar";
            this.lblMiqdar.Size = new System.Drawing.Size(64, 20);
            this.lblMiqdar.TabIndex = 2;
            this.lblMiqdar.Text = "Miqdar:";
            // 
            // lblAlisQiymeti
            // 
            this.lblAlisQiymeti.AutoSize = true;
            this.lblAlisQiymeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlisQiymeti.Location = new System.Drawing.Point(12, 319);
            this.lblAlisQiymeti.Name = "lblAlisQiymeti";
            this.lblAlisQiymeti.Size = new System.Drawing.Size(102, 20);
            this.lblAlisQiymeti.TabIndex = 4;
            this.lblAlisQiymeti.Text = "Alış Qiyməti:";
            // 
            // txtAlisQiymeti
            // 
            this.txtAlisQiymeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlisQiymeti.Location = new System.Drawing.Point(170, 316);
            this.txtAlisQiymeti.Name = "txtAlisQiymeti";
            this.txtAlisQiymeti.Size = new System.Drawing.Size(232, 27);
            this.txtAlisQiymeti.TabIndex = 7;
            // 
            // lblSatisQiymeti
            // 
            this.lblSatisQiymeti.AutoSize = true;
            this.lblSatisQiymeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatisQiymeti.Location = new System.Drawing.Point(12, 359);
            this.lblSatisQiymeti.Name = "lblSatisQiymeti";
            this.lblSatisQiymeti.Size = new System.Drawing.Size(111, 20);
            this.lblSatisQiymeti.TabIndex = 6;
            this.lblSatisQiymeti.Text = "Satış Qiyməti:";
            // 
            // txtSatisQiymeti
            // 
            this.txtSatisQiymeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSatisQiymeti.Location = new System.Drawing.Point(170, 356);
            this.txtSatisQiymeti.Name = "txtSatisQiymeti";
            this.txtSatisQiymeti.Size = new System.Drawing.Size(232, 27);
            this.txtSatisQiymeti.TabIndex = 8;
            // 
            // lblKateqoriya
            // 
            this.lblKateqoriya.AutoSize = true;
            this.lblKateqoriya.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKateqoriya.Location = new System.Drawing.Point(12, 399);
            this.lblKateqoriya.Name = "lblKateqoriya";
            this.lblKateqoriya.Size = new System.Drawing.Size(91, 20);
            this.lblKateqoriya.TabIndex = 8;
            this.lblKateqoriya.Text = "Kateqoriya:";
            // 
            // cmbKateqoriya
            // 
            this.cmbKateqoriya.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKateqoriya.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKateqoriya.FormattingEnabled = true;
            this.cmbKateqoriya.Location = new System.Drawing.Point(170, 396);
            this.cmbKateqoriya.Name = "cmbKateqoriya";
            this.cmbKateqoriya.Size = new System.Drawing.Size(232, 28);
            this.cmbKateqoriya.TabIndex = 9;
            // 
            // btnYaddaSaxla
            // 
            this.btnYaddaSaxla.BackColor = System.Drawing.Color.Green;
            this.btnYaddaSaxla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYaddaSaxla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYaddaSaxla.ForeColor = System.Drawing.Color.White;
            this.btnYaddaSaxla.Location = new System.Drawing.Point(491, 444);
            this.btnYaddaSaxla.Name = "btnYaddaSaxla";
            this.btnYaddaSaxla.Size = new System.Drawing.Size(132, 40);
            this.btnYaddaSaxla.TabIndex = 10;
            this.btnYaddaSaxla.Text = "Yadda Saxla";
            this.btnYaddaSaxla.UseVisualStyleBackColor = false;
            this.btnYaddaSaxla.Click += new System.EventHandler(this.btnYaddaSaxla_Click);
            // 
            // btnLegvEt
            // 
            this.btnLegvEt.BackColor = System.Drawing.Color.Red;
            this.btnLegvEt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnLegvEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLegvEt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLegvEt.ForeColor = System.Drawing.Color.White;
            this.btnLegvEt.Location = new System.Drawing.Point(353, 444);
            this.btnLegvEt.Name = "btnLegvEt";
            this.btnLegvEt.Size = new System.Drawing.Size(132, 40);
            this.btnLegvEt.TabIndex = 11;
            this.btnLegvEt.Text = "Ləğv Et";
            this.btnLegvEt.UseVisualStyleBackColor = false;
            // 
            // picMehsulSekli
            // 
            this.picMehsulSekli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMehsulSekli.Location = new System.Drawing.Point(423, 16);
            this.picMehsulSekli.Name = "picMehsulSekli";
            this.picMehsulSekli.Size = new System.Drawing.Size(200, 200);
            this.picMehsulSekli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMehsulSekli.TabIndex = 12;
            this.picMehsulSekli.TabStop = false;
            // 
            // btnSekilSec
            // 
            this.btnSekilSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSekilSec.Location = new System.Drawing.Point(423, 222);
            this.btnSekilSec.Name = "btnSekilSec";
            this.btnSekilSec.Size = new System.Drawing.Size(200, 30);
            this.btnSekilSec.TabIndex = 12;
            this.btnSekilSec.Text = "Şəkil Seç...";
            this.btnSekilSec.UseVisualStyleBackColor = true;
            this.btnSekilSec.Click += new System.EventHandler(this.btnSekilSec_Click);
            // 
            // lblBarkod
            // 
            this.lblBarkod.AutoSize = true;
            this.lblBarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarkod.Location = new System.Drawing.Point(12, 19);
            this.lblBarkod.Name = "lblBarkod";
            this.lblBarkod.Size = new System.Drawing.Size(68, 20);
            this.lblBarkod.TabIndex = 14;
            this.lblBarkod.Text = "Barkod:";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarkod.Location = new System.Drawing.Point(170, 16);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(232, 27);
            this.txtBarkod.TabIndex = 1;
            // 
            // lblTevsir
            // 
            this.lblTevsir.AutoSize = true;
            this.lblTevsir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTevsir.Location = new System.Drawing.Point(12, 99);
            this.lblTevsir.Name = "lblTevsir";
            this.lblTevsir.Size = new System.Drawing.Size(133, 20);
            this.lblTevsir.TabIndex = 16;
            this.lblTevsir.Text = "Məhsul Təsviri:";
            // 
            // txtTevsir
            // 
            this.txtTevsir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTevsir.Location = new System.Drawing.Point(170, 96);
            this.txtTevsir.Multiline = true;
            this.txtTevsir.Name = "txtTevsir";
            this.txtTevsir.Size = new System.Drawing.Size(232, 85);
            this.txtTevsir.TabIndex = 3;
            // 
            // lblMinStok
            // 
            this.lblMinStok.AutoSize = true;
            this.lblMinStok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinStok.Location = new System.Drawing.Point(12, 239);
            this.lblMinStok.Name = "lblMinStok";
            this.lblMinStok.Size = new System.Drawing.Size(152, 20);
            this.lblMinStok.TabIndex = 18;
            this.lblMinStok.Text = "Minimum Stok Səv:";
            // 
            // lblOlcuVahidi
            // 
            this.lblOlcuVahidi.AutoSize = true;
            this.lblOlcuVahidi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOlcuVahidi.Location = new System.Drawing.Point(12, 279);
            this.lblOlcuVahidi.Name = "lblOlcuVahidi";
            this.lblOlcuVahidi.Size = new System.Drawing.Size(102, 20);
            this.lblOlcuVahidi.TabIndex = 20;
            this.lblOlcuVahidi.Text = "Ölçü Vahidi:";
            // 
            // cmbOlcuVahidi
            // 
            this.cmbOlcuVahidi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOlcuVahidi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOlcuVahidi.FormattingEnabled = true;
            this.cmbOlcuVahidi.Items.AddRange(new object[] {
            "Ədəd",
            "KQ",
            "Litr",
            "Qutu"});
            this.cmbOlcuVahidi.Location = new System.Drawing.Point(170, 276);
            this.cmbOlcuVahidi.Name = "cmbOlcuVahidi";
            this.cmbOlcuVahidi.Size = new System.Drawing.Size(232, 28);
            this.cmbOlcuVahidi.TabIndex = 6;
            // 
            // lblIstehsalTarixi
            // 
            this.lblIstehsalTarixi.AutoSize = true;
            this.lblIstehsalTarixi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIstehsalTarixi.Location = new System.Drawing.Point(420, 279);
            this.lblIstehsalTarixi.Name = "lblIstehsalTarixi";
            this.lblIstehsalTarixi.Size = new System.Drawing.Size(118, 20);
            this.lblIstehsalTarixi.TabIndex = 22;
            this.lblIstehsalTarixi.Text = "İstehsal Tarixi:";
            // 
            // dtpIstehsalTarixi
            // 
            this.dtpIstehsalTarixi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpIstehsalTarixi.Location = new System.Drawing.Point(423, 314);
            this.dtpIstehsalTarixi.Name = "dtpIstehsalTarixi";
            this.dtpIstehsalTarixi.Size = new System.Drawing.Size(200, 27);
            this.dtpIstehsalTarixi.TabIndex = 13;
            // 
            // numMiqdar
            // 
            this.numMiqdar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.numMiqdar.Location = new System.Drawing.Point(170, 197);
            this.numMiqdar.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMiqdar.Name = "numMiqdar";
            this.numMiqdar.Size = new System.Drawing.Size(232, 27);
            this.numMiqdar.TabIndex = 4;
            // 
            // numMinStok
            // 
            this.numMinStok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.numMinStok.Location = new System.Drawing.Point(170, 237);
            this.numMinStok.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMinStok.Name = "numMinStok";
            this.numMinStok.Size = new System.Drawing.Size(232, 27);
            this.numMinStok.TabIndex = 5;
            // 
            // Frm_ProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 501);
            this.Controls.Add(this.numMinStok);
            this.Controls.Add(this.numMiqdar);
            this.Controls.Add(this.dtpIstehsalTarixi);
            this.Controls.Add(this.lblIstehsalTarixi);
            this.Controls.Add(this.cmbOlcuVahidi);
            this.Controls.Add(this.lblOlcuVahidi);
            this.Controls.Add(this.lblMinStok);
            this.Controls.Add(this.txtTevsir);
            this.Controls.Add(this.lblTevsir);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.lblBarkod);
            this.Controls.Add(this.btnSekilSec);
            this.Controls.Add(this.picMehsulSekli);
            this.Controls.Add(this.btnLegvEt);
            this.Controls.Add(this.btnYaddaSaxla);
            this.Controls.Add(this.cmbKateqoriya);
            this.Controls.Add(this.lblKateqoriya);
            this.Controls.Add(this.txtSatisQiymeti);
            this.Controls.Add(this.lblSatisQiymeti);
            this.Controls.Add(this.txtAlisQiymeti);
            this.Controls.Add(this.lblAlisQiymeti);
            this.Controls.Add(this.lblMiqdar);
            this.Controls.Add(this.txtMehsulAd);
            this.Controls.Add(this.lblMehsulAd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_ProductDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Məhsul Məlumatları";
            this.Load += new System.EventHandler(this.Frm_ProductDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMehsulSekli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMiqdar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinStok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMehsulAd;
        private System.Windows.Forms.TextBox txtMehsulAd;
        private System.Windows.Forms.Label lblMiqdar;
        private System.Windows.Forms.Label lblAlisQiymeti;
        private System.Windows.Forms.TextBox txtAlisQiymeti;
        private System.Windows.Forms.Label lblSatisQiymeti;
        private System.Windows.Forms.TextBox txtSatisQiymeti;
        private System.Windows.Forms.Label lblKateqoriya;
        private System.Windows.Forms.ComboBox cmbKateqoriya;
        private System.Windows.Forms.Button btnYaddaSaxla;
        private System.Windows.Forms.Button btnLegvEt;
        private System.Windows.Forms.PictureBox picMehsulSekli;
        private System.Windows.Forms.Button btnSekilSec;
        private System.Windows.Forms.Label lblBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Label lblTevsir;
        private System.Windows.Forms.TextBox txtTevsir;
        private System.Windows.Forms.Label lblMinStok;
        private System.Windows.Forms.Label lblOlcuVahidi;
        private System.Windows.Forms.ComboBox cmbOlcuVahidi;
        private System.Windows.Forms.Label lblIstehsalTarixi;
        private System.Windows.Forms.DateTimePicker dtpIstehsalTarixi;
        private System.Windows.Forms.NumericUpDown numMiqdar;
        private System.Windows.Forms.NumericUpDown numMinStok;
    }
}