using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

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
            CargarRoles();
        }

        private void CargarRoles()
        {
            dataGridViewRoles.Rows.Clear();
            RolDAO rolDao = new RolDAO();
            List<Rol> roles = rolDao.ObtenerRoles();
            foreach (Rol rol in roles)
            {
                dataGridViewRoles.Rows.Add((new[] { rol.Id.ToString(), rol.Nombre, rol.Activo ? "Sí" : "No" }));
            }
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            FormAltaRol formAltaRol = new FormAltaRol();
            formAltaRol.ShowDialog();
            CargarRoles();
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
            CargarRoles();
        }
    }
}
