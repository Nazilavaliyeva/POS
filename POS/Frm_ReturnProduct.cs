using System;
using System.Data;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_ReturnProduct : Form
    {
        public Frm_ReturnProduct()
        {
            InitializeComponent();
        }

        private void btnAxtar_Click(object sender, EventArgs e)
        {
            dgvSoldItems.DataSource = null;
            btnGeriQaytar.Enabled = false;
            string satisID = txtSatisID.Text.Trim();

            if (string.IsNullOrEmpty(satisID))
            {
                MessageBox.Show("Zəhmət olmasa, Satış ID-sini daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable soldItemsTable = DataAccess.GetSaleDetailsByTransactionId(satisID);

                if (soldItemsTable.Rows.Count == 0)
                {
                    MessageBox.Show("Bu ID ilə satış tapılmadı.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dgvSoldItems.DataSource = soldItemsTable;
                btnGeriQaytar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış axtararkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeriQaytar_Click(object sender, EventArgs e)
        {
            if (dgvSoldItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Geri qaytarmaq üçün məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string barkod = dgvSoldItems.SelectedRows[0].Cells["Barkod"].Value.ToString();
            string mehsulAdi = dgvSoldItems.SelectedRows[0].Cells["Məhsul Adı"].Value.ToString();
            int satilanMiqdar = Convert.ToInt32(dgvSoldItems.SelectedRows[0].Cells["Satılan Miqdar"].Value);
            int qaytarilanMiqdar = (int)numReturnQty.Value;

            if (qaytarilanMiqdar > satilanMiqdar)
            {
                MessageBox.Show($"Bu satışda yalnız {satilanMiqdar} ədəd '{mehsulAdi}' satılıb. Daha çox qaytara bilməzsiniz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"'{mehsulAdi}' məhsulundan {qaytarilanMiqdar} ədəd geri qaytarılır. Əminsinizmi?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DataAccess.ProcessReturn(txtSatisID.Text.Trim(), barkod, mehsulAdi, qaytarilanMiqdar);

                    MessageBox.Show("Məhsul uğurla geri qaytarıldı və stok yeniləndi.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Geri qaytarma zamanı xəta baş verdi: {ex.Message}");
                }
            }
        }
    }
}