using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_ReturnProduct : Form
    {
        private readonly string salesFilePath = "sales.txt";
        private readonly string productsFilePath = "products.txt";
        private readonly string returnsFilePath = "returns.txt";
        private DataTable soldItemsTable = new DataTable();

        public Frm_ReturnProduct()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            soldItemsTable.Columns.Add("Barkod", typeof(string));
            soldItemsTable.Columns.Add("Məhsul Adı", typeof(string));
            soldItemsTable.Columns.Add("Satılan Miqdar", typeof(int));
            soldItemsTable.Columns.Add("Qiymət", typeof(decimal));
            dgvSoldItems.DataSource = soldItemsTable;
        }

        private void btnAxtar_Click(object sender, EventArgs e)
        {
            soldItemsTable.Clear();
            btnGeriQaytar.Enabled = false;
            string satisID = txtSatisID.Text.Trim();

            if (string.IsNullOrEmpty(satisID))
            {
                MessageBox.Show("Zəhmət olmasa, Satış ID-sini daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(salesFilePath))
            {
                MessageBox.Show("Heç bir satış qeydi tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var saleLines = File.ReadAllLines(salesFilePath)
                                .Where(line => line.Split('|')[0].Equals(satisID, StringComparison.OrdinalIgnoreCase))
                                .ToList();

            if (saleLines.Count == 0)
            {
                MessageBox.Show("Bu ID ilə satış tapılmadı.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var line in saleLines)
            {
                string[] parts = line.Split('|');
                // Format: TransactionID|Date|Barkod|ProductName|Quantity|SalePrice
                if (parts.Length == 6)
                {
                    soldItemsTable.Rows.Add(parts[2], parts[3], int.Parse(parts[4]), decimal.Parse(parts[5]));
                }
            }
            btnGeriQaytar.Enabled = true;
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
                    // 1. Məhsulun stokunu artırırıq (barkoda görə)
                    List<string> productLines = File.ReadAllLines(productsFilePath).ToList();
                    int index = productLines.FindIndex(line => line.Split('|')[0].Equals(barkod, StringComparison.OrdinalIgnoreCase));
                    if (index != -1)
                    {
                        string[] parts = productLines[index].Split('|');
                        parts[3] = (int.Parse(parts[3]) + qaytarilanMiqdar).ToString(); // Miqdarı artırırıq
                        productLines[index] = string.Join("|", parts);
                        File.WriteAllLines(productsFilePath, productLines);
                    }
                    else
                    {
                        MessageBox.Show("Qaytarılan məhsul anbarda tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Qaytarılma qeydi yaradırıq
                    string returnRecord = $"{txtSatisID.Text.Trim()}|{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{barkod}|{mehsulAdi}|{qaytarilanMiqdar}";
                    File.AppendAllText(returnsFilePath, returnRecord + Environment.NewLine);

                    MessageBox.Show("Məhsul uğurla geri qaytarıldı və stok yeniləndi.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Ana formanın məhsul siyahısını yeniləməsi üçün
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