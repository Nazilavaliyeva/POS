using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class frmPOS : Form
    {
        private readonly string productsFilePath = "products.txt";
        private readonly string categoriesFilePath = "categories.txt";
        private readonly string salesFilePath = "sales.txt";

        private DataTable productTable = new DataTable();
        private DataTable basketTable = new DataTable();

        public frmPOS()
        {
            InitializeComponent();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            SetupDataTables();
            LoadProducts();
            LoadCategoriesFilter();
        }

        private void SetupDataTables()
        {
            productTable.Columns.Add("Barkod", typeof(string));
            productTable.Columns.Add("Ad", typeof(string));
            productTable.Columns.Add("Miqdar", typeof(int));
            productTable.Columns.Add("Satış Qiyməti", typeof(decimal));
            productTable.Columns.Add("Kateqoriya", typeof(string));
            productTable.Columns.Add("Min. Stok", typeof(int));

            dgvProducts.DataSource = productTable;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.DataBindingComplete += dgvProducts_DataBindingComplete;

            basketTable.Columns.Add("Barkod", typeof(string));
            basketTable.Columns.Add("Ad", typeof(string));
            basketTable.Columns.Add("Miqdar", typeof(int));
            basketTable.Columns.Add("Qiymət", typeof(decimal));
            basketTable.Columns.Add("Toplam", typeof(decimal), "Miqdar * Qiymət");

            dgvBasket.DataSource = basketTable;
            dgvBasket.ReadOnly = true;
            dgvBasket.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBasket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadProducts()
        {
            productTable.Clear();
            if (!File.Exists(productsFilePath)) return;

            try
            {
                var encryptedLines = File.ReadAllLines(productsFilePath);
                foreach (var encryptedLine in encryptedLines)
                {
                    string line = EncryptionHelper.Decrypt(encryptedLine);
                    string[] parts = line.Split('|');
                    if (parts.Length == 11)
                    {
                        productTable.Rows.Add(parts[0], parts[1], int.Parse(parts[3]), decimal.Parse(parts[8]), parts[9], int.Parse(parts[4]));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsulları yükləyərkən xəta baş verdi: {ex.Message}");
            }
        }

        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvProducts.Rows)
            {
                if (row.Cells["Miqdar"].Value == null || row.Cells["Min. Stok"].Value == null) continue;

                int miqdar = Convert.ToInt32(row.Cells["Miqdar"].Value);
                int minStok = Convert.ToInt32(row.Cells["Min. Stok"].Value);

                if (miqdar <= minStok)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = SystemColors.Window;
                    row.DefaultCellStyle.ForeColor = SystemColors.ControlText;
                }
            }
        }

        private void LoadCategoriesFilter()
        {
            try
            {
                cmbKateqoriyaFilter.Items.Clear();
                cmbKateqoriyaFilter.Items.Add("Bütün Kateqoriyalar");
                if (File.Exists(categoriesFilePath))
                {
                    var encryptedLines = File.ReadAllLines(categoriesFilePath);
                    var decryptedLines = encryptedLines.Select(line => EncryptionHelper.Decrypt(line));
                    cmbKateqoriyaFilter.Items.AddRange(decryptedLines.ToArray());
                }
                cmbKateqoriyaFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kateqoriyaları yükləyərkən xəta baş verdi: {ex.Message}");
            }
        }

        private void btnYeniMehsul_Click(object sender, EventArgs e)
        {
            Frm_ProductDetails addProductForm = new Frm_ProductDetails();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            EditSelectedProduct();
        }

        private void EditSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Yeniləmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string selectedBarcode = dgvProducts.SelectedRows[0].Cells["Barkod"].Value.ToString();

                var encryptedLines = File.ReadAllLines(productsFilePath);
                string encryptedProductLine = encryptedLines.FirstOrDefault(line => EncryptionHelper.Decrypt(line).Split('|')[0] == selectedBarcode);

                if (encryptedProductLine != null)
                {
                    Frm_ProductDetails updateForm = new Frm_ProductDetails(EncryptionHelper.Decrypt(encryptedProductLine).Split('|'));
                    if (updateForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul məlumatlarını açarkən xəta baş verdi: {ex.Message}");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Seçilmiş məhsulu silməyə əminsiniz?", "Silməni Təsdiqlə", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string selectedBarcode = dgvProducts.SelectedRows[0].Cells["Barkod"].Value.ToString();

                    var encryptedLines = File.ReadAllLines(productsFilePath).ToList();
                    encryptedLines.RemoveAll(encryptedLine => EncryptionHelper.Decrypt(encryptedLine).Split('|')[0] == selectedBarcode);
                    File.WriteAllLines(productsFilePath, encryptedLines);

                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Məhsulu silərkən xəta baş verdi: {ex.Message}");
                }
            }
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView selectedRow = (DataRowView)dgvProducts.Rows[e.RowIndex].DataBoundItem;
                string barkod = selectedRow["Barkod"].ToString();
                AddToBasket(barkod);
            }
        }

        private void FilterProducts()
        {
            DataView dv = productTable.DefaultView;
            string filter = "";

            if (!string.IsNullOrEmpty(txtAxtaris.Text))
            {
                filter += $"Ad LIKE '%{txtAxtaris.Text}%'";
            }

            if (cmbKateqoriyaFilter.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"Kateqoriya = '{cmbKateqoriyaFilter.SelectedItem}'";
            }

            dv.RowFilter = filter;
        }

        private void txtAxtaris_TextChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void cmbKateqoriyaFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterProducts();
        }

        private void btnHesabatlar_Click(object sender, EventArgs e)
        {
            Frm_Reports reportsForm = new Frm_Reports();
            reportsForm.ShowDialog();
        }

        private void btnKateqoriyalar_Click(object sender, EventArgs e)
        {
            Frm_Categories categoriesForm = new Frm_Categories();
            if (categoriesForm.ShowDialog() == DialogResult.OK)
            {
                LoadCategoriesFilter();
                LoadProducts();
            }
        }

        private void btnGeriQaytarma_Click(object sender, EventArgs e)
        {
            Frm_ReturnProduct returnForm = new Frm_ReturnProduct();
            if (returnForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void AddToBasket(string barkod)
        {
            DataRow productRow = productTable.Select($"Barkod = '{barkod}'").FirstOrDefault();
            if (productRow == null) return;

            int anbarMiqdari = (int)productRow["Miqdar"];
            if (anbarMiqdari <= 0)
            {
                MessageBox.Show("Bu məhsul anbarada bitib.", "Stok Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow basketRow = basketTable.Select($"Barkod = '{barkod}'").FirstOrDefault();

            if (basketRow != null)
            {
                int yeniMiqdar = (int)basketRow["Miqdar"] + 1;
                if (yeniMiqdar > anbarMiqdari)
                {
                    MessageBox.Show($"Anbarda yalnız {anbarMiqdari} ədəd var.", "Stok Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                basketRow["Miqdar"] = yeniMiqdar;
            }
            else
            {
                string ad = productRow["Ad"].ToString();
                decimal satisQiymeti = (decimal)productRow["Satış Qiyməti"];
                basketTable.Rows.Add(barkod, ad, 1, satisQiymeti);
            }

            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal yekunMebleg = 0;
            if (basketTable.Rows.Count > 0)
            {
                yekunMebleg = (decimal)basketTable.Compute("SUM(Toplam)", string.Empty);
            }
            lblYekunMebleg.Text = $"{yekunMebleg:F2} ₼";
        }

        private void btnSebetiTemizle_Click(object sender, EventArgs e)
        {
            basketTable.Clear();
            UpdateTotal();
        }

        private void btnSatisEt_Click(object sender, EventArgs e)
        {
            if (basketTable.Rows.Count == 0)
            {
                MessageBox.Show("Satış üçün səbətə məhsul əlavə edin.", "Boş Səbət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<string> encryptedProductLines = File.ReadAllLines(productsFilePath).ToList();
                List<string> decryptedProductLines = encryptedProductLines.Select(line => EncryptionHelper.Decrypt(line)).ToList();

                string salesRecord = "";
                string transactionId = Guid.NewGuid().ToString().Substring(0, 8);
                DateTime saleDate = DateTime.Now;

                foreach (DataRow row in basketTable.Rows)
                {
                    string barkod = row["Barkod"].ToString();
                    int satilanMiqdar = (int)row["Miqdar"];

                    int index = decryptedProductLines.FindIndex(line => line.Split('|')[0] == barkod);
                    if (index != -1)
                    {
                        string[] parts = decryptedProductLines[index].Split('|');
                        parts[3] = (int.Parse(parts[3]) - satilanMiqdar).ToString();
                        decryptedProductLines[index] = string.Join("|", parts);
                    }

                    string singleSaleInfo = $"{transactionId}|{saleDate:yyyy-MM-dd HH:mm:ss}|{barkod}|{row["Ad"]}|{satilanMiqdar}|{row["Qiymət"]}";
                    salesRecord += EncryptionHelper.Encrypt(singleSaleInfo) + Environment.NewLine;
                }

                var reEncryptedProductLines = decryptedProductLines.Select(line => EncryptionHelper.Encrypt(line));
                File.WriteAllLines(productsFilePath, reEncryptedProductLines);

                File.AppendAllText(salesFilePath, salesRecord);

                MessageBox.Show("Satış uğurla tamamlandı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Frm_Receipt receiptForm = new Frm_Receipt(transactionId, saleDate, basketTable);
                receiptForm.ShowDialog();

                basketTable.Clear();
                UpdateTotal();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}