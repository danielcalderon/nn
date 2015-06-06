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

        private void UserControlListadoUsuarios_Load(object sender, EventArgs e)
        {
            dataGridViewUsuarios.Rows.Add((new[] { "1", "Usuario 1", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "2", "Usuario 2", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "3", "Usuario 3", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "4", "Usuario 4", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "5", "Usuario 5", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "6", "Usuario 6", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "7", "Usuario 7", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "8", "Usuario 8", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "9", "Usuario 9", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "10", "Usuario 10", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "11", "Usuario 11", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "12", "Usuario 12", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "13", "Usuario 13", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "14", "Usuario 14", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "15", "Usuario 15", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "16", "Usuario 16", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "17", "Usuario 17", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "18", "Usuario 18", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "19", "Usuario 19", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "20", "Usuario 20", "No" }));
            dataGridViewUsuarios.Rows.Add((new[] { "21", "Usuario 21", "Sí" }));
            dataGridViewUsuarios.Rows.Add((new[] { "22", "Usuario 22", "No" }));
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            FormAltaUsuario formAltaUsuario = new FormAltaUsuario();
            formAltaUsuario.ShowDialog();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow rol = dataGridViewUsuarios.SelectedRows[0];
            MessageBox.Show("Elimino el usuario " + rol.Cells["Id"].Value);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            DataGridViewRow usuario = dataGridViewUsuarios.SelectedRows[0];
            FormModificacionUsuario formModificacionUsuario = new FormModificacionUsuario(int.Parse(usuario.Cells["Id"].Value.ToString()));
            formModificacionUsuario.ShowDialog();
        }
    }
}
