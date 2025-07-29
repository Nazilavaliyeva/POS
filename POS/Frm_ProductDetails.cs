using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_ProductDetails : Form
    {
        private readonly string productsFilePath = "products.txt";
        private readonly string categoriesFilePath = "categories.txt";
        private readonly string imagesFolderPath = "images";

        // Redaktə rejimi üçün məhsulun orijinal barkodunu saxlayır
        private readonly string originalBarcode;
        public bool IsEditMode { get; private set; }

        // Yeni məhsul əlavə etmək üçün konstruktor
        public Frm_ProductDetails()
        {
            InitializeComponent();
            IsEditMode = false;
            this.Text = "Yeni Məhsul Əlavə Et";
        }

        // Məhsulu redaktə etmək üçün konstruktor
        public Frm_ProductDetails(string[] productData)
        {
            InitializeComponent();
            IsEditMode = true;
            this.Text = "Məhsulu Redaktə Et";

            // Mövcud məlumatları formadakı sahələrə doldururuq
            originalBarcode = productData[0];
            txtBarkod.Text = productData[0];
            txtMehsulAd.Text = productData[1];
            txtTevsir.Text = productData[2];
            numMiqdar.Value = int.Parse(productData[3]);
            numMinStok.Value = int.Parse(productData[4]);
            cmbOlcuVahidi.SelectedItem = productData[5];
            dtpIstehsalTarixi.Value = DateTime.Parse(productData[6]);
            txtAlisQiymeti.Text = productData[7];
            txtSatisQiymeti.Text = productData[8];
            cmbKateqoriya.SelectedItem = productData[9];

            // Şəkli yükləyirik
            string imagePath = productData[10];
            if (File.Exists(imagePath))
            {
                picMehsulSekli.ImageLocation = imagePath;
            }
        }


        private void Frm_ProductDetails_Load(object sender, EventArgs e)
        {
            LoadCategories();
            if (cmbOlcuVahidi.Items.Count > 0 && cmbOlcuVahidi.SelectedItem == null)
            {
                cmbOlcuVahidi.SelectedIndex = 0;
            }
        }

        private void LoadCategories()
        {
            try
            {
                if (File.Exists(categoriesFilePath))
                {
                    cmbKateqoriya.Items.AddRange(File.ReadAllLines(categoriesFilePath));
                }
                else
                {
                    string[] defaultCategories = { "İçkilər", "Şirniyyat", "Qida" };
                    File.WriteAllLines(categoriesFilePath, defaultCategories);
                    cmbKateqoriya.Items.AddRange(defaultCategories);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kateqoriyaları yükləyərkən xəta baş verdi: {ex.Message}");
            }
        }

        private void btnSekilSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picMehsulSekli.ImageLocation = ofd.FileName;
            }
        }

        private void btnYaddaSaxla_Click(object sender, EventArgs e)
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(txtBarkod.Text) ||
                string.IsNullOrWhiteSpace(txtMehsulAd.Text) ||
                !decimal.TryParse(txtAlisQiymeti.Text, out _) ||
                !decimal.TryParse(txtSatisQiymeti.Text, out _))
            {
                MessageBox.Show("Barkod, Ad, Alış və Satış qiyməti xanaları düzgün doldurulmalıdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Şəklin yadda saxlanması
            string imagePath = picMehsulSekli.ImageLocation;
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                // Şəkillər üçün qovluq mövcud deyilsə yaradırıq
                if (!Directory.Exists(imagesFolderPath))
                {
                    Directory.CreateDirectory(imagesFolderPath);
                }
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(imagePath);
                string newPath = Path.Combine(imagesFolderPath, newFileName);
                File.Copy(imagePath, newPath);
                imagePath = newPath; // Yeni yolu mənimsədirik
            }
            else
            {
                imagePath = "N/A"; // Şəkil yoxdursa
            }


            // Məlumatları formatlaşdırırıq
            string productInfo = string.Join("|",
                txtBarkod.Text,
                txtMehsulAd.Text,
                txtTevsir.Text,
                numMiqdar.Value,
                numMinStok.Value,
                cmbOlcuVahidi.SelectedItem,
                dtpIstehsalTarixi.Value.ToString("yyyy-MM-dd"),
                txtAlisQiymeti.Text,
                txtSatisQiymeti.Text,
                cmbKateqoriya.SelectedItem,
                imagePath
            );

            try
            {
                List<string> lines = new List<string>();
                if (File.Exists(productsFilePath))
                {
                    lines = File.ReadAllLines(productsFilePath).ToList();
                }

                if (IsEditMode)
                {
                    // Redaktə rejimi
                    int index = lines.FindIndex(line => line.Split('|')[0] == originalBarcode);
                    if (index != -1)
                    {
                        lines[index] = productInfo;
                    }
                }
                else
                {
                    // Əlavə etmə rejimi
                    // Barkodun unikal olub-olmadığını yoxlayırıq
                    if (lines.Any(line => line.Split('|')[0].Equals(txtBarkod.Text, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Bu barkod artıq mövcuddur.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    lines.Add(productInfo);
                }

                File.WriteAllLines(productsFilePath, lines);
                MessageBox.Show("Məlumatlar uğurla yadda saxlanıldı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məlumatları yadda saxlayarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}