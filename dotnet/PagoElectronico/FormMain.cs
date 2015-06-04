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

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlListadoRoles userControlListadoRoles = new UserControlListadoRoles();
            panelPrincipal.Controls.Add(userControlListadoRoles);
        }
    }
}
