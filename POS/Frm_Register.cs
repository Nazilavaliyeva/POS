using System;
using System.IO;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_Register : Form
    {
        // İstifadəçi məlumatlarını saxlayacağımız faylın yolu
        private readonly string usersFilePath = "users.txt";

        public Frm_Register()
        {
            InitializeComponent();
        }

        private void btnQeydiyyat_Click(object sender, EventArgs e)
        {
            string istifadeciAdi = txtIstifadeciAdi.Text.Trim();
            string sifre = txtSifre.Text;
            string sifreTekrar = txtSifreTekrar.Text;

            // 1. Girişlərin boş olub olmadığını yoxlayın
            if (string.IsNullOrEmpty(istifadeciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("İstifadəçi adı və şifrə boş buraxıla bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Şifrələrin eyni olub olmadığını yoxlayın
            if (sifre != sifreTekrar)
            {
                MessageBox.Show("Şifrələr eyni deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. İstifadəçi adının artıq mövcud olub olmadığını yoxlayın
            if (File.Exists(usersFilePath))
            {
                string[] lines = File.ReadAllLines(usersFilePath);
                foreach (string line in lines)
                {
                    // Hər sətri vergüllə ayırıb istifadəçi adını yoxlayırıq
                    if (line.Split(',')[0].Equals(istifadeciAdi, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Bu istifadəçi adı artıq mövcuddur.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // 4. Yeni istifadəçini fayla yazın
            try
            {
                // Format: istifadeciAdi,sifre
                string userInfo = $"{istifadeciAdi},{sifre}";
                File.AppendAllText(usersFilePath, userInfo + Environment.NewLine);

                MessageBox.Show("Qeydiyyat uğurla tamamlandı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Qeydiyyat pəncərəsini bağlayın
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Qeydiyyat zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}