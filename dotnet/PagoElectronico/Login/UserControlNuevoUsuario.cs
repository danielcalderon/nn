using System.Windows.Forms;

namespace PagoElectronico.Login
{
    public partial class UserControlNuevoUsuario : UserControl
    {
        public UserControlNuevoUsuario()
        {
            InitializeComponent();
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            FormLogin formLogin = (FormLogin)TopLevelControl;
            if (formLogin != null) formLogin.CargarLogin();
        }

        private void buttonCrear_Click(object sender, System.EventArgs e)
        {
            if (textBoxUsuario.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Usuario no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxPassword.Text.Length == 0)
            {
                MessageBox.Show("El campo Contraseña no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxRepetirPassword.Text.Length == 0)
            {
                MessageBox.Show("El campo Repetir contraseña no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxPassword.Text != textBoxRepetirPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Creo el nuevo usuario");
        }
    }
}
