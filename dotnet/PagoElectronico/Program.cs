using System;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico
{
    static class Program
    {
        public static Usuario Usuario { get; set; }

        public static Rol Rol { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
