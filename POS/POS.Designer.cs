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
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 59);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(776, 339);
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
            this.btnYeniMehsul.Location = new System.Drawing.Point(520, 415);
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
            this.btnSil.Location = new System.Drawing.Point(658, 415);
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
            this.lblKateqoriyaFilter.Location = new System.Drawing.Point(448, 19);
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
            this.cmbKateqoriyaFilter.Location = new System.Drawing.Point(545, 16);
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
            this.btnYenile.Location = new System.Drawing.Point(382, 415);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(132, 40);
            this.btnYenile.TabIndex = 7;
            this.btnYenile.Text = "Yenilə";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // frmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 471);
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
    }
}