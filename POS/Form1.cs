using System;
using System.IO;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_login : Form
    {
        // İstifadəçi məlumatlarını saxlayan faylın yolu
        private readonly string usersFilePath = "users.txt";

        public Frm_login()
        {
            InitializeComponent();
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            // Form yüklənəndə heç bir xüsusi əməliyyat lazım deyil
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim(); // Boşluqları təmizləyirik
            // Soyad sahəsi artıq istifadə edilmədiyi üçün onu şərhə alırıq və ya silə bilərik.
            // string soyad = txtSoyad.Text; 
            string sifre = txtSifre.Text;

            // Giriş məlumatlarının boş olmamasını yoxlayırıq
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("İstifadəçi adı və şifrə daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Faylın mövcudluğunu yoxlayırıq
            if (!File.Exists(usersFilePath))
            {
                MessageBox.Show("Qeydiyyatdan keçmiş istifadəçi tapılmadı. Zəhmət olmasa, qeydiyyatdan keçin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool girisUqurlu = false;
            try
            {
                string[] lines = File.ReadAllLines(usersFilePath);
                foreach (string line in lines)
                {
                    string[] userCredentials = line.Split(',');
                    // Fayldakı istifadəçi adı və şifrə ilə daxil edilənləri müqayisə edirik
                    if (userCredentials.Length == 2 &&
                        userCredentials[0].Equals(ad, StringComparison.OrdinalIgnoreCase) &&
                        userCredentials[1] == sifre)
                    {
                        girisUqurlu = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Giriş nəticəsini yoxlayırıq
            if (girisUqurlu)
            {
                MessageBox.Show("Giriş uğurludur!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // POS formunu açırıq
                frmPOS posForm = new frmPOS();
                posForm.Show();

                // Login formunu gizlədirik
                this.Hide();
            }
            else
            {
                MessageBox.Show("İstifadəçi adı və ya şifrə yanlışdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Yeni əlavə etdiyimiz qeydiyyat düyməsinin click hadisəsi
        private void btnQeydiyyatOl_Click(object sender, EventArgs e)
        {
            Frm_Register registerForm = new Frm_Register();
            registerForm.ShowDialog(); // Qeydiyyat formunu yeni pəncərə kimi açır
        }

        // Çıxış düyməsinin funksionallığı
        private void btncixis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}