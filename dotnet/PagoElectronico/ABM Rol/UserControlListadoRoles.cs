using System;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Rol
{
    public partial class UserControlListadoRoles : UserControl
    {
        public UserControlListadoRoles()
        {
            InitializeComponent();
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            FormAltaRol formAltaRol = new FormAltaRol();
            formAltaRol.ShowDialog();
        }
    }
}
