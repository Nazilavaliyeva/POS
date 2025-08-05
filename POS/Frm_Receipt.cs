using System;
using System.Data;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_Receipt : Form
    {
        // DÜZƏLİŞ: Konstruktor 5 arqument qəbul edəcək şəkildə yeniləndi
        public Frm_Receipt(string transactionId, DateTime saleDate, DataTable basketData, decimal discountPercentage, string paymentMethod)
        {
            InitializeComponent();

            lblSatisID.Text = transactionId;
            lblTarix.Text = saleDate.ToString("dd.MM.yyyy HH:mm:ss");
            lblOdenisNovu.Text = paymentMethod;

            decimal umumiMebleg = 0;

            foreach (DataRow row in basketData.Rows)
            {
                string ad = row["Ad"].ToString();
                int miqdar = Convert.ToInt32(row["Miqdar"]);
                decimal qiymet = Convert.ToDecimal(row["Qiymət"]);
                decimal toplam = Convert.ToDecimal(row["Toplam"]);

                ListViewItem item = new ListViewItem(ad);
                item.SubItems.Add(miqdar.ToString());
                item.SubItems.Add($"{qiymet:F2}");
                item.SubItems.Add($"{toplam:F2}");

                lvSatisDetallari.Items.Add(item);

                umumiMebleg += toplam;
            }

            decimal endirimMeblegi = umumiMebleg * (discountPercentage / 100);
            decimal yekunMebleg = umumiMebleg - endirimMeblegi;

            lblUmumiMebleg.Text = $"{umumiMebleg:F2} ₼";
            lblEndirim.Text = $"- {endirimMeblegi:F2} ₼ ({discountPercentage}%)";
            lblYekunMebleg.Text = $"{yekunMebleg:F2} ₼";
        }
    }
}