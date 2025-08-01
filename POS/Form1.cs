using System;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_login : Form
    {
        public Frm_login()
        {
            InitializeComponent();
        }

        private void Frm_login_Load(object sender, EventArgs e) { }

        private void btngiris_Click(object sender, EventArgs e)
        {
            string username = txtAd.Text.Trim();
            string password = txtSifre.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("İstifadəçi adı və şifrə daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = DataAccess.GetUser(username);

                if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
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
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
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