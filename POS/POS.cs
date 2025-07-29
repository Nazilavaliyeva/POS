using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class frmPOS : Form
    {
        // Faylların yolları
        private readonly string productsFilePath = "products.txt";
        private readonly string categoriesFilePath = "categories.txt";
        private readonly string salesFilePath = "sales.txt";

        // Məlumatları saxlamaq üçün DataTable-lar
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

        // Bu metod designer.cs faylındakı xətanı aradan qaldırmaq üçün əlavə edilib.
        // Artıq istifadə edilmədiyi üçün içi boşdur.
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Bu metod artıq istifadə edilmir.
        }

        private void SetupDataTables()
        {
            // Məhsul cədvəlinin sütunları
            productTable.Columns.Add("Barkod", typeof(string));
            productTable.Columns.Add("Ad", typeof(string));
            productTable.Columns.Add("Miqdar", typeof(int));
            productTable.Columns.Add("Satış Qiyməti", typeof(decimal));
            productTable.Columns.Add("Kateqoriya", typeof(string));

            dgvProducts.DataSource = productTable;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Səbət cədvəlinin sütunları
            basketTable.Columns.Add("Barkod", typeof(string));
            basketTable.Columns.Add("Ad", typeof(string));
            basketTable.Columns.Add("Miqdar", typeof(int));
            basketTable.Columns.Add("Qiymət", typeof(decimal));
            basketTable.Columns.Add("Toplam", typeof(decimal), "Miqdar * Qiymət"); // Avtomatik hesablanan sütun

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
                string[] lines = File.ReadAllLines(productsFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 11) // 11 sahə olmalıdır
                    {
                        productTable.Rows.Add(parts[0], parts[1], int.Parse(parts[3]), decimal.Parse(parts[8]), parts[9]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsulları yükləyərkən xəta baş verdi: {ex.Message}");
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
                    cmbKateqoriyaFilter.Items.AddRange(File.ReadAllLines(categoriesFilePath));
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
            // Frm_ProductDetails olaraq dəyişdirdik
            Frm_ProductDetails addProductForm = new Frm_ProductDetails();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts(); // Cədvəli yenilə
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Yeniləmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EditSelectedProduct();
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Səbətə əlavə et
                DataRowView selectedRow = (DataRowView)dgvProducts.Rows[e.RowIndex].DataBoundItem;
                string barkod = selectedRow["Barkod"].ToString();
                AddToBasket(barkod);
            }
        }

        private void EditSelectedProduct()
        {
            if (dgvProducts.SelectedRows.Count == 0) return;

            try
            {
                string selectedBarcode = dgvProducts.SelectedRows[0].Cells["Barkod"].Value.ToString();
                string[] lines = File.ReadAllLines(productsFilePath);
                string productLine = lines.FirstOrDefault(line => line.Split('|')[0] == selectedBarcode);

                if (productLine != null)
                {
                    Frm_ProductDetails updateForm = new Frm_ProductDetails(productLine.Split('|'));
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
                    List<string> lines = File.ReadAllLines(productsFilePath).ToList();
                    lines.RemoveAll(line => line.Split('|')[0] == selectedBarcode);
                    File.WriteAllLines(productsFilePath, lines);
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Məhsulu silərkən xəta baş verdi: {ex.Message}");
                }
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

        // --- SATIŞ MODULU FUNKSİYALARI ---

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

            if (basketRow != null) // Məhsul artıq səbətdədirsə
            {
                int yeniMiqdar = (int)basketRow["Miqdar"] + 1;
                if (yeniMiqdar > anbarMiqdari)
                {
                    MessageBox.Show($"Anbarda yalnız {anbarMiqdari} ədəd var.", "Stok Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                basketRow["Miqdar"] = yeniMiqdar;
            }
            else // Məhsul səbətə yeni əlavə olunursa
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
                List<string> productLines = File.ReadAllLines(productsFilePath).ToList();
                string salesRecord = "";

                string transactionId = Guid.NewGuid().ToString(); // Unikal satış ID-si
                DateTime saleDate = DateTime.Now;

                // Səbətdəki hər məhsul üçün stoku azaldırıq
                foreach (DataRow row in basketTable.Rows)
                {
                    string barkod = row["Barkod"].ToString();
                    int satilanMiqdar = (int)row["Miqdar"];

                    int index = productLines.FindIndex(line => line.Split('|')[0] == barkod);
                    if (index != -1)
                    {
                        string[] parts = productLines[index].Split('|');
                        int yeniMiqdar = int.Parse(parts[3]) - satilanMiqdar;
                        parts[3] = yeniMiqdar.ToString();
                        productLines[index] = string.Join("|", parts);
                    }
                    // Satışın qeydini hazırlayırıq
                    salesRecord += $"{transactionId}|{saleDate:yyyy-MM-dd HH:mm:ss}|{row["Ad"]}|{satilanMiqdar}|{row["Qiymət"]}{Environment.NewLine}";
                }

                // Yenilənmiş məhsul siyahısını fayla yazırıq
                File.WriteAllLines(productsFilePath, productLines);

                // Satışı fayla əlavə edirik
                File.AppendAllText(salesFilePath, salesRecord);

                MessageBox.Show("Satış uğurla tamamlandı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Səbəti təmizləyirik və məhsul siyahısını yeniləyirik
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