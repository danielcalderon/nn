using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class FormAltaUsuario : Form
    {
        public string Usuario { get; set; }

        public FormAltaUsuario()
        {
            InitializeComponent();
        }

        private void FormAltaUsuario_Load(object sender, EventArgs e)
        {
            listViewRoles.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            RolDAO rolDao = new RolDAO();
            List<Rol> roles = rolDao.ObtenerRoles();
            foreach (Rol rol in roles)
            {
                ListViewItem listViewItem = new ListViewItem(rol.Nombre);
                listViewItem.Tag = rol.Id;
                listViewRoles.Items.Add(listViewItem);
            }
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
            UsuarioDAO usuarioDao = new UsuarioDAO();
            Usuario usuarioExistente = usuarioDao.ObtenerUsuario(textBoxNombre.Text.Trim());
            if (usuarioExistente != null)
            {
                MessageBox.Show("El nombre de usuario no está disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Usuario usuario = new Usuario();
            usuario.Nombre = textBoxNombre.Text.Trim();
            usuario.Password = textBoxPassword.Text;
            usuario.Pregunta = textBoxPregunta.Text.Trim();
            usuario.Respuesta = textBoxRespuesta.Text.Trim();
            usuario.Activo = true;
            usuarioDao.GuardarUsuario(usuario);
            MessageBox.Show("El usuario se creó correctamente");
            Usuario = usuario.Nombre;
            Close();
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
