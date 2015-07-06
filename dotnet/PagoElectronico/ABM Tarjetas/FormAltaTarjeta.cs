using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_Tarjeta
{
    public partial class FormAltaTarjeta : Form
    {
        private readonly int _idCliente;

        public FormAltaTarjeta(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }

        private void FormAltaUsuario_Load(object sender, EventArgs e)
        {
            EmisorDAO emisorDao = new EmisorDAO();
            List<Emisor> emisores = emisorDao.ObtenerEmisores();
            Dictionary<int, string> documentosCombo = emisores.ToDictionary(rol => rol.Id, rol => rol.Descripcion);
            comboBoxEmisor.DataSource = new BindingSource(documentosCombo, null);
            comboBoxEmisor.DisplayMember = "Value";
            comboBoxEmisor.ValueMember = "Key";
            comboBoxEmisor.SelectedIndex = 0;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxNumero.Text.Trim().Length != 16)
            {
                MessageBox.Show("El campo Número de tarjeta debe contener 16 dígitos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TarjetaDAO tarjetaDao = new TarjetaDAO();
            Tarjeta tarjetaExistente = tarjetaDao.ObtenerTarjeta(textBoxNumero.Text.Trim());
            if (tarjetaExistente != null)
            {
                MessageBox.Show("El número de tarjeta no está disponible", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxCodigoSeguridad.Text.Trim().Length != 3)
            {
                MessageBox.Show("El campo Código de seguridad debe contener 3 dígitos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTime.Compare(dateTimePickerFechaVencimiento.Value, DateTime.Today.AddDays(1)) < 0)
            {
                MessageBox.Show("La fecha de vencimiento debe ser mayor a hoy", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Tarjeta tarjeta = new Tarjeta();
            Cliente cliente = new Cliente();
            cliente.Id = _idCliente;
            tarjeta.Cliente = cliente;
            tarjeta.Numero = textBoxNumero.Text.Trim();
            tarjeta.Codigo = int.Parse(textBoxCodigoSeguridad.Text.Trim());
            KeyValuePair<int, string> itemEmisor = (KeyValuePair<int, string>)comboBoxEmisor.SelectedItem;
            Emisor emisor = new Emisor();
            emisor.Id = itemEmisor.Key;
            tarjeta.Emisor = emisor;
            tarjeta.FechaEmision = DateTime.Now;
            tarjeta.FechaVencimiento = dateTimePickerFechaVencimiento.Value;
            tarjeta.Activo = true;
            tarjetaDao.GuardarTarjeta(tarjeta);
            MessageBox.Show("La tarjeta se creó correctamente");
            Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNumero.Clear();
            textBoxCodigoSeguridad.Clear();
            comboBoxEmisor.SelectedIndex = 0;
            dateTimePickerFechaVencimiento.Value = DateTime.Now;
        }

        private void textBoxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
