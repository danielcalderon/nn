using System;
using System.Windows.Forms;

namespace PagoElectronico.Login
{
    public partial class UserControlLogin : UserControl
    {
        public UserControlLogin()
        {
            InitializeComponent();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = (FormLogin)TopLevelControl;
            if (formLogin == null)
            {
                return;
            }
            formLogin.Login(textBoxUsuario.Text.Trim(), textBoxPassword.Text);
        }

        private static void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {       
            FormLogin formLogin = (FormLogin) TopLevelControl;
            if (formLogin != null)
            {
                formLogin.CargarNuevoUsuario();
            }
        }

        private void UserControlLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Enter))
            {
                return;
            }
            FormLogin formLogin = (FormLogin)TopLevelControl;
            if (formLogin == null)
            {
                return;
            }
            formLogin.Login(textBoxUsuario.Text.Trim(), textBoxPassword.Text);
        }
    }
}
