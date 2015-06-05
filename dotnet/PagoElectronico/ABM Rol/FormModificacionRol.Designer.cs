namespace PagoElectronico.ABM_Rol
{
    partial class FormModificacionRol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNombreRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxRol = new System.Windows.Forms.GroupBox();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxActivo = new System.Windows.Forms.CheckBox();
            this.listViewFuncionalidades = new System.Windows.Forms.ListView();
            this.Funcionalidad = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupBoxRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxNombreRol
            // 
            this.textBoxNombreRol.Location = new System.Drawing.Point(96, 53);
            this.textBoxNombreRol.Name = "textBoxNombreRol";
            this.textBoxNombreRol.Size = new System.Drawing.Size(169, 20);
            this.textBoxNombreRol.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de rol";
            // 
            // groupBoxRol
            // 
            this.groupBoxRol.Controls.Add(this.textBoxId);
            this.groupBoxRol.Controls.Add(this.label3);
            this.groupBoxRol.Controls.Add(this.checkBoxActivo);
            this.groupBoxRol.Controls.Add(this.listViewFuncionalidades);
            this.groupBoxRol.Controls.Add(this.label2);
            this.groupBoxRol.Controls.Add(this.label1);
            this.groupBoxRol.Controls.Add(this.textBoxNombreRol);
            this.groupBoxRol.Location = new System.Drawing.Point(12, 12);
            this.groupBoxRol.Name = "groupBoxRol";
            this.groupBoxRol.Size = new System.Drawing.Size(360, 245);
            this.groupBoxRol.TabIndex = 2;
            this.groupBoxRol.TabStop = false;
            this.groupBoxRol.Text = "Datos del rol";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(96, 27);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(169, 20);
            this.textBoxId.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Id de rol";
            // 
            // checkBoxActivo
            // 
            this.checkBoxActivo.AutoSize = true;
            this.checkBoxActivo.Checked = true;
            this.checkBoxActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActivo.Location = new System.Drawing.Point(9, 211);
            this.checkBoxActivo.Name = "checkBoxActivo";
            this.checkBoxActivo.Size = new System.Drawing.Size(74, 17);
            this.checkBoxActivo.TabIndex = 6;
            this.checkBoxActivo.Text = "Rol activo";
            this.checkBoxActivo.UseVisualStyleBackColor = true;
            // 
            // listViewFuncionalidades
            // 
            this.listViewFuncionalidades.CheckBoxes = true;
            this.listViewFuncionalidades.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Funcionalidad});
            this.listViewFuncionalidades.FullRowSelect = true;
            this.listViewFuncionalidades.Location = new System.Drawing.Point(96, 79);
            this.listViewFuncionalidades.Name = "listViewFuncionalidades";
            this.listViewFuncionalidades.Size = new System.Drawing.Size(257, 129);
            this.listViewFuncionalidades.TabIndex = 4;
            this.listViewFuncionalidades.UseCompatibleStateImageBehavior = false;
            this.listViewFuncionalidades.View = System.Windows.Forms.View.Details;
            // 
            // Funcionalidad
            // 
            this.Funcionalidad.Text = "Funcionalidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Funcionalidades";
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(12, 277);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 3;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(297, 277);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(75, 23);
            this.buttonModificar.TabIndex = 4;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(216, 277);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 5;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FormModificacionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 312);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.groupBoxRol);
            this.Name = "FormModificacionRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación de rol";
            this.Load += new System.EventHandler(this.FormAltaRol_Load);
            this.groupBoxRol.ResumeLayout(false);
            this.groupBoxRol.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombreRol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxRol;
        private System.Windows.Forms.CheckBox checkBoxActivo;
        private System.Windows.Forms.ListView listViewFuncionalidades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.ColumnHeader Funcionalidad;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label3;
    }
}