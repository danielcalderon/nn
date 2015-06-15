using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_Cliente
{
    public partial class UserControlClientes : UserControl
    {
        public UserControlClientes()
        {
            InitializeComponent();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            FormAltaCliente formAltaCliente = new FormAltaCliente();
            formAltaCliente.ShowDialog();
        }

        private void UserControlClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            dataGridViewClientes.Rows.Clear();
            ClienteDAO clienteDao = new ClienteDAO();
            List<Cliente> clientes = clienteDao.ObtenerClientes();
            foreach (Cliente cliente in clientes)
            {
                dataGridViewClientes.Rows.Add((new[] { cliente.TipoDocumento.Nombre, cliente.Documento.ToString(), cliente.Nombre, cliente.Apellido, 
                    cliente.Usuario != null ? cliente.Usuario.Nombre : "", cliente.Email }));
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            DataGridViewRow cliente = dataGridViewClientes.SelectedRows[0];
            FormModificacionCliente formModificacionRol = new FormModificacionCliente(int.Parse(cliente.Cells["TipoDocumento"].Value.ToString()), long.Parse(cliente.Cells["Documento"].Value.ToString()));
            formModificacionRol.ShowDialog();
            CargarClientes();
        }
    }
}
