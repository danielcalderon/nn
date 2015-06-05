using System;
using System.Windows.Forms;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class FormAltaUsuario : Form
    {
        public FormAltaUsuario()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creo usuario");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
