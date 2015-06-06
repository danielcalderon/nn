using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.Login
{
    public partial class UserControlSeleccionarRol : UserControl
    {
        public UserControlSeleccionarRol()
        {
            InitializeComponent();
        }

        private void UserControlSeleccionarRol_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> roles = new Dictionary<int, string>();
            roles.Add(1, "Rol 1");
            roles.Add(2, "Rol 2");
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
            int rol = comboBoxRoles.SelectedIndex;
            formLogin.SeleccionarRol(rol);
        }
    }
}
