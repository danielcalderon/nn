using System;
using System.Windows.Forms;

namespace PagoElectronico.ABM_Cliente
{
    public partial class FormAltaCliente : Form
    {
        public FormAltaCliente()
        {
            InitializeComponent();
        }

        private void FormAltaCliente_Load(object sender, EventArgs e)
        {
            comboBoxTipoDoc.SelectedIndex = 0;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            comboBoxTipoDoc.SelectedIndex = 0;
            textBoxNumeroDoc.Clear();
            textBoxEmail.Clear();
            textBoxPais.Clear();
            textBoxCalle.Clear();
            textBoxPiso.Clear();
            textBoxDepartamento.Clear();
            textBoxLocalidad.Clear();
            textBoxNacionalidad.Clear();
            dateTimePickerFechaNacimiento.Value = DateTime.Now;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxNumeroDoc.Text == "1")
            {
                MessageBox.Show("El tipo y número de documento ya existen en el sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxEmail.Text == "1")
            {
                MessageBox.Show("La dirección de email ya existe en el sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Guardo el cliente");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
