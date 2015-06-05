using System;
using System.Windows.Forms;

namespace PagoElectronico
{
    static class Program
    {
        public static string Usuario { get; set; }

        public static string Rol { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
