namespace PagoElectronico.ABM_de_Usuario
{
    partial class UserControlListadoUsuarios
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
            this.buttonCrear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCrear
            // 
            this.buttonCrear.Location = new System.Drawing.Point(50, 56);
            this.buttonCrear.Name = "buttonCrear";
            this.buttonCrear.Size = new System.Drawing.Size(75, 23);
            this.buttonCrear.TabIndex = 0;
            this.buttonCrear.Text = "Nuevo";
            this.buttonCrear.UseVisualStyleBackColor = true;
            this.buttonCrear.Click += new System.EventHandler(this.buttonCrear_Click);
            // 
            // UserControlListadoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCrear);
            this.Name = "UserControlListadoUsuarios";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCrear;

    }
}
