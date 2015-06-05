using System.Windows.Forms;

namespace PagoElectronico.ABM_Rol
{
    public partial class FormModificacionRol : Form
    {
        private readonly int _idRol;

        public FormModificacionRol(int idRol)
        {
            _idRol = idRol;
            InitializeComponent();
        }

        private void FormAltaRol_Load(object sender, System.EventArgs e)
        {
            textBoxId.Text = _idRol.ToString();

            listViewFuncionalidades.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewFuncionalidades.Columns[0].Width -= 17;
            listViewFuncionalidades.Items.Add("Funcionalidad 1");
            listViewFuncionalidades.Items.Add("Funcionalidad 2");
            listViewFuncionalidades.Items.Add("Funcionalidad 3");
            listViewFuncionalidades.Items.Add("Funcionalidad 4");
            listViewFuncionalidades.Items.Add("Funcionalidad 5");
            listViewFuncionalidades.Items.Add("Funcionalidad 6");
            listViewFuncionalidades.Items.Add("Funcionalidad 7");
            listViewFuncionalidades.Items.Add("Funcionalidad 8");
            listViewFuncionalidades.Items.Add("Funcionalidad 9");
            listViewFuncionalidades.Items.Add("Funcionalidad 10");
            listViewFuncionalidades.Items.Add("Funcionalidad 11");
            listViewFuncionalidades.Items.Add("Funcionalidad 12");
        }

        private void buttonLimpiar_Click(object sender, System.EventArgs e)
        {
            textBoxNombreRol.Clear();
            foreach (ListViewItem funcionalidad in listViewFuncionalidades.Items)
            {
                funcionalidad.Checked = false;
            }
            checkBoxActivo.Checked = true;
        }

        private void buttonGuardar_Click(object sender, System.EventArgs e)
        {
            if (textBoxNombreRol.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Nombre no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Guardo el rol");
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
