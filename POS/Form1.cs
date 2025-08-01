using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_login : Form
    {
        private readonly string usersFilePath = "users.txt";

        public Frm_login()
        {
            InitializeComponent();
        }

        private void Frm_login_Load(object sender, EventArgs e) { }

        private void btngiris_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            string sifre = txtSifre.Text;

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("İstifadəçi adı və şifrə daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(usersFilePath))
            {
                MessageBox.Show("Qeydiyyatdan keçmiş istifadəçi tapılmadı. Zəhmət olmasa qeydiyyatdan keçin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool girisUqurlu = false;
            try
            {
                var lines = File.ReadAllLines(usersFilePath); // DƏYİŞİKLİK: 'encryptedLines' -> 'lines'
                foreach (var line in lines) // DƏYİŞİKLİK: 'encryptedLine' -> 'line'
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // SİLİNDİ: Deşifrələmə artıq lazım deyil
                    // string decryptedLine = EncryptionHelper.Decrypt(line); 
                    string[] userCredentials = line.Split(',');

                    if (userCredentials.Length == 2 && userCredentials[0].Equals(ad, StringComparison.OrdinalIgnoreCase))
                    {
                        string savedHashedPassword = userCredentials[1];
                        if (BCrypt.Net.BCrypt.Verify(sifre, savedHashedPassword))
                        {
                            girisUqurlu = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (girisUqurlu)
            {
                MessageBox.Show("Giriş uğurludur!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmPOS posForm = new frmPOS();
                posForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("İstifadəçi adı və ya şifrə yanlışdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQeydiyyatOl_Click(object sender, EventArgs e)
        {
            Frm_Register registerForm = new Frm_Register();
            registerForm.ShowDialog();
        }

        private void btncixis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}