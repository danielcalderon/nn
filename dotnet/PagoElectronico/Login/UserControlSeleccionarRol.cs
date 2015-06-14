using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.Login
{
    public partial class UserControlSeleccionarRol : UserControl
    {
        private readonly List<Rol> _roles;

        public UserControlSeleccionarRol(List<Rol> roles)
        {
            _roles = roles;
            InitializeComponent();
        }

        private void UserControlSeleccionarRol_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> roles = _roles.ToDictionary(rol => rol.Id, rol => rol.Nombre);
            comboBoxRoles.DataSource = new BindingSource(roles, null);
            comboBoxRoles.DisplayMember = "Value";
            comboBoxRoles.ValueMember = "Key";
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = (FormLogin)TopLevelControl;
            if (formLogin == null)
            {
                return;
            }
            KeyValuePair<int, string> item = (KeyValuePair<int, string>) comboBoxRoles.SelectedItem;
            int idRol = item.Key;
            foreach (Rol rol in _roles.Where(rol => rol.Id == idRol))
            {
                formLogin.SeleccionarRol(rol);
            }
        }
    }
}
