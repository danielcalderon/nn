using System.Windows.Forms;

namespace PagoElectronico.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, System.EventArgs e)
        {
            CargarLogin();
        }

        public void CargarLogin()
        {
            UserControlLogin userControlLogin = new UserControlLogin();
            panelLogin.Controls.Clear();
            panelLogin.Controls.Add(userControlLogin);
        }

        public void CargarNuevoUsuario()
        {
            UserControlNuevoUsuario userControlNuevoUsuario = new UserControlNuevoUsuario();
            panelLogin.Controls.Clear();
            panelLogin.Controls.Add(userControlNuevoUsuario);
        }

        public void Login(string usuario, string password)
        {
            /*if (usuario.Length == 0)
            {
                MessageBox.Show("El campo Usuario no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password.Length == 0)
            {
                MessageBox.Show("El campo Contraseña no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            Program.Usuario = "MAGOYA";
            Program.Rol = "BANQUERO";
            Close();
        }
    }
}
