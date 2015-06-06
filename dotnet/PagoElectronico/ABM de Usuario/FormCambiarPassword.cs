using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class FormCambiarPassword : Form
    {
        public FormCambiarPassword()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCambiar_Click(object sender, EventArgs e)
        {
            if (textBoxPasswordActual.Text.Length == 0)
            {
                MessageBox.Show("El campo Contraseña actual no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxNuevoPassword.Text.Length == 0)
            {
                MessageBox.Show("El campo Nueva contraseña no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxRepetirNuevoPassword.Text.Length == 0)
            {
                MessageBox.Show("El campo Repetir contraseña no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxNuevoPassword.Text != textBoxRepetirNuevoPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Cambio la contraseña");
            Close();
        }
    }
}
