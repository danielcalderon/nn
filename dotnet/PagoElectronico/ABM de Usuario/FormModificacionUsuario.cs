using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PagoElectronico.ABM_de_Usuario
{
    public partial class FormModificacionUsuario : Form
    {

        private readonly int _usuario;

        public FormModificacionUsuario(int usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }
    }
}
