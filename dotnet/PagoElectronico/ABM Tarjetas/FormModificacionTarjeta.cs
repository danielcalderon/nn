using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_Tarjeta
{
    public partial class FormModificacionTarjeta : Form
    {
        private readonly int _idTarjeta;

        public FormModificacionTarjeta(int idTarjeta)
        {
            _idTarjeta = idTarjeta;
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

            CargarTarjeta();
        }

        private void CargarTarjeta()
        {
            TarjetaDAO tarjetaDao = new TarjetaDAO();
            Tarjeta tarjeta = tarjetaDao.ObtenerTarjeta(_idTarjeta);
            textBoxUltimos4digitos.Text = tarjeta.Numero.Substring(tarjeta.Numero.Length - 4);
            textBoxCodigoSeguridad.Text = tarjeta.Codigo.ToString();
            KeyValuePair<int, string> itemEmisor = new KeyValuePair<int, string>();
            foreach (KeyValuePair<int, string> item in comboBoxEmisor.Items)
            {
                if (item.Key == tarjeta.Emisor.Id)
                {
                    itemEmisor = item;
                }
            }
            comboBoxEmisor.SelectedItem = itemEmisor;
            dateTimePickerFechaVencimiento.Value = tarjeta.FechaVencimiento;
            checkBoxActivo.Checked = tarjeta.Activo;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
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
            tarjeta.Id = _idTarjeta;
            tarjeta.Codigo = int.Parse(textBoxCodigoSeguridad.Text.Trim());
            KeyValuePair<int, string> itemEmisor = (KeyValuePair<int, string>)comboBoxEmisor.SelectedItem;
            Emisor emisor = new Emisor();
            emisor.Id = itemEmisor.Key;
            tarjeta.Emisor = emisor;
            tarjeta.FechaVencimiento = dateTimePickerFechaVencimiento.Value;
            tarjeta.Activo = checkBoxActivo.Checked;
            TarjetaDAO tarjetaDao = new TarjetaDAO();
            tarjetaDao.ModificarTarjeta(tarjeta);
            MessageBox.Show("La tarjeta se modificó correctamente");
            Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxCodigoSeguridad.Clear();
            comboBoxEmisor.SelectedIndex = 0;
            dateTimePickerFechaVencimiento.Value = DateTime.Now;
            checkBoxActivo.Checked = true;
        }

        private void textBoxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
