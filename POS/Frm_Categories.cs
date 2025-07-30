using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_Categories : Form
    {
        private readonly string categoriesFilePath = "categories.txt";
        private readonly string productsFilePath = "products.txt";

        public Frm_Categories()
        {
            InitializeComponent();
        }

        private void Frm_Categories_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            lstCategories.Items.Clear();
            if (File.Exists(categoriesFilePath))
            {
                lstCategories.Items.AddRange(File.ReadAllLines(categoriesFilePath));
            }
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem != null)
            {
                txtCategoryName.Text = lstCategories.SelectedItem.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newCategory = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(newCategory))
            {
                MessageBox.Show("Kateqoriya adı boş ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstCategories.Items.Contains(newCategory))
            {
                MessageBox.Show("Bu kateqoriya artıq mövcuddur.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            File.AppendAllText(categoriesFilePath, newCategory + Environment.NewLine);
            LoadCategories();
            txtCategoryName.Clear();
            this.DialogResult = DialogResult.OK; // Ana formanın yenilənməsi üçün
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null)
            {
                MessageBox.Show("Yeniləmək üçün bir kateqoriya seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string oldCategory = lstCategories.SelectedItem.ToString();
            string newCategory = txtCategoryName.Text.Trim();

            if (string.IsNullOrEmpty(newCategory))
            {
                MessageBox.Show("Yeni kateqoriya adı boş ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstCategories.Items.Contains(newCategory) && oldCategory != newCategory)
            {
                MessageBox.Show("Bu adda kateqoriya artıq mövcuddur.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> categories = File.ReadAllLines(categoriesFilePath).ToList();
            int index = categories.FindIndex(c => c == oldCategory);
            if (index != -1)
            {
                categories[index] = newCategory;
                File.WriteAllLines(categoriesFilePath, categories);

                // Məhsullar faylında da bu kateqoriyanı yeniləyirik
                UpdateCategoryInProducts(oldCategory, newCategory);

                LoadCategories();
                txtCategoryName.Clear();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void UpdateCategoryInProducts(string oldCategory, string newCategory)
        {
            if (!File.Exists(productsFilePath)) return;

            List<string> productLines = File.ReadAllLines(productsFilePath).ToList();
            bool updated = false;

            for (int i = 0; i < productLines.Count; i++)
            {
                string[] parts = productLines[i].Split('|');
                if (parts.Length == 11 && parts[9] == oldCategory)
                {
                    parts[9] = newCategory;
                    productLines[i] = string.Join("|", parts);
                    updated = true;
                }
            }

            if (updated)
            {
                File.WriteAllLines(productsFilePath, productLines);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem == null)
            {
                MessageBox.Show("Silmək üçün bir kateqoriya seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string categoryToDelete = lstCategories.SelectedItem.ToString();

            // Məhsullar faylında bu kateqoriyanın istifadə edilib-edilmədiyini yoxlayırıq
            if (File.Exists(productsFilePath))
            {
                bool isUsed = File.ReadAllLines(productsFilePath)
                                  .Any(line => line.Split('|').Length == 11 && line.Split('|')[9] == categoryToDelete);
                if (isUsed)
                {
                    MessageBox.Show("Bu kateqoriya məhsullarda istifadə edildiyi üçün silinə bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (MessageBox.Show($"'{categoryToDelete}' kateqoriyasını silməyə əminsiniz?", "Silməni təsdiqlə", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> categories = File.ReadAllLines(categoriesFilePath).ToList();
                categories.Remove(categoryToDelete);
                File.WriteAllLines(categoriesFilePath, categories);
                LoadCategories();
                txtCategoryName.Clear();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}