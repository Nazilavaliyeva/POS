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
                var encryptedLines = File.ReadAllLines(categoriesFilePath);
                foreach (var encryptedLine in encryptedLines)
                {
                    // Boş sətirləri nəzərə almamaq üçün
                    if (!string.IsNullOrWhiteSpace(encryptedLine))
                    {
                        lstCategories.Items.Add(EncryptionHelper.Decrypt(encryptedLine));
                    }
                }
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

            string encryptedCategory = EncryptionHelper.Encrypt(newCategory);
            File.AppendAllText(categoriesFilePath, encryptedCategory + Environment.NewLine);
            LoadCategories();
            txtCategoryName.Clear();
            this.DialogResult = DialogResult.OK;
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

            List<string> categories = new List<string>();
            foreach (var item in lstCategories.Items)
            {
                categories.Add(item.ToString());
            }

            int index = categories.FindIndex(c => c == oldCategory);
            if (index != -1)
            {
                categories[index] = newCategory;

                var encryptedCategories = categories.Select(c => EncryptionHelper.Encrypt(c));
                File.WriteAllLines(categoriesFilePath, encryptedCategories);

                UpdateCategoryInProducts(oldCategory, newCategory);

                LoadCategories();
                txtCategoryName.Clear();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void UpdateCategoryInProducts(string oldCategory, string newCategory)
        {
            if (!File.Exists(productsFilePath)) return;

            List<string> encryptedLines = File.ReadAllLines(productsFilePath).ToList();
            List<string> decryptedLines = encryptedLines.Select(line => EncryptionHelper.Decrypt(line)).ToList();
            bool updated = false;

            for (int i = 0; i < decryptedLines.Count; i++)
            {
                string[] parts = decryptedLines[i].Split('|');
                // DÜZƏLİŞ: Məhsul sətrinin formatını yoxlayırıq.
                if (parts.Length == 11 && parts[9] == oldCategory)
                {
                    parts[9] = newCategory;
                    decryptedLines[i] = string.Join("|", parts);
                    updated = true;
                }
            }

            if (updated)
            {
                var reEncryptedLines = decryptedLines.Select(line => EncryptionHelper.Encrypt(line));
                File.WriteAllLines(productsFilePath, reEncryptedLines);
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

            if (File.Exists(productsFilePath))
            {
                // DÜZƏLİŞ: Məhsul sətrinin formatını yoxlayırıq.
                bool isUsed = File.ReadAllLines(productsFilePath)
                                  .Select(line => EncryptionHelper.Decrypt(line))
                                  .Any(decryptedLine =>
                                       decryptedLine.Split('|').Length == 11 &&
                                       decryptedLine.Split('|')[9] == categoryToDelete);
                if (isUsed)
                {
                    MessageBox.Show("Bu kateqoriya məhsullarda istifadə edildiyi üçün silinə bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (MessageBox.Show($"'{categoryToDelete}' kateqoriyasını silməyə əminsiniz?", "Silməni təsdiqlə", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> categories = new List<string>();
                foreach (var item in lstCategories.Items)
                {
                    categories.Add(item.ToString());
                }

                categories.Remove(categoryToDelete);
                var encryptedCategories = categories.Select(c => EncryptionHelper.Encrypt(c));
                File.WriteAllLines(categoriesFilePath, encryptedCategories);

                LoadCategories();
                txtCategoryName.Clear();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}