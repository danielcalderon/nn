using System;
using System.Windows.Forms;
using PagoElectronico.ABM_Rol;

namespace PagoElectronico
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private static void crearNuevoRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAltaRol formAltaRol = new FormAltaRol();
            formAltaRol.Show();
        }
    }
}
