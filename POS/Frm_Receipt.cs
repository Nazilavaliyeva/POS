using System;
using System.Data;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_Receipt : Form
    {
        public Frm_Receipt(string transactionId, DateTime saleDate, DataTable basketData)
        {
            InitializeComponent();

            // Satış məlumatlarını müvafiq labellərə yazırıq
            lblSatisID.Text = transactionId;
            lblTarix.Text = saleDate.ToString("dd.MM.yyyy HH:mm:ss");

            decimal yekunMebleg = 0;

            // Səbətdəki hər bir məhsulu ListView-ə əlavə edirik
            foreach (DataRow row in basketData.Rows)
            {
                string ad = row["Ad"].ToString();
                int miqdar = Convert.ToInt32(row["Miqdar"]);
                decimal qiymet = Convert.ToDecimal(row["Qiymət"]);
                decimal toplam = Convert.ToDecimal(row["Toplam"]);

                // ListView üçün sətir yaradırıq
                ListViewItem item = new ListViewItem(ad);
                item.SubItems.Add(miqdar.ToString());
                item.SubItems.Add($"{qiymet:F2}");
                item.SubItems.Add($"{toplam:F2}");

                lvSatisDetallari.Items.Add(item);

                yekunMebleg += toplam;
            }

            // Yekun məbləği göstəririk
            lblYekunMebleg.Text = $"{yekunMebleg:F2} ₼";
        }
    }
}