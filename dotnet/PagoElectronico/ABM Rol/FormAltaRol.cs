using System.Collections.Generic;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_Rol
{
    public partial class FormAltaRol : Form
    {
        public FormAltaRol()
        {
            InitializeComponent();
        }

        private void FormAltaRol_Load(object sender, System.EventArgs e)
        {
            listViewFuncionalidades.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewFuncionalidades.Columns[0].Width -= 17;
            FuncionalidadDAO funcionalidadDao = new FuncionalidadDAO();
            List<Funcionalidad> funcionalidades = funcionalidadDao.ObtenerFuncionalidades();
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                ListViewItem listViewItem = new ListViewItem(funcionalidad.Nombre);
                listViewItem.Tag = funcionalidad.Id;
                listViewFuncionalidades.Items.Add(listViewItem);
            }
        }

        private void buttonLimpiar_Click(object sender, System.EventArgs e)
        {
            textBoxNombre.Clear();
            foreach (ListViewItem funcionalidad in listViewFuncionalidades.Items)
            {
                funcionalidad.Checked = false;
            }
            checkBoxActivo.Checked = true;
        }

        private void buttonGuardar_Click(object sender, System.EventArgs e)
        {
            if (textBoxNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("El campo Nombre no puede estar vacío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Rol rol = new Rol();
            rol.Nombre = textBoxNombre.Text.Trim();
            rol.Activo = checkBoxActivo.Checked;
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            ListView.CheckedListViewItemCollection listViewItemCollection = listViewFuncionalidades.CheckedItems;
            foreach (ListViewItem listViewItem in listViewItemCollection)
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.Id = (int) listViewItem.Tag;
                funcionalidades.Add(funcionalidad);
            }
            rol.Funcionalidades = funcionalidades;

            RolDAO rolDao = new RolDAO();
            if (rolDao.GuardarRol(rol))
            {
                MessageBox.Show("Se ha guardado el rol correctamente");
            }
            Close();
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
