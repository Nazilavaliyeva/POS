using System;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_Categories : Form
    {
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
            try
            {
                lstCategories.DataSource = null; // Mənbəni sıfırlayırıq
                lstCategories.DataSource = DataAccess.GetAllCategories();
                lstCategories.DisplayMember = "Name";
                lstCategories.ValueMember = "Id";
                lstCategories.SelectedItem = null;
                txtCategoryName.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kateqoriyaları yükləyərkən xəta baş verdi: {ex.Message}");
            }
        }

        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem is Category selectedCategory)
            {
                txtCategoryName.Text = selectedCategory.Name;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string newCategoryName = txtCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(newCategoryName))
            {
                MessageBox.Show("Kateqoriya adı boş ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataAccess.AddCategory(newCategoryName);
                LoadCategories();
                this.DialogResult = DialogResult.OK; // Əsas formanın yenilənməsi üçün
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kateqoriya əlavə edilərkən xəta baş verdi (ola bilsin ki, bu ad artıq mövcuddur): {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem is Category selectedCategory)
            {
                string newCategoryName = txtCategoryName.Text.Trim();
                if (string.IsNullOrEmpty(newCategoryName))
                {
                    MessageBox.Show("Yeni kateqoriya adı boş ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    DataAccess.UpdateCategory(selectedCategory.Id, newCategoryName);
                    LoadCategories();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kateqoriya yenilənərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Yeniləmək üçün bir kateqoriya seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedItem is Category selectedCategory)
            {
                try
                {
                    if (DataAccess.IsCategoryInUse(selectedCategory.Id))
                    {
                        MessageBox.Show("Bu kateqoriya məhsullarda istifadə edildiyi üçün silinə bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (MessageBox.Show($"'{selectedCategory.Name}' kateqoriyasını silməyə əminsinizmi?", "Silməni təsdiqlə", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DataAccess.DeleteCategory(selectedCategory.Id);
                        LoadCategories();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kateqoriya silinərkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Silmək üçün bir kateqoriya seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}