namespace POS
{
    partial class Frm_ReturnProduct
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSatisID = new System.Windows.Forms.TextBox();
            this.btnAxtar = new System.Windows.Forms.Button();
            this.dgvSoldItems = new System.Windows.Forms.DataGridView();
            this.btnGeriQaytar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numReturnQty = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoldItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnQty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Satış ID-sini daxil et:";
            // 
            // txtSatisID
            // 
            this.txtSatisID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSatisID.Location = new System.Drawing.Point(179, 17);
            this.txtSatisID.Name = "txtSatisID";
            this.txtSatisID.Size = new System.Drawing.Size(315, 30);
            this.txtSatisID.TabIndex = 1;
            // 
            // btnAxtar
            // 
            this.btnAxtar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAxtar.FlatAppearance.BorderSize = 0;
            this.btnAxtar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAxtar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAxtar.ForeColor = System.Drawing.Color.White;
            this.btnAxtar.Location = new System.Drawing.Point(513, 15);
            this.btnAxtar.Name = "btnAxtar";
            this.btnAxtar.Size = new System.Drawing.Size(121, 34);
            this.btnAxtar.TabIndex = 2;
            this.btnAxtar.Text = "Axtar";
            this.btnAxtar.UseVisualStyleBackColor = false;
            this.btnAxtar.Click += new System.EventHandler(this.btnAxtar_Click);
            // 
            // dgvSoldItems
            // 
            this.dgvSoldItems.AllowUserToAddRows = false;
            this.dgvSoldItems.AllowUserToDeleteRows = false;
            this.dgvSoldItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSoldItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoldItems.Location = new System.Drawing.Point(16, 102);
            this.dgvSoldItems.MultiSelect = false;
            this.dgvSoldItems.Name = "dgvSoldItems";
            this.dgvSoldItems.ReadOnly = true;
            this.dgvSoldItems.RowHeadersWidth = 51;
            this.dgvSoldItems.RowTemplate.Height = 24;
            this.dgvSoldItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSoldItems.Size = new System.Drawing.Size(618, 226);
            this.dgvSoldItems.TabIndex = 3;
            // 
            // btnGeriQaytar
            // 
            this.btnGeriQaytar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnGeriQaytar.Enabled = false;
            this.btnGeriQaytar.FlatAppearance.BorderSize = 0;
            this.btnGeriQaytar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeriQaytar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeriQaytar.ForeColor = System.Drawing.Color.White;
            this.btnGeriQaytar.Location = new System.Drawing.Point(451, 344);
            this.btnGeriQaytar.Name = "btnGeriQaytar";
            this.btnGeriQaytar.Size = new System.Drawing.Size(183, 40);
            this.btnGeriQaytar.TabIndex = 4;
            this.btnGeriQaytar.Text = "Seçiləni Geri Qaytar";
            this.btnGeriQaytar.UseVisualStyleBackColor = false;
            this.btnGeriQaytar.Click += new System.EventHandler(this.btnGeriQaytar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Satılan Məhsullar:";
            // 
            // numReturnQty
            // 
            this.numReturnQty.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.numReturnQty.Location = new System.Drawing.Point(220, 350);
            this.numReturnQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numReturnQty.Name = "numReturnQty";
            this.numReturnQty.Size = new System.Drawing.Size(120, 30);
            this.numReturnQty.TabIndex = 6;
            this.numReturnQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Qaytarılacaq Miqdar:";
            // 
            // Frm_ReturnProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(650, 403);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numReturnQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGeriQaytar);
            this.Controls.Add(this.dgvSoldItems);
            this.Controls.Add(this.btnAxtar);
            this.Controls.Add(this.txtSatisID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ReturnProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Məhsulu Geri Qaytarma";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoldItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numReturnQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSatisID;
        private System.Windows.Forms.Button btnAxtar;
        private System.Windows.Forms.DataGridView dgvSoldItems;
        private System.Windows.Forms.Button btnGeriQaytar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numReturnQty;
        private System.Windows.Forms.Label label4;
    }
}