using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_Reports : Form
    {
        private readonly string productsFilePath = "products.txt";
        private readonly string salesFilePath = "sales.txt";
        private DataTable salesTable = new DataTable();

        public Frm_Reports()
        {
            InitializeComponent();
        }

        private void Frm_Reports_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            // Load the report for the last month automatically when the form loads
            dtpBaslangic.Value = DateTime.Now.AddMonths(-1);
            dtpBitis.Value = DateTime.Now;
            btnHesabatiGoster_Click(sender, e);
        }

        private void SetupDataGridView()
        {
            salesTable.Columns.Add("Satış ID", typeof(string));
            salesTable.Columns.Add("Tarix", typeof(DateTime));
            salesTable.Columns.Add("Məhsul Adı", typeof(string));
            salesTable.Columns.Add("Miqdar", typeof(int));
            salesTable.Columns.Add("Satış Qiyməti", typeof(decimal));
            salesTable.Columns.Add("Ümumi Məbləğ", typeof(decimal));

            dgvSalesReport.DataSource = salesTable;
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnHesabatiGoster_Click(object sender, EventArgs e)
        {
            salesTable.Clear();

            if (!File.Exists(salesFilePath) || !File.Exists(productsFilePath))
            {
                MessageBox.Show("Satış və ya məhsul məlumatları tapılmadı.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Gather purchase prices of products into a dictionary
                var productCosts = File.ReadAllLines(productsFilePath)
                    .Select(line => EncryptionHelper.Decrypt(line))
                    .Select(line => line.Split('|'))
                    .Where(parts => parts.Length == 11)
                    .ToDictionary(parts => parts[1], parts => decimal.Parse(parts[7])); // Key: Ad, Value: Alış Qiyməti

                var encryptedSalesLines = File.ReadAllLines(salesFilePath);

                decimal umumiGelir = 0;
                decimal umumiMayaDeyeri = 0;

                DateTime baslangicTarix = dtpBaslangic.Value.Date;
                DateTime bitisTarix = dtpBitis.Value.Date.AddDays(1).AddTicks(-1); // Until the end of the day

                foreach (string encryptedLine in encryptedSalesLines)
                {
                    string line = EncryptionHelper.Decrypt(encryptedLine);
                    string[] parts = line.Split('|');
                    // Format: TransactionID|Date|Barkod|ProductName|Quantity|SalePrice
                    if (parts.Length == 6)
                    {
                        DateTime satisTarixi = DateTime.Parse(parts[1]);

                        if (satisTarixi >= baslangicTarix && satisTarixi <= bitisTarix)
                        {
                            string mehsulAdi = parts[3];
                            int miqdar = int.Parse(parts[4]);
                            decimal satisQiymeti = decimal.Parse(parts[5]);
                            decimal toplamMebleg = miqdar * satisQiymeti;

                            // Add to the table
                            salesTable.Rows.Add(parts[0], satisTarixi, mehsulAdi, miqdar, satisQiymeti, toplamMebleg);

                            // Sum up the figures for the report
                            umumiGelir += toplamMebleg;
                            if (productCosts.ContainsKey(mehsulAdi))
                            {
                                umumiMayaDeyeri += miqdar * productCosts[mehsulAdi];
                            }
                        }
                    }
                }

                // Display the final numbers
                lblUmumiGelir.Text = $"{umumiGelir:F2} ₼";
                lblMayaDeyeri.Text = $"{umumiMayaDeyeri:F2} ₼";
                lblXalisQazanc.Text = $"{(umumiGelir - umumiMayaDeyeri):F2} ₼";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hesabatı hazırlayarkən xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}