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
            try
            {
                lstCategories.Items.Clear();
                if (File.Exists(categoriesFilePath))
                {
                    var encryptedLines = File.ReadAllLines(categoriesFilePath);
                    foreach (var encryptedLine in encryptedLines)
                    {
                        // Boş sətrləri nəzərə almamaq üçün yoxlama
                        if (!string.IsNullOrWhiteSpace(encryptedLine))
                        {
                            lstCategories.Items.Add(EncryptionHelper.Decrypt(encryptedLine));
                        }
                    }
                }
            }
            catch (Exception