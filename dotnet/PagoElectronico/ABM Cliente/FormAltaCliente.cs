﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PagoElectronico.ABM_de_Usuario;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_Cliente
{
    public partial class FormAltaCliente : Form
    {
        private Usuario _usuario;

        public FormAltaCliente()
        {
            InitializeComponent();
        }

        private void FormAltaCliente_Load(object sender, EventArgs e)
        {
            TipoDocumentoDAO documentoDao = new TipoDocumentoDAO();
            List<TipoDocumento> documentos = documentoDao.ObtenerDocumentos();
            Dictionary<int, string> documentosCombo = documentos.ToDictionary(rol => rol.Id, rol => rol.Nombre);
            comboBoxTipoDoc.DataSource = new BindingSource(documentosCombo, null);
            comboBoxTipoDoc.DisplayMember = "Value";
            comboBoxTipoDoc.ValueMember = "Key";
            comboBoxTipoDoc.SelectedIndex = 0;
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
            ClienteDAO clienteDao = new ClienteDAO();
            Usuario usuarioExistente = new Usuario();
            usuarioExistente.Nombre = textBoxUsuario.Text;
            Cliente clienteExistente = clienteDao.ObtenerCliente(usuarioExistente);
            if (clienteExistente != null)
            {
                MessageBox.Show("El usuario selecciondo ya es cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            KeyValuePair<int, string> itemTipoDocumento = (KeyValuePair<int, string>)comboBoxTipoDoc.SelectedItem;
            clienteExistente = clienteDao.ObtenerCliente(itemTipoDocumento.Key, long.Parse(textBoxNumeroDoc.Text.Trim()));
            if (clienteExistente != null)
            {
                MessageBox.Show("El tipo y número de documento ya existen en el sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clienteExistente = clienteDao.ObtenerCliente(textBoxEmail.Text.Trim());
            if (clienteExistente != null)
            {
                MessageBox.Show("La dirección de email ya existe en el sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Cliente cliente = new Cliente();
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
            cliente.Usuario = _usuario;
            clienteDao.GuardarCliente(cliente);
            UsuarioDAO usuarioDao = new UsuarioDAO();
            Usuario usuario = usuarioDao.ObtenerUsuario(textBoxUsuario.Text);
            RolDAO rolDao = new RolDAO();
            Rol rolCliente = rolDao.ObtenerRol("Cliente");
            usuario.Roles.Add(rolCliente);
            usuarioDao.ModificarUsuario(usuario);
            MessageBox.Show("El cliente se creó correctamente");
            Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonNuevoUsuario_Click(object sender, EventArgs e)
        {
            FormAltaUsuario formAltaUsuario = new FormAltaUsuario();
            formAltaUsuario.ShowDialog();
            CargarUsuario(formAltaUsuario.Usuario);
        }

        private void comboBoxUsuarios_TextChanged(object sender, EventArgs e)
        {
            string queryNombre = comboBoxUsuarios.Text.Trim();
            if (queryNombre.Length == 0) return;
            UsuarioDAO usuarioDao = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDao.BuscarUsuarios(queryNombre);
            Dictionary<int, string> usuariosCombo = usuarios.ToDictionary(usuario => usuario.Id, usuario => usuario.Nombre);
            if (usuariosCombo.Count > 0)
            {
                comboBoxUsuarios.DataSource = new BindingSource(usuariosCombo, null);
                comboBoxUsuarios.DisplayMember = "Value";
                comboBoxUsuarios.ValueMember = "Key";
            }
            else
            {
                comboBoxUsuarios.DataSource = null;
            }
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

        private void comboBoxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<int, string> item = (KeyValuePair<int, string>)comboBoxUsuarios.SelectedItem;
            string nombreUsuario = item.Value;
            CargarUsuario(nombreUsuario);
        }

        public void CargarUsuario(string nombreUsuario)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            Usuario usuario = usuarioDao.ObtenerUsuario(nombreUsuario);
            if (usuario == null) return;
            textBoxUsuario.Text = usuario.Nombre;
            checkBoxUsuarioActivo.Checked = usuario.Activo;
            _usuario = usuario;
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
