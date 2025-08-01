using System;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_Register : Form
    {
        public Frm_Register()
        {
            InitializeComponent();
        }

        private void btnQeydiyyat_Click(object sender, EventArgs e)
        {
            string username = txtIstifadeciAdi.Text.Trim();
            string password = txtSifre.Text;
            string passwordRepeat = txtSifreTekrar.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("İstifadəçi adı və şifrə boş buraxıla bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != passwordRepeat)
            {
                MessageBox.Show("Şifrələr eyni deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (DataAccess.UserExists(username))
                {
                    MessageBox.Show("Bu istifadəçi adı artıq mövcuddur.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                var newUser = new User { Username = username, PasswordHash = hashedPassword };
                DataAccess.AddUser(newUser);

                MessageBox.Show("Qeydiyyat uğurla tamamlandı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Qeydiyyat zamanı xəta baş verdi: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}