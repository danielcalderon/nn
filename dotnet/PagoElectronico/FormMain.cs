﻿using System;
using System.Windows.Forms;
using PagoElectronico.ABM_Rol;
using PagoElectronico.Login;

namespace PagoElectronico
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControlListadoRoles userControlListadoRoles = new UserControlListadoRoles();
            panelPrincipal.Controls.Clear();
            panelPrincipal.Controls.Add(userControlListadoRoles);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }
    }
}