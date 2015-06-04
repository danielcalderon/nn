namespace PagoElectronico.ABM_Rol
{
    partial class UserControlListadoRoles
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewRoles = new System.Windows.Forms.ListView();
            this.Nombre = new System.Windows.Forms.ColumnHeader();
            this.Activo = new System.Windows.Forms.ColumnHeader();
            this.buttonAlta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewRoles
            // 
            this.listViewRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nombre,
            this.Activo});
            this.listViewRoles.Location = new System.Drawing.Point(3, 32);
            this.listViewRoles.Name = "listViewRoles";
            this.listViewRoles.Size = new System.Drawing.Size(594, 365);
            this.listViewRoles.TabIndex = 0;
            this.listViewRoles.UseCompatibleStateImageBehavior = false;
            this.listViewRoles.View = System.Windows.Forms.View.List;
            // 
            // Nombre
            // 
            this.Nombre.Text = "Nombre";
            // 
            // Activo
            // 
            this.Activo.Text = "Activo";
            // 
            // buttonAlta
            // 
            this.buttonAlta.Location = new System.Drawing.Point(522, 3);
            this.buttonAlta.Name = "buttonAlta";
            this.buttonAlta.Size = new System.Drawing.Size(75, 23);
            this.buttonAlta.TabIndex = 1;
            this.buttonAlta.Text = "Nuevo rol";
            this.buttonAlta.UseVisualStyleBackColor = true;
            this.buttonAlta.Click += new System.EventHandler(this.buttonAlta_Click);
            // 
            // UserControlListadoRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAlta);
            this.Controls.Add(this.listViewRoles);
            this.Name = "UserControlListadoRoles";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewRoles;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Activo;
        private System.Windows.Forms.Button buttonAlta;
    }
}
