namespace PagoElectronico.ABM_de_Usuario
{
    partial class FormCambiarPassword
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
            this.buttonCambiar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPasswordActual = new System.Windows.Forms.TextBox();
            this.textBoxRepetirNuevoPassword = new System.Windows.Forms.TextBox();
            this.textBoxNuevoPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCambiar
            // 
            this.buttonCambiar.Location = new System.Drawing.Point(215, 157);
            this.buttonCambiar.Name = "buttonCambiar";
            this.buttonCambiar.Size = new System.Drawing.Size(75, 23);
            this.buttonCambiar.TabIndex = 0;
            this.buttonCambiar.Text = "Cambiar";
            this.buttonCambiar.UseVisualStyleBackColor = true;
            this.buttonCambiar.Click += new System.EventHandler(this.buttonCambiar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(134, 157);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Contraseña actual";
            // 
            // textBoxPasswordActual
            // 
            this.textBoxPasswordActual.Location = new System.Drawing.Point(112, 49);
            this.textBoxPasswordActual.Name = "textBoxPasswordActual";
            this.textBoxPasswordActual.Size = new System.Drawing.Size(169, 20);
            this.textBoxPasswordActual.TabIndex = 3;
            // 
            // textBoxRepetirNuevoPassword
            // 
            this.textBoxRepetirNuevoPassword.Location = new System.Drawing.Point(112, 101);
            this.textBoxRepetirNuevoPassword.Name = "textBoxRepetirNuevoPassword";
            this.textBoxRepetirNuevoPassword.Size = new System.Drawing.Size(169, 20);
            this.textBoxRepetirNuevoPassword.TabIndex = 4;
            // 
            // textBoxNuevoPassword
            // 
            this.textBoxNuevoPassword.Location = new System.Drawing.Point(112, 75);
            this.textBoxNuevoPassword.Name = "textBoxNuevoPassword";
            this.textBoxNuevoPassword.Size = new System.Drawing.Size(169, 20);
            this.textBoxNuevoPassword.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Repetir contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nueva contraseña";
            // 
            // FormCambiarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 192);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNuevoPassword);
            this.Controls.Add(this.textBoxRepetirNuevoPassword);
            this.Controls.Add(this.textBoxPasswordActual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonCambiar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCambiarPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar contraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCambiar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPasswordActual;
        private System.Windows.Forms.TextBox textBoxRepetirNuevoPassword;
        private System.Windows.Forms.TextBox textBoxNuevoPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}