using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PagoElectronico.DAO;
using PagoElectronico.Entidades_de_negocio;

namespace PagoElectronico.ABM_Rol
{
    public partial class FormModificacionRol : Form
    {
        private readonly int _rol;

        public FormModificacionRol(int rol)
        {
            _rol = rol;
            InitializeComponent();
        }

        private void FormAltaRol_Load(object sender, System.EventArgs e)
        {
            listViewFuncionalidades.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listViewFuncionalidades.Columns[0].Width -= 17;

            RolDAO rolDao = new RolDAO();
            Rol rol = rolDao.ObtenerRol(_rol);

            textBoxId.Text = rol.Id.ToString();
            textBoxNombre.Text = rol.Nombre;

            FuncionalidadDAO funcionalidadDao = new FuncionalidadDAO();
            List<Funcionalidad> funcionalidades = funcionalidadDao.ObtenerFuncionalidades();
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                ListViewItem listViewItem = new ListViewItem(funcionalidad.Nombre);
                listViewItem.Tag = funcionalidad.Id;
                Funcionalidad f = funcionalidad;
                if (rol.Funcionalidades.Any(funcionalidadRol => funcionalidadRol.Id == f.Id))
                {
                    listViewItem.Checked = true;
                }
                listViewFuncionalidades.Items.Add(listViewItem);
            }
            checkBoxActivo.Checked = rol.Activo;
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
            rol.Id = int.Parse(textBoxId.Text);
            rol.Nombre = textBoxNombre.Text.Trim();
            rol.Activo = checkBoxActivo.Checked;
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            ListView.CheckedListViewItemCollection listViewItemCollection = listViewFuncionalidades.CheckedItems;
            foreach (ListViewItem listViewItem in listViewItemCollection)
            {
                Funcionalidad funcionalidad = new Funcionalidad();
                funcionalidad.Id = (int)listViewItem.Tag;
                funcionalidades.Add(funcionalidad);
            }
            rol.Funcionalidades = funcionalidades;

            RolDAO rolDao = new RolDAO();
            if (rolDao.ModificarRol(rol))
            {
                MessageBox.Show("Se ha modificado el rol correctamente");
            }
            Close();
        }

        private void buttonCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
