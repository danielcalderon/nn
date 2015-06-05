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

        private void UserControlListadoRoles_Load(object sender, EventArgs e)
        {
            dataGridViewRoles.Rows.Add((new[] { "1", "Rol 1", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "2", "Rol 2", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "3", "Rol 3", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "4", "Rol 4", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "5", "Rol 5", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "6", "Rol 2", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "7", "Rol 1", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "8", "Rol 2", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "9", "Rol 1", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "10", "Rol 2", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "11", "Rol 1", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "12", "Rol 2", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "13", "Rol 1", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "14", "Rol 2", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "15", "Rol 1", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "16", "Rol 2", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "17", "Rol 1", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "18", "Rol 2", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "19", "Rol 1", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "20", "Rol 2", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "21", "Rol 1", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "22", "Rol 2", "No" }));
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            FormAltaRol formAltaRol = new FormAltaRol();
            formAltaRol.ShowDialog();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            DataGridViewRow rol = dataGridViewRoles.SelectedRows[0];
            MessageBox.Show("Elimino el rol " + rol.Cells["Id"].Value);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            DataGridViewRow rol = dataGridViewRoles.SelectedRows[0];
            FormModificacionRol formAltaRol = new FormModificacionRol(int.Parse(rol.Cells["Id"].Value.ToString()));
            formAltaRol.ShowDialog();
        }
    }
}
