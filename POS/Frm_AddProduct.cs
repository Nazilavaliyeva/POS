using System;
using System.IO;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_AddProduct : Form
    {
        private readonly string productsFilePath = "products.txt";
        private readonly string categoriesFilePath = "categories.txt";

        public Frm_AddProduct()
        {
            InitializeComponent();
        }

        private void Frm_AddProduct_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        private void LoadCategories()
        {
            // Kateqoriyaları fayldan oxuyub ComboBox-a yükləyir
            try
            {
                if (File.Exists(categoriesFilePath))
                {
                    string[] categories = File.ReadAllLines(categoriesFilePath);
                    cmbKateqoriya.Items.AddRange(categories);
                }
                else
                {
                    // Fayl yoxdursa, nümunə kateqoriyalar yaradırıq
                    string[] defaultCategories = { "İçkilər", "Şirniyyat", "Qida" };
                    File.WriteAllLines(categoriesFilePath, defaultCategories);
                    cmbKateqoriya.Items.AddRange(defaultCategories);
                }

                if (cmbKateqoriya.Items.Count > 0)
                {
                    cmbKateqoriya.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kateqoriyaları yükləyərkən xəta baş verdi: {ex.Message}");
            }
        }

        private void btnYaddaSaxla_Click(object sender, EventArgs e)
        {
            // 1. Girişləri yoxlayırıq
            if (string.IsNullOrWhiteSpace(txtMehsulAd.Text) ||
                string.IsNullOrWhiteSpace(txtMiqdar.Text) ||
                string.IsNullOrWhiteSpace(txtAlisQiymeti.Text) ||
                string.IsNullOrWhiteSpace(txtSatisQiymeti.Text) ||
                cmbKateqoriya.SelectedItem == null)
            {
                MessageBox.Show("Bütün xanaları doldurun.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Rəqəm xanalarını yoxlayırıq
            if (!int.TryParse(txtMiqdar.Text, out int miqdar) ||
                !decimal.TryParse(txtAlisQiymeti.Text, out decimal alisQiymeti) ||
                !decimal.TryParse(txtSatisQiymeti.Text, out decimal satisQiymeti))
            {
                MessageBox.Show("Miqdar, Alış və Satış qiymətləri düzgün rəqəm formatında olmalıdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Məhsul məlumatlarını fayla yazırıq
            try
            {
                // Format: Ad,Miqdar,AlışQiyməti,SatışQiyməti,Kateqoriya
                string productInfo = $"{txtMehsulAd.Text},{miqdar},{alisQiymeti},{satisQiymeti},{cmbKateqoriya.SelectedItem}";
                File.AppendAllText(productsFilePath, productInfo + Environment.NewLine);

                MessageBox.Show("Məhsul uğurla əlavə edildi!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // POS formunu yeniləmək üçün DialogResult göndəririk
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsulu yadda saxlamaq mümkün olmadı: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLegvEt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}