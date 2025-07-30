namespace POS
{
    partial class frmPOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOS));
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lblAxtaris = new System.Windows.Forms.Label();
            this.txtAxtaris = new System.Windows.Forms.TextBox();
            this.btnYeniMehsul = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.lblKateqoriyaFilter = new System.Windows.Forms.Label();
            this.cmbKateqoriyaFilter = new System.Windows.Forms.ComboBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.dgvBasket = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblYekunMebleg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSatisEt = new System.Windows.Forms.Button();
            this.btnSebetiTemizle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHesabatlar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 85);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(560, 480);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellDoubleClick);
            // 
            // lblAxtaris
            // 
            this.lblAxtaris.AutoSize = true;
            this.lblAxtaris.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAxtaris.Location = new System.Drawing.Point(12, 19);
            this.lblAxtaris.Name = "lblAxtaris";
            this.lblAxtaris.Size = new System.Drawing.Size(117, 20);
            this.lblAxtaris.TabIndex = 1;
            this.lblAxtaris.Text = "Ada görə axtar:";
            // 
            // txtAxtaris
            // 
            this.txtAxtaris.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAxtaris.Location = new System.Drawing.Point(135, 16);
            this.txtAxtaris.Name = "txtAxtaris";
            this.txtAxtaris.Size = new System.Drawing.Size(235, 27);
            this.txtAxtaris.TabIndex = 2;
            this.txtAxtaris.TextChanged += new System.EventHandler(this.txtAxtaris_TextChanged);
            // 
            // btnYeniMehsul
            // 
            this.btnYeniMehsul.BackColor = System.Drawing.Color.Green;
            this.btnYeniMehsul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniMehsul.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYeniMehsul.ForeColor = System.Drawing.Color.White;
            this.btnYeniMehsul.Location = new System.Drawing.Point(12, 571);
            this.btnYeniMehsul.Name = "btnYeniMehsul";
            this.btnYeniMehsul.Size = new System.Drawing.Size(132, 40);
            this.btnYeniMehsul.TabIndex = 3;
            this.btnYeniMehsul.Text = "Yeni Məhsul";
            this.btnYeniMehsul.UseVisualStyleBackColor = false;
            this.btnYeniMehsul.Click += new System.EventHandler(this.btnYeniMehsul_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.Red;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.Location = new System.Drawing.Point(288, 571);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(130, 40);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // lblKateqoriyaFilter
            // 
            this.lblKateqoriyaFilter.AutoSize = true;
            this.lblKateqoriyaFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKateqoriyaFilter.Location = new System.Drawing.Point(391, 19);
            this.lblKateqoriyaFilter.Name = "lblKateqoriyaFilter";
            this.lblKateqoriyaFilter.Size = new System.Drawing.Size(91, 20);
            this.lblKateqoriyaFilter.TabIndex = 5;
            this.lblKateqoriyaFilter.Text = "Kateqoriya:";
            // 
            // cmbKateqoriyaFilter
            // 
            this.cmbKateqoriyaFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKateqoriyaFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKateqoriyaFilter.FormattingEnabled = true;
            this.cmbKateqoriyaFilter.Location = new System.Drawing.Point(488, 16);
            this.cmbKateqoriyaFilter.Name = "cmbKateqoriyaFilter";
            this.cmbKateqoriyaFilter.Size = new System.Drawing.Size(243, 28);
            this.cmbKateqoriyaFilter.TabIndex = 6;
            this.cmbKateqoriyaFilter.SelectedIndexChanged += new System.EventHandler(this.cmbKateqoriyaFilter_SelectedIndexChanged);
            // 
            // btnYenile
            // 
            this.btnYenile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnYenile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYenile.ForeColor = System.Drawing.Color.White;
            this.btnYenile.Location = new System.Drawing.Point(150, 571);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(132, 40);
            this.btnYenile.TabIndex = 7;
            this.btnYenile.Text = "Yenilə";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // dgvBasket
            // 
            this.dgvBasket.AllowUserToAddRows = false;
            this.dgvBasket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBasket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBasket.Location = new System.Drawing.Point(590, 85);
            this.dgvBasket.Name = "dgvBasket";
            this.dgvBasket.RowHeadersWidth = 51;
            this.dgvBasket.RowTemplate.Height = 24;
            this.dgvBasket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBasket.Size = new System.Drawing.Size(500, 360);
            this.dgvBasket.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.lblYekunMebleg);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(590, 451);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 64);
            this.panel1.TabIndex = 9;
            // 
            // lblYekunMebleg
            // 
            this.lblYekunMebleg.AutoSize = true;
            this.lblYekunMebleg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYekunMebleg.Location = new System.Drawing.Point(395, 18);
            this.lblYekunMebleg.Name = "lblYekunMebleg";
            this.lblYekunMebleg.Size = new System.Drawing.Size(90, 29);
            this.lblYekunMebleg.TabIndex = 1;
            this.lblYekunMebleg.Text = "0.00 ₼";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yekun Məbləğ:";
            // 
            // btnSatisEt
            // 
            this.btnSatisEt.BackColor = System.Drawing.Color.Orange;
            this.btnSatisEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatisEt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSatisEt.ForeColor = System.Drawing.Color.White;
            this.btnSatisEt.Location = new System.Drawing.Point(850, 521);
            this.btnSatisEt.Name = "btnSatisEt";
            this.btnSatisEt.Size = new System.Drawing.Size(240, 90);
            this.btnSatisEt.TabIndex = 10;
            this.btnSatisEt.Text = "Satışı Bitir";
            this.btnSatisEt.UseVisualStyleBackColor = false;
            this.btnSatisEt.Click += new System.EventHandler(this.btnSatisEt_Click);
            // 
            // btnSebetiTemizle
            // 
            this.btnSebetiTemizle.BackColor = System.Drawing.Color.Gray;
            this.btnSebetiTemizle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSebetiTemizle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSebetiTemizle.ForeColor = System.Drawing.Color.White;
            this.btnSebetiTemizle.Location = new System.Drawing.Point(590, 521);
            this.btnSebetiTemizle.Name = "btnSebetiTemizle";
            this.btnSebetiTemizle.Size = new System.Drawing.Size(180, 40);
            this.btnSebetiTemizle.TabIndex = 11;
            this.btnSebetiTemizle.Text = "Səbəti Təmizlə";
            this.btnSebetiTemizle.UseVisualStyleBackColor = false;
            this.btnSebetiTemizle.Click += new System.EventHandler(this.btnSebetiTemizle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Məhsul Anbarı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(585, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Satış Səbəti";
            // 
            // btnHesabatlar
            // 
            this.btnHesabatlar.BackColor = System.Drawing.Color.Teal;
            this.btnHesabatlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHesabatlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHesabatlar.ForeColor = System.Drawing.Color.White;
            this.btnHesabatlar.Location = new System.Drawing.Point(590, 571);
            this.btnHesabatlar.Name = "btnHesabatlar";
            this.btnHesabatlar.Size = new System.Drawing.Size(180, 40);
            this.btnHesabatlar.TabIndex = 14;
            this.btnHesabatlar.Text = "Hesabatlar";
            this.btnHesabatlar.UseVisualStyleBackColor = false;
            this.btnHesabatlar.Click += new System.EventHandler(this.btnHesabatlar_Click);
            // 
            // frmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 623);
            this.Controls.Add(this.btnHesabatlar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSebetiTemizle);
            this.Controls.Add(this.btnSatisEt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvBasket);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.cmbKateqoriyaFilter);
            this.Controls.Add(this.lblKateqoriyaFilter);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnYeniMehsul);
            this.Controls.Add(this.txtAxtaris);
            this.Controls.Add(this.lblAxtaris);
            this.Controls.Add(this.dgvProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Satış Nöqtəsi Sistemi (POS)";
            this.Load += new System.EventHandler(this.frmPOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBasket)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label lblAxtaris;
        private System.Windows.Forms.TextBox txtAxtaris;
        private System.Windows.Forms.Button btnYeniMehsul;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Label lblKateqoriyaFilter;
        private System.Windows.Forms.ComboBox cmbKateqoriyaFilter;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.DataGridView dgvBasket;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblYekunMebleg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSatisEt;
        private System.Windows.Forms.Button btnSebetiTemizle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHesabatlar;
    }
}