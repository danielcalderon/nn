using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            CargarLogin();
        }

        internal void CargarLogin()
        {
            UserControlLogin userControlLogin = new UserControlLogin();
            panelLogin.Controls.Clear();
            panelLogin.Controls.Add(userControlLogin);
        }

        internal void CargarNuevoUsuario()
        {
            UserControlNuevoUsuario userControlNuevoUsuario = new UserControlNuevoUsuario();
            panelLogin.Controls.Clear();
            panelLogin.Controls.Add(userControlNuevoUsuario);
        }

        internal void CargarSeleccionarRol(List<Rol> roles)
        {
            UserControlSeleccionarRol userControlSeleccionarRol = new UserControlSeleccionarRol(roles);
            panelLogin.Controls.Clear();
            panelLogin.Controls.Add(userControlSeleccionarRol);
        }

        internal void Login(string nombreUsuario, string password)
        {
            if (nombreUsuario.Length == 0)
            {
                MessageBox.Show("El campo Usuario no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password.Length == 0)
            {
                MessageBox.Show("El campo Contraseña no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UsuarioDAO usuarioDao = new UsuarioDAO();
            Usuario usuario = usuarioDao.ObtenerUsuario(nombreUsuario);
            if (usuario == null)
            {
                MessageBox.Show("El usuario no existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (EncriptarPassword(password) != usuario.Password)
            {
                MessageBox.Show("La contraseña es incorrecta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usuario.Intentos += 1;
                if (usuario.Intentos >= 3)
                {
                    usuario.Activo = false;
                }
                usuarioDao.ModificarUsuario(usuario);
                GuardarLogin(usuario.Nombre, false, usuario.Intentos, usuario.Activo);
                return;
            }
            if (!usuario.Activo)
            {
                MessageBox.Show("El usuario no está habilitado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GuardarLogin(usuario.Nombre, false, usuario.Intentos, usuario.Activo);
                return;
            }
            GuardarLogin(usuario.Nombre, true, usuario.Intentos, usuario.Activo);
            usuario.Intentos = 0;
            usuarioDao.ModificarUsuario(usuario);
            Program.Usuario = usuario;
            if (usuario.Roles.Count > 1)
            {
                CargarSeleccionarRol(usuario.Roles);
            }
            else
            {
                if (usuario.Roles.Count > 0)
                {
                    Program.Rol = usuario.Roles[0];
                }
                else
                {
                    MessageBox.Show("El usuario no posee roles asignados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Close();
            }
        }

        private static void GuardarLogin(string usuario, bool loginExitoso, int intentos, bool usuarioActivo)
        {
            LoginDAO loginDao = new LoginDAO();
            loginDao.GuardarLogin(usuario, loginExitoso, intentos, usuarioActivo);
        }

        internal void SeleccionarRol(Rol rol)
        {
            Program.Rol = rol;
            Close();
        }

        private static string EncriptarPassword(string password)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
            HashAlgorithm hash = new SHA256Managed();
            byte[] hashBytes = hash.ComputeHash(plainTextBytes);
            string hashValue = Convert.ToBase64String(hashBytes);
            return hashValue;
        }
    }
}
