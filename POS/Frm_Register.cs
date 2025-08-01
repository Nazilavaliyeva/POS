using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_Register : Form
    {
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

            if (string.IsNullOrEmpty(istifadeciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("İstifadəçi adı və şifrə boş buraxıla bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (sifre != sifreTekrar)
            {
                MessageBox.Show("Şifrələr eyni deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (File.Exists(usersFilePath))
                {
                    var lines = File.ReadAllLines(usersFilePath);
                    foreach (var encryptedLine in lines)
                    {
                        var decryptedLine = EncryptionHelper.Decrypt(encryptedLine);
                        if (decryptedLine.Split(',')[0].Equals(istifadeciAdi, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Bu istifadəçi adı artıq mövcuddur.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(sifre);
                string userInfo = $"{istifadeciAdi},{hashedPassword}";

                // Məlumatı şifrələyib fayla yazırıq
                string encryptedUserInfo = EncryptionHelper.Encrypt(userInfo);
                File.AppendAllText(usersFilePath, encryptedUserInfo + Environment.NewLine);

                MessageBox.Show("Qeydiyyat uğurla tamamlandı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Qeydiyyat zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}