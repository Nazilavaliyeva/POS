using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class Frm_login : Form
    {
        public Frm_login()
        {
            InitializeComponent();
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
          

        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            // Burada giriş məlumatlarını yoxlayırıq    
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string sifre = txtSifre.Text;

        }
    }
}
