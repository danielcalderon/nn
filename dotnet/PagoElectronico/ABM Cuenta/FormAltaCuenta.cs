using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_Cuenta
{
    public partial class FormAltaCuenta : Form
    {
        public FormAltaCuenta()
        {
            InitializeComponent();
        }

        private void FormAltaRol_Load(object sender, System.EventArgs e)
        {
            comboBoxMoneda.Items.Add("Dólares");
            comboBoxMoneda.SelectedIndex = 0;
            TipoCuentaDAO tipoCuentaDao = new TipoCuentaDAO();
            List<TipoCuenta> tiposCuenta = tipoCuentaDao.ObtenerTiposCuenta();
            Dictionary<int, string> tiposCuentaCombo = tiposCuenta.ToDictionary(rol => rol.Id, rol => rol.Nombre);
            comboBoxTipoCuenta.DataSource = new BindingSource(tiposCuentaCombo, null);
            comboBoxTipoCuenta.DisplayMember = "Value";
            comboBoxTipoCuenta.ValueMember = "Key";
            comboBoxTipoCuenta.SelectedIndex = 0;
            comboBoxTipoCuenta.SelectedItem = 0;
        }

        private void buttonLimpiar_Click(object sender, System.EventArgs e)
        {
            comboBoxClientes.SelectedItem = null;
            textBoxCliente.Clear();
            textBoxNumero.Clear();
            comboBoxPais.SelectedItem = null;
            dateTimePickerFechaCreacion.Value = DateTime.Now;
            comboBoxTipoCuenta.SelectedIndex = 0;
        }

        private void buttonGuardar_Click(object sender, System.EventArgs e)
        {
            if (textBoxCliente.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxNumero.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Número de cuenta no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CuentaDAO cuentaDao = new CuentaDAO();
            Cuenta cuentaExistente = cuentaDao.ObtenerCuenta(textBoxNumero.Text.Trim());
            if (cuentaExistente != null)
            {
                MessageBox.Show("El número de cuenta no está disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxPais.SelectedItem == null)
            {
                MessageBox.Show("El país no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cuenta cuenta = new Cuenta();
            KeyValuePair<int, string> itemCliente = (KeyValuePair<int, string>)comboBoxClientes.SelectedItem;
            Cliente cliente = new Cliente();
            cliente.Id = itemCliente.Key;
            cuenta.Cliente = cliente;
            cuenta.Numero = textBoxNumero.Text.Trim();
            cuenta.FechaCreacion = dateTimePickerFechaCreacion.Value;
            KeyValuePair<int, string> itemPais = (KeyValuePair<int, string>)comboBoxPais.SelectedItem;
            Pais pais = new Pais();
            pais.Id = itemPais.Key;
            cuenta.Pais  = pais;
            cuenta.Estado = 'H';
            KeyValuePair<int, string> itemTipoCuenta = (KeyValuePair<int, string>)comboBoxTipoCuenta.SelectedItem;
            TipoCuenta tipoCuenta = new TipoCuenta();
            tipoCuenta.Id = itemTipoCuenta.Key;
            cuenta.TipoCuenta = tipoCuenta;
            cuenta.TipoMoneda = 1;
            cuenta.Saldo = 0;
            cuentaDao.GuardarCuenta(cuenta);
            MessageBox.Show("Se creó la cuenta correctamente");
            Close();
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void comboBoxPais_TextChanged(object sender, System.EventArgs e)
        {
            string queryNombre = comboBoxPais.Text.Trim();
            if (queryNombre.Length == 0) return;
            PaisDAO paisDao = new PaisDAO();
            List<Pais> paises = paisDao.BuscarPaises(queryNombre);
            Dictionary<int, string> paisesCombo = paises.ToDictionary(pais => pais.Id, pais => pais.Nombre);
            if (paisesCombo.Count > 0)
            {
                comboBoxPais.DataSource = new BindingSource(paisesCombo, null);
                comboBoxPais.DisplayMember = "Value";
                comboBoxPais.ValueMember = "Key";
            }
            else
            {
                comboBoxPais.DataSource = null;
            }
        }

        private void buttonBuscarCliente_Click(object sender, System.EventArgs e)
        {
            string queryDocumento = comboBoxClientes.Text.Trim();
            if (queryDocumento.Length == 0) return;
            ClienteDAO clienteDao = new ClienteDAO();
            List<Cliente> clientes = clienteDao.BuscarClientes(queryDocumento);
            Dictionary<int, string> clientesCombo = clientes.ToDictionary(cliente => cliente.Id, cliente => cliente.Documento.ToString());
            if (clientesCombo.Count > 0)
            {
                comboBoxClientes.DataSource = new BindingSource(clientesCombo, null);
                comboBoxClientes.DisplayMember = "Value";
                comboBoxClientes.ValueMember = "Key";
            }
            else
            {
                comboBoxClientes.DataSource = null;
            }
        }


        private void comboBoxClientes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBoxClientes.SelectedItem == null) return;
            KeyValuePair<int, string> itemCliente = (KeyValuePair<int, string>)comboBoxClientes.SelectedItem;
            ClienteDAO clienteDao = new ClienteDAO();
            Cliente cliente = clienteDao.ObtenerCliente(itemCliente.Key);
            textBoxCliente.Text = cliente.Nombre + " " + cliente.Apellido;
        }

        private void textBoxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBoxClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
