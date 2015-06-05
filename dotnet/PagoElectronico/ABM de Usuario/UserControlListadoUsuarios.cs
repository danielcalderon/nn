using System;
using System.Windows.Forms;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class UserControlListadoUsuarios : UserControl
    {
        public UserControlListadoUsuarios()
        {
            InitializeComponent();
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            FormAltaUsuario formAltaUsuario = new FormAltaUsuario();
            formAltaUsuario.ShowDialog();
        }
    }
}
