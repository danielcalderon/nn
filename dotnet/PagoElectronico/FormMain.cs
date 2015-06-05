using System;
using System.Windows.Forms;
using PagoElectronico.ABM_Rol;
using PagoElectronico.Login;
using PagoElectronico.ABM_de_Usuario;
using PagoElectronico.ABM_Cliente;
using PagoElectronico.ABM_Cuenta;
using PagoElectronico.Consulta_Saldos;
using PagoElectronico.Facturacion;
using PagoElectronico.Transferencias;
using PagoElectronico.Depositos;
using PagoElectronico.Retiros;

namespace PagoElectronico
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlListadoRoles userControlListadoRoles = new UserControlListadoRoles();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlListadoRoles);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlListadoUsuarios userControlListadoUsuarios = new UserControlListadoUsuarios();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlListadoUsuarios);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlClientes userControlClientes = new UserControlClientes();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlClientes);
        }

        private void cuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlCuentas userControlCuentas = new UserControlCuentas();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlCuentas);
        }

        private void depósitosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlDepositos userControlDepositos = new UserControlDepositos();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlDepositos);
        }

        private void retirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlRetiros userControlRetiros = new UserControlRetiros();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlRetiros);
        }

        private void transferenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlTransferencias userControlTransferencias = new UserControlTransferencias();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlTransferencias);
        }

        private void facturaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlFacturacion userControlFacturacion = new UserControlFacturacion();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlFacturacion);
        }

        private void saldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlSaldos userControlSaldos = new UserControlSaldos();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlSaldos);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
