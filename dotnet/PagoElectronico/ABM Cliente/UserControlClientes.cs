using System;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Cliente
{
    public partial class UserControlClientes : UserControl
    {
        public UserControlClientes()
        {
            InitializeComponent();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            FormAltaCliente formAltaCliente = new FormAltaCliente();
            formAltaCliente.ShowDialog();
        }
    }
}
