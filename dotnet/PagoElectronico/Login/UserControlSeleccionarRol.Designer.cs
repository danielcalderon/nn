namespace PagoElectronico.Login
{
    partial class UserControlSeleccionarRol
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar rol";
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.DataSource = this.rolBindingSource;
            this.comboBoxRoles.DisplayMember = "Nombre";
            this.comboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(109, 59);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(167, 21);
            this.comboBoxRoles.TabIndex = 1;
            this.comboBoxRoles.ValueMember = "Id";
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(201, 98);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 2;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // UserControlSeleccionarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.label1);
            this.Name = "UserControlSeleccionarRol";
            this.Size = new System.Drawing.Size(294, 168);
            this.Load += new System.EventHandler(this.UserControlSeleccionarRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.BindingSource rolBindingSource;
    }
}
