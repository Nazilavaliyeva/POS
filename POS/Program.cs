using System;
using System.Windows.Forms;

namespace POS
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Verilənlər bazasını və cədvəlləri hazırlayır
            DataAccess.InitializeDatabase();

            Application.Run(new Frm_login());
        }
    }
}