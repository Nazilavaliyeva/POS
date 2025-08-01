using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing; // DÜZƏLİŞ: Bu sətir əlavə edildi

namespace POS
{
    public partial class Frm_ProductDetails : Form
    {
        private readonly string imagesFolderPath = "images";
        private string originalBarcode;
        private string currentImagePath;
        public bool IsEditMode { get; private set; }

        public Frm_ProductDetails()
        {
            InitializeComponent();
            IsEditMode = false;
            this.Text = "Yeni Məhsul Əlavə Et";
        }

        public Frm_ProductDetails(string barcodeToEdit)
        {
            InitializeComponent();
            IsEditMode = true;
            this.Text = "Məhsulu Redaktə Et";
            originalBarcode = barcodeToEdit;
        }

        private void Frm_ProductDetails_Load(object sender, EventArgs e)
        {
            LoadCategories();
            if (cmbOlcuVahidi.Items.Count > 0 && cmbOlcuVahidi.SelectedItem == null)
            {
                cmbOlcuVahidi.SelectedIndex = 0;
            }

            if (IsEditMode)
            {
                LoadProductData(originalBarcode);
            }
        }

        private void LoadProductData(string barcode)
        {
            try
            {
                Product product = DataAccess.GetProductByBarcode(barcode);
                if (product != null)
                {
                    txtBarkod.Text = product.Barcode;
                    txtMehsulAd.Text = product.Name;
                    txtTevsir.Text = product.Description;
                    numMiqdar.Value = product.Quantity;
                    numMinStok.Value = product.MinStock;
                    cmbOlcuVahidi.SelectedItem = product.Unit;
                    txtAlisQiymeti.Text = product.PurchasePrice.ToString("F2");
                    txtSatisQiymeti.Text = product.SalePrice.ToString("F2");

                    // DÜZƏLİŞ: Nullable int? yoxlanılır
                    if (product.CategoryId.HasValue)
                    {
                        cmbKateqoriya.SelectedValue = product.CategoryId.Value;
                    }

                    currentImagePath = product.ImagePath;
                    if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                    {
                        picMehsulSekli.Image = Image.FromFile(currentImagePath);
                    }
                }
                else
                {
                    MessageBox.Show("Məhsul tapılmadı.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məhsul məlumatları yüklənərkən xəta baş verdi: {ex.Message}");
            }
        }

        private void LoadCategories()
        {
            try
            {
                cmbKateqoriya.DataSource = DataAccess.GetAllCategories();
                cmbKateqoriya.DisplayMember = "Name";
                cmbKateqoriya.ValueMember = "Id";
                cmbKateqoriya.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kateqoriyaları yükləyərkən xəta baş verdi: {ex.Message}");
            }
        }

        private void btnSekilSec_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    picMehsulSekli.Image = Image.FromFile(currentImagePath);
                }
            }
        }

        private void btnYaddaSaxla_Click(object sender, EventArgs e)
        {
            // ... (Əvvəlki cavabdakı kimi, bu metodda dəyişiklik yoxdur) ...
            if (string.IsNullOrWhiteSpace(txtBarkod.Text) ||
               string.IsNullOrWhiteSpace(txtMehsulAd.Text) ||
               !decimal.TryParse(txtAlisQiymeti.Text, out _) ||
               !decimal.TryParse(txtSatisQiymeti.Text, out _))
            {
                MessageBox.Show("Barkod, Ad, Alış və Satış qiyməti xanaları düzgün doldurulmalıdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string finalImagePath = currentImagePath;
            if (!string.IsNullOrEmpty(finalImagePath) && File.Exists(finalImagePath) && !finalImagePath.StartsWith(imagesFolderPath, StringComparison.OrdinalIgnoreCase))
            {
                if (!Directory.Exists(imagesFolderPath)) Directory.CreateDirectory(imagesFolderPath);
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(finalImagePath);
                finalImagePath = Path.Combine(imagesFolderPath, newFileName);
                File.Copy(currentImagePath, finalImagePath, true);
            }
            else if (string.IsNullOrEmpty(finalImagePath))
            {
                finalImagePath = "N/A";
            }

            var product = new Product
            {
                Barcode = txtBarkod.Text.Trim(),
                Name = txtMehsulAd.Text.Trim(),
                Description = txtTevsir.Text.Trim(),
                Quantity = (int)numMiqdar.Value,
                MinStock = (int)numMinStok.Value,
                Unit = cmbOlcuVahidi.SelectedItem?.ToString(),
                PurchasePrice = decimal.Parse(txtAlisQiymeti.Text),
                SalePrice = decimal.Parse(txtSatisQiymeti.Text),
                ImagePath = finalImagePath,
                CategoryId = (int?)cmbKateqoriya.SelectedValue // DÜZƏLİŞ: int? tipinə çevrilir
            };

            try
            {
                if (IsEditMode)
                {
                    if (originalBarcode != product.Barcode && DataAccess.GetProductByBarcode(product.Barcode) != null)
                    {
                        MessageBox.Show("Daxil etdiyiniz yeni barkod başqa bir məhsulda mövcuddur.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataAccess.UpdateProduct(product, originalBarcode);
                }
                else
                {
                    if (DataAccess.GetProductByBarcode(product.Barcode) != null)
                    {
                        MessageBox.Show("Bu barkod artıq mövcuddur.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataAccess.AddProduct(product);
                }

                MessageBox.Show("Məlumatlar uğurla yadda saxlanıldı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məlumatları yadda saxlayarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLegvEt_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}