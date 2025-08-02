using System;
using System.Data;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_Reports : Form
    {
        public Frm_Reports()
        {
            InitializeComponent();
        }

        private void Frm_Reports_Load(object sender, EventArgs e)
        {
            // Form yüklənəndə avtomatik olaraq son bir ayın hesabatını göstər
            dtpBaslangic.Value = DateTime.Now.AddMonths(-1);
            dtpBitis.Value = DateTime.Now;
            btnHesabatiGoster_Click(sender, e);
        }

        private void btnHesabatiGoster_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime baslangicTarix = dtpBaslangic.Value.Date;
                DateTime bitisTarix = dtpBitis.Value.Date.AddDays(1).AddTicks(-1); // Günün sonuna qədər

                DataTable salesReport = DataAccess.GetSalesReport(baslangicTarix, bitisTarix);
                dgvSalesReport.DataSource = salesReport;

                decimal umumiGelir = 0;
                decimal umumiMayaDeyeri = 0;

                foreach (DataRow row in salesReport.Rows)
                {
                    int miqdar = Convert.ToInt32(row["Miqdar"]);
                    decimal satisQiymeti = Convert.ToDecimal(row["Satış Qiyməti"]);
                    decimal alisQiymeti = row["Alış Qiyməti"] != DBNull.Value ? Convert.ToDecimal(row["Alış Qiyməti"]) : 0;

                    umumiGelir += miqdar * satisQiymeti;
                    umumiMayaDeyeri += miqdar * alisQiymeti;
                }

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