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
        private readonly string productsFilePath = "products.txt";
        private readonly string categoriesFilePath = "categories.txt";
        private DataTable productTable = new DataTable();

        public frmPOS()
        {
            InitializeComponent();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadProducts();
            LoadCategoriesFilter();
        }

        private void SetupDataGridView()
        {
            productTable.Columns.Add("Barkod", typeof(string));
            productTable.Columns.Add("Ad", typeof(string));
            productTable.Columns.Add("Miqdar", typeof(int));
            productTable.Columns.Add("Alış Qiyməti", typeof(decimal));
            productTable.Columns.Add("Satış Qiyməti", typeof(decimal));
            productTable.Columns.Add("Kateqoriya", typeof(string));
            productTable.Columns.Add("Min. Stok", typeof(int));
            productTable.Columns.Add("Ölçü Vahidi", typeof(string));

            dgvProducts.DataSource = productTable;
            dgvProducts.ReadOnly = true;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                        productTable.Rows.Add(parts[0], parts[1], int.Parse(parts[3]), decimal.Parse(parts[7]), decimal.Parse(parts[8]), parts[9], int.Parse(parts[4]), parts[5]);
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
            Frm_ProductDetails addProductForm = new Frm_ProductDetails();
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
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

        // Bu düyməni dizayna əlavə etdikdən sonra bu hadisəni yaradın
        private void btnYenile_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Yeniləmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

        // DataGridView-də sətirə iki dəfə klikləməklə də redaktəni açaq
        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // btnYenile_Click ilə eyni məntiqi çağırırıq
            if (e.RowIndex >= 0) // Başlıq sətrinə kliklənmədiyindən əmin oluruq
            {
                btnYenile_Click(sender, e);
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
    }
}