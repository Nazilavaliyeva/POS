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
            string ad = "Admin";
            string soyad = "Admin";
            int parol = 123456;
            if(ad =="Admin" && soyad == "Admin" && parol == 123456)
            {
                frmPOS pos = new frmPOS();
                pos.Show(); 

            }
            else
            {
                MessageBox.Show("Məlumatları düzgün daxil edin", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
    }
}
