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

        private void FormAltaUsuario_Load(object sender, EventArgs e)
        {
            listViewRoles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewRoles.Items.Add("Rol 1");
            listViewRoles.Items.Add("Rol 2");
            listViewRoles.Items.Add("Rol 3");
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Nombre no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Contraseña no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listViewRoles.CheckedItems.Count == 0)
            {
                MessageBox.Show("El usuario debe tener al menos un rol", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxPregunta.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Pregunta secreta no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxRespuesta.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Respuesta secreta no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //TODO
            if (textBoxNombre.Text.Trim() == "a")
            {
                MessageBox.Show("El nombre de usuario no está disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Creo el usuario");
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxPassword.Clear();
            foreach (ListViewItem rol in listViewRoles.Items)
            {
                rol.Checked = false;
            }
            textBoxPregunta.Clear();
            textBoxRespuesta.Clear();
        }
    }
}
