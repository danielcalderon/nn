using System.Collections.Generic;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class UserControlCuentas : UserControl
    {
        public UserControlCuentas()
        {
            InitializeComponent();
        }

        private void UserControlCuentas_Load(object sender, System.EventArgs e)
        {
            CargarCuentas();
        }

        private void CargarCuentas()
        {
            dataGridViewCuentas.Rows.Clear();
            CuentaDAO cuentaDao = new CuentaDAO();
            List<Cuenta> cuentas = cuentaDao.ObtenerCuentas();
            foreach (Cuenta cuenta in cuentas)
            {
                dataGridViewCuentas.Rows.Add((new[] { cuenta.Id.ToString(), cuenta.Numero, cuenta.Saldo.ToString(), cuenta.Estado.ToString() }));
            }
        }

        private void buttonNuevo_Click(object sender, System.EventArgs e)
        {
            FormAltaCuenta formAltaCuenta = new FormAltaCuenta();
            formAltaCuenta.ShowDialog();
            CargarCuentas();
        }

        private void buttonModificar_Click(object sender, System.EventArgs e)
        {
            DataGridViewRow cuenta = dataGridViewCuentas.SelectedRows[0];
            MessageBox.Show(cuenta.Cells["Id"].Value.ToString());
            CargarCuentas();
        }
    }
}
