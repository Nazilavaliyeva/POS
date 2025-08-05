namespace POS
{
    partial class Frm_Receipt
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
            this.lblTarix = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvSatisDetallari = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.lblYekunMebleg = new System.Windows.Forms.Label();
            this.btnBagla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSatisID = new System.Windows.Forms.Label();
            this.lblEndirim = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUmumiMebleg = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblOdenisNovu = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Satış Qəbzi";
            // 
            // lblTarix
            // 
            this.lblTarix.AutoSize = true;
            this.lblTarix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarix.Location = new System.Drawing.Point(132, 90);
            this.lblTarix.Name = "lblTarix";
            this.lblTarix.Size = new System.Drawing.Size(41, 18);
            this.lblTarix.TabIndex = 1;
            this.lblTarix.Text = "Tarix";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tarix:";
            // 
            // lvSatisDetallari
            // 
            this.lvSatisDetallari.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvSatisDetallari.HideSelection = false;
            this.lvSatisDetallari.Location = new System.Drawing.Point(15, 155);
            this.lvSatisDetallari.Name = "lvSatisDetallari";
            this.lvSatisDetallari.Size = new System.Drawing.Size(416, 253);
            this.lvSatisDetallari.TabIndex = 3;
            this.lvSatisDetallari.UseCompatibleStateImageBehavior = false;
            this.lvSatisDetallari.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Məhsul Adı";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Miqdar";
            this.columnHeader2.Width = 70;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Qiymət";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Toplam";
            this.columnHeader4.Width = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 485);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Yekun Məbləğ:";
            // 
            // lblYekunMebleg
            // 
            this.lblYekunMebleg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYekunMebleg.Location = new System.Drawing.Point(279, 485);
            this.lblYekunMebleg.Name = "lblYekunMebleg";
            this.lblYekunMebleg.Size = new System.Drawing.Size(152, 25);
            this.lblYekunMebleg.TabIndex = 5;
            this.lblYekunMebleg.Text = "0.00 ₼";
            this.lblYekunMebleg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBagla
            // 
            this.btnBagla.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBagla.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBagla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBagla.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBagla.ForeColor = System.Drawing.Color.White;
            this.btnBagla.Location = new System.Drawing.Point(156, 529);
            this.btnBagla.Name = "btnBagla";
            this.btnBagla.Size = new System.Drawing.Size(132, 40);
            this.btnBagla.TabIndex = 12;
            this.btnBagla.Text = "Bağla";
            this.btnBagla.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Satış ID:";
            // 
            // lblSatisID
            // 
            this.lblSatisID.AutoSize = true;
            this.lblSatisID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSatisID.Location = new System.Drawing.Point(132, 63);
            this.lblSatisID.Name = "lblSatisID";
            this.lblSatisID.Size = new System.Drawing.Size(22, 18);
            this.lblSatisID.TabIndex = 13;
            this.lblSatisID.Text = "ID";
            // 
            // lblEndirim
            // 
            this.lblEndirim.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndirim.ForeColor = System.Drawing.Color.Red;
            this.lblEndirim.Location = new System.Drawing.Point(279, 451);
            this.lblEndirim.Name = "lblEndirim";
            this.lblEndirim.Size = new System.Drawing.Size(152, 25);
            this.lblEndirim.TabIndex = 16;
            this.lblEndirim.Text = "- 0.00 ₼";
            this.lblEndirim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 451);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Endirim:";
            // 
            // lblUmumiMebleg
            // 
            this.lblUmumiMebleg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUmumiMebleg.Location = new System.Drawing.Point(279, 422);
            this.lblUmumiMebleg.Name = "lblUmumiMebleg";
            this.lblUmumiMebleg.Size = new System.Drawing.Size(152, 25);
            this.lblUmumiMebleg.TabIndex = 18;
            this.lblUmumiMebleg.Text = "0.00 ₼";
            this.lblUmumiMebleg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Ümumi Məbləğ:";
            // 
            // lblOdenisNovu
            // 
            this.lblOdenisNovu.AutoSize = true;
            this.lblOdenisNovu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOdenisNovu.Location = new System.Drawing.Point(132, 117);
            this.lblOdenisNovu.Name = "lblOdenisNovu";
            this.lblOdenisNovu.Size = new System.Drawing.Size(43, 18);
            this.lblOdenisNovu.TabIndex = 20;
            this.lblOdenisNovu.Text = "Növü";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ödəniş Növü:";
            // 
            // Frm_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 581);
            this.Controls.Add(this.lblOdenisNovu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblUmumiMebleg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblEndirim);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSatisID);
            this.Controls.Add(this.btnBagla);
            this.Controls.Add(this.lblYekunMebleg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvSatisDetallari);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTarix);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Receipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Qəbz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTarix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvSatisDetallari;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblYekunMebleg;
        private System.Windows.Forms.Button btnBagla;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSatisID;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblEndirim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUmumiMebleg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblOdenisNovu;
        private System.Windows.Forms.Label label8;
    }
}