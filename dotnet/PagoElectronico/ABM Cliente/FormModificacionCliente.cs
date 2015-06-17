using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_Cliente
{
    public partial class FormModificacionCliente : Form
    {
        private readonly int _idCliente;
        private int _idUsuario;

        public FormModificacionCliente(int idCliente)
        {
            _idCliente = idCliente;
            InitializeComponent();
        }

        private void FormModificacionCliente_Load(object sender, EventArgs e)
        {
            TipoDocumentoDAO documentoDao = new TipoDocumentoDAO();
            List<TipoDocumento> documentos = documentoDao.ObtenerDocumentos();
            Dictionary<int, string> documentosCombo = documentos.ToDictionary(rol => rol.Id, rol => rol.Nombre);
            comboBoxTipoDoc.DataSource = new BindingSource(documentosCombo, null);
            comboBoxTipoDoc.DisplayMember = "Value";
            comboBoxTipoDoc.ValueMember = "Key";
            comboBoxTipoDoc.SelectedIndex = 0;

            CargarCliente();
        }

        private void CargarCliente()
        {
            ClienteDAO clienteDao = new ClienteDAO();
            Cliente cliente = clienteDao.ObtenerCliente(_idCliente);
            textBoxNombre.Text = cliente.Nombre;
            textBoxApellido.Text = cliente.Apellido;
            KeyValuePair<int, string> itemTipoDocumento = new KeyValuePair<int, string>();
            foreach (KeyValuePair<int, string> item in comboBoxTipoDoc.Items)
            {
                if (item.Key == cliente.TipoDocumento.Id)
                {
                    itemTipoDocumento = item;
                }
            }
            comboBoxTipoDoc.SelectedItem = itemTipoDocumento;
            textBoxNumeroDoc.Text = cliente.Documento.ToString();
            textBoxEmail.Text = cliente.Email;
            Dictionary<int, string> paisesCombo = new Dictionary<int, string>();
            paisesCombo.Add(cliente.Pais.Id, cliente.Pais.Nombre);
            comboBoxPais.DataSource = new BindingSource(paisesCombo, null);
            comboBoxPais.DisplayMember = "Value";
            comboBoxPais.ValueMember = "Key";
            KeyValuePair<int, string> itemPais = new KeyValuePair<int, string>();
            foreach (KeyValuePair<int, string> item in comboBoxPais.Items)
            {
                if (item.Key == cliente.Pais.Id)
                {
                    itemPais = item;
                }
            }
            comboBoxPais.SelectedItem = itemPais;
            textBoxCalle.Text = cliente.Calle;
            textBoxPiso.Text = cliente.Piso;
            textBoxDepartamento.Text = cliente.Departamento;
            textBoxLocalidad.Text = cliente.Localidad;
            textBoxNacionalidad.Text = cliente.Nacionalidad;
            dateTimePickerFechaNacimiento.Value = cliente.FechaNacimiento;
            checkBoxActivo.Checked = cliente.Activo;

            CargarUsuario(cliente.Usuario.Id);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxApellido.Clear();
            comboBoxTipoDoc.SelectedIndex = 0;
            textBoxNumeroDoc.Clear();
            textBoxEmail.Clear();
            comboBoxPais.SelectedItem = null;
            textBoxCalle.Clear();
            textBoxPiso.Clear();
            textBoxDepartamento.Clear();
            textBoxLocalidad.Clear();
            textBoxNacionalidad.Clear();
            dateTimePickerFechaNacimiento.Value = DateTime.Now;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text.Length == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo nombre no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxApellido.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo apellido no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxNumeroDoc.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo número de documento no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxEmail.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo email no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxPais.SelectedItem == null)
            {
                MessageBox.Show("El país no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxCalle.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo calle no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxLocalidad.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo localidad no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxNacionalidad.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo nacionalidad no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DateTime.Compare(dateTimePickerFechaNacimiento.Value, DateTime.Today) > 0)
            {
                MessageBox.Show("La fecha de nacimiento debe ser menor a hoy", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ClienteDAO clienteDao = new ClienteDAO();
            KeyValuePair<int, string> itemTipoDocumento = (KeyValuePair<int, string>)comboBoxTipoDoc.SelectedItem;
            Cliente cliente = new Cliente();
            cliente.Id = _idCliente;
            Usuario usuario = new Usuario();
            usuario.Id = _idUsuario;
            cliente.Usuario = usuario;
            cliente.Nombre = textBoxNombre.Text.Trim();
            cliente.Apellido = textBoxApellido.Text.Trim();
            TipoDocumento tipoDocumento = new TipoDocumento();
            tipoDocumento.Id = itemTipoDocumento.Key;
            tipoDocumento.Nombre = itemTipoDocumento.Value;
            cliente.TipoDocumento = tipoDocumento;
            cliente.Documento = long.Parse(textBoxNumeroDoc.Text.Trim());
            cliente.Email = textBoxEmail.Text.Trim();
            Pais pais = new Pais();
            KeyValuePair<int, string> itemPais = (KeyValuePair<int, string>)comboBoxPais.SelectedItem;
            pais.Id = itemPais.Key;
            pais.Nombre = itemPais.Value;
            cliente.Pais = pais;
            cliente.Calle = textBoxCalle.Text.Trim();
            cliente.Piso = textBoxPiso.Text.Trim();
            cliente.Departamento = textBoxDepartamento.Text.Trim();
            cliente.Localidad = textBoxLocalidad.Text.Trim();
            cliente.Nacionalidad = textBoxNacionalidad.Text.Trim();
            cliente.FechaNacimiento = dateTimePickerFechaNacimiento.Value;
            cliente.Activo = checkBoxActivo.Checked;
            clienteDao.ModificarCliente(cliente);
            MessageBox.Show("El cliente se modificó correctamente");
            Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBoxPais_TextChanged(object sender, EventArgs e)
        {
            string queryNombre = comboBoxPais.Text.Trim();
            if (queryNombre.Length == 0) return;
            PaisDAO paisDao = new PaisDAO();
            List<Pais> paises = paisDao.BuscarPaises(queryNombre);
            Dictionary<int, string> paisesCombo = paises.ToDictionary(pais => pais.Id, usuario => usuario.Nombre);
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

        private void CargarUsuario(int idUsuario)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            Usuario usuario = usuarioDao.ObtenerUsuario(idUsuario);
            textBoxUsuario.Text = usuario.Nombre;
            checkBoxUsuarioActivo.Checked = usuario.Activo;
            _idUsuario = idUsuario;
        }

        private void textBoxNumeroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBoxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
