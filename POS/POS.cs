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
            // DataTable üçün sütunları yaradırıq
            productTable.Columns.Add("Ad", typeof(string));
            productTable.Columns.Add("Miqdar", typeof(int));
            productTable.Columns.Add("Alış Qiyməti", typeof(decimal));
            productTable.Columns.Add("Satış Qiyməti", typeof(decimal));
            productTable.Columns.Add("Kateqoriya", typeof(string));

            // DataGridView-i DataTable-a bağlayırıq
            dgvProducts.DataSource = productTable;
        }

        private void LoadProducts()
        {
            productTable.Clear(); // Cədvəli təmizləyirik

            if (!File.Exists(productsFilePath)) return;

            try
            {
                string[] lines = File.ReadAllLines(productsFilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 5)
                    {
                        productTable.Rows.Add(parts[0], int.Parse(parts[1]), decimal.Parse(parts[2]), decimal.Parse(parts[3]), parts[4]);
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
                cmbKateqoriyaFilter.Items.Add("Bütün Kateqoriyalar"); // Filtr üçün default seçim

                if (File.Exists(categoriesFilePath))
                {
                    string[] categories = File.ReadAllLines(categoriesFilePath);
                    cmbKateqoriyaFilter.Items.AddRange(categories);
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
            Frm_AddProduct addProductForm = new Frm_AddProduct();
            // Yeni məhsul əlavə edildikdə cədvəli yeniləmək üçün
            if (addProductForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts(); // Cədvəli yenilə
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // Seçilmiş sətir yoxdursa, heç nə etmə
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Silməni təsdiqləmək üçün soruşuruq
            if (MessageBox.Show("Seçilmiş məhsulu silməyə əminsiniz?", "Silməni Təsdiqlə", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Seçilmiş sətrin adını alırıq
                    string selectedProductName = dgvProducts.SelectedRows[0].Cells["Ad"].Value.ToString();

                    // Fayldakı bütün məhsulları oxuyuruq
                    List<string> lines = File.ReadAllLines(productsFilePath).ToList();

                    // Silinəcək məhsulu tapıb siyahıdan çıxarırıq
                    lines.RemoveAll(line => line.Split(',')[0].Equals(selectedProductName, StringComparison.OrdinalIgnoreCase));

                    // Faylı yenilənmiş siyahı ilə yenidən yazırıq
                    File.WriteAllLines(productsFilePath, lines);

                    // Cədvəli yeniləyirik
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
            string axtarisSozu = txtAxtaris.Text.ToLower();
            string secilmisKateqoriya = cmbKateqoriyaFilter.SelectedItem.ToString();

            // DataView istifadə edərək DataTable üzərində filtrasiya edirik
            DataView dv = productTable.DefaultView;

            string filterExpression = "";

            // Ada görə axtarış
            if (!string.IsNullOrEmpty(axtarisSozu))
            {
                filterExpression += $"Ad LIKE '%{axtarisSozu}%'";
            }

            // Kateqoriyaya görə axtarış
            if (secilmisKateqoriya != "Bütün Kateqoriyalar")
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += $"Kateqoriya = '{secilmisKateqoriya}'";
            }

            dv.RowFilter = filterExpression;
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