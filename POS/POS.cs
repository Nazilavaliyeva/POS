using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class frmPOS : Form
    {
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
        }

        private void LoadProducts()
        {
            try
            {
                productTable = DataAccess.GetProductsForDisplay();
                dgvProducts.DataSource = productTable;
                if (dgvProducts.Columns.Contains("MinStock"))
                    dgvProducts.Columns["MinStock"].Visible = false;
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
                if (row.Cells["Miqdar"].Value == null || row.Cells["MinStock"].Value == null) continue;

                int miqdar = Convert.ToInt32(row.Cells["Miqdar"].Value);
                int minStok = Convert.ToInt32(row.Cells["MinStock"].Value);

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
                var categories = DataAccess.GetAllCategories();
                foreach (var cat in categories)
                {
                    cmbKateqoriyaFilter.Items.Add(cat.Name);
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
            using (Frm_ProductDetails addProductForm = new Frm_ProductDetails())
            {
                if (addProductForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Redaktə etmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedBarcode = dgvProducts.SelectedRows[0].Cells["Barkod"].Value.ToString();
            using (Frm_ProductDetails updateForm = new Frm_ProductDetails(selectedBarcode))
            {
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                    FilterProducts();
                }
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
                    DataAccess.DeleteProduct(selectedBarcode);
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
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];
                string barkod = row.Cells["Barkod"].Value.ToString();
                AddToBasket(barkod);
            }
        }

        private void FilterProducts()
        {
            DataView dv = productTable.DefaultView;
            string filter = "";

            if (!string.IsNullOrEmpty(txtAxtaris.Text))
            {
                string safeSearch = txtAxtaris.Text.Replace("'", "''");
                filter += $"Ad LIKE '%{safeSearch}%' OR Barkod LIKE '%{safeSearch}%'";
            }

            if (cmbKateqoriyaFilter.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                string safeCategory = cmbKateqoriyaFilter.SelectedItem.ToString().Replace("'", "''");
                filter += $"Kateqoriya = '{safeCategory}'";
            }
            dv.RowFilter = filter;
        }

        private void txtAxtaris_TextChanged(object sender, EventArgs e) => FilterProducts();
        private void cmbKateqoriyaFilter_SelectedIndexChanged(object sender, EventArgs e) => FilterProducts();

        private void btnKateqoriyalar_Click(object sender, EventArgs e)
        {
            using (Frm_Categories categoriesForm = new Frm_Categories())
            {
                if (categoriesForm.ShowDialog() == DialogResult.OK)
                {
                    LoadCategoriesFilter();
                    LoadProducts();
                }
            }
        }

        private void AddToBasket(string barkod)
        {
            DataRow productRow = productTable.AsEnumerable().FirstOrDefault(r => r.Field<string>("Barkod") == barkod);
            if (productRow == null) return;

            int anbarMiqdari = productRow.Field<int>("Miqdar");
            if (anbarMiqdari <= 0)
            {
                MessageBox.Show("Bu məhsul anbarda bitib.", "Stok Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow basketRow = basketTable.AsEnumerable().FirstOrDefault(r => r.Field<string>("Barkod") == barkod);

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
                basketTable.Rows.Add(barkod, productRow["Ad"], 1, productRow["Satış Qiyməti"]);
            }
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal yekunMebleg = 0;
            if (basketTable.Rows.Count > 0)
            {
                yekunMebleg = Convert.ToDecimal(basketTable.Compute("SUM(Toplam)", string.Empty));
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
                string transactionId = Guid.NewGuid().ToString().Substring(0, 8);
                DataAccess.ProcessSale(basketTable.Copy(), transactionId);

                MessageBox.Show("Satış uğurla tamamlandı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (Frm_Receipt receiptForm = new Frm_Receipt(transactionId, DateTime.Now, basketTable.Copy()))
                {
                    receiptForm.ShowDialog();
                }

                basketTable.Clear();
                UpdateTotal();
                LoadProducts(); // Stok yeniləndiyi üçün məhsul siyahısını yeniləyirik
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hələlik uyğunlaşdırılmayıb:
        private void btnHesabatlar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hesabatlar modulu verilənlər bazasına uyğunlaşdırılmalıdır.");
        }
        private void btnGeriQaytarma_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Qaytarma modulu verilənlər bazasına uyğunlaşdırılmalıdır.");
        }
    }
}