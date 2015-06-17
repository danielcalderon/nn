using System;
using System.Collections.Generic;
using System.Linq;
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
            CargarClientes();
        }

        private void UserControlClientes_Load(object sender, EventArgs e)
        {
            TipoDocumentoDAO documentoDao = new TipoDocumentoDAO();
            List<TipoDocumento> documentos = new List<TipoDocumento>();
            TipoDocumento tipoDocumento = new TipoDocumento();
            documentos.Add(tipoDocumento);
            documentos.AddRange(documentoDao.ObtenerDocumentos());
            Dictionary<int, string> documentosCombo = documentos.ToDictionary(rol => rol.Id, rol => rol.Nombre);
            comboBoxTipoDoc.DataSource = new BindingSource(documentosCombo, null);
            comboBoxTipoDoc.DisplayMember = "Value";
            comboBoxTipoDoc.ValueMember = "Key";

            CargarClientes();
        }

        private void CargarClientes()
        {
            dataGridViewClientes.Rows.Clear();
            ClienteDAO clienteDao = new ClienteDAO();
            KeyValuePair<int, string> itemTipoDocumento = (KeyValuePair<int, string>)comboBoxTipoDoc.SelectedItem;
            int tipoDocumento = itemTipoDocumento.Key;
            List<Cliente> clientes = clienteDao.ObtenerClientes(textBoxNombre.Text.Trim(), textBoxApellido.Text.Trim(), tipoDocumento, textBoxNumeroDoc.Text, textBoxEmail.Text.Trim());
            foreach (Cliente cliente in clientes)
            {
                dataGridViewClientes.Rows.Add((new[] { cliente.Id.ToString(), cliente.TipoDocumento.Nombre, cliente.Documento.ToString(), cliente.Nombre, cliente.Apellido, 
                    cliente.Usuario != null ? cliente.Usuario.Nombre : "", cliente.Email }));
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            DataGridViewRow cliente = dataGridViewClientes.SelectedRows[0];
            FormModificacionCliente formModificacionRol = new FormModificacionCliente(int.Parse(cliente.Cells["Id"].Value.ToString()));
            formModificacionRol.ShowDialog();
            CargarClientes();
        }

        private void controlSearch_Changed(object sender, EventArgs e)
        {
            CargarClientes();
        }
    }
}
