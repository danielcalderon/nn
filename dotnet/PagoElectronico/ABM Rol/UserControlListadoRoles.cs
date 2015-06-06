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
            dataGridViewRoles.Rows.Add((new[] { "6", "Rol 6", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "7", "Rol 7", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "8", "Rol 8", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "9", "Rol 9", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "10", "Rol 10", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "11", "Rol 11", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "12", "Rol 12", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "13", "Rol 13", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "14", "Rol 14", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "15", "Rol 15", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "16", "Rol 16", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "17", "Rol 17", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "18", "Rol 18", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "19", "Rol 19", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "20", "Rol 20", "No" }));
            dataGridViewRoles.Rows.Add((new[] { "21", "Rol 21", "Sí" }));
            dataGridViewRoles.Rows.Add((new[] { "22", "Rol 22", "No" }));
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
            FormModificacionRol formModificacionRol = new FormModificacionRol(int.Parse(rol.Cells["Id"].Value.ToString()));
            formModificacionRol.ShowDialog();
        }
    }
}
