﻿namespace PagoElectronico.ABM_Tarjeta
{
    partial class FormModificacionTarjeta
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
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePickerFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxEmisor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCodigoSeguridad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUltimos4digitos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.checkBoxActivo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(258, 191);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 0;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(177, 191);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 1;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxActivo);
            this.groupBox1.Controls.Add(this.dateTimePickerFechaVencimiento);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxEmisor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxCodigoSeguridad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxUltimos4digitos);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 166);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la tarjeta";
            // 
            // dateTimePickerFechaVencimiento
            // 
            this.dateTimePickerFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFechaVencimiento.Location = new System.Drawing.Point(124, 108);
            this.dateTimePickerFechaVencimiento.Name = "dateTimePickerFechaVencimiento";
            this.dateTimePickerFechaVencimiento.Size = new System.Drawing.Size(169, 20);
            this.dateTimePickerFechaVencimiento.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Emisor";
            // 
            // comboBoxEmisor
            // 
            this.comboBoxEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmisor.FormattingEnabled = true;
            this.comboBoxEmisor.Location = new System.Drawing.Point(124, 81);
            this.comboBoxEmisor.Name = "comboBoxEmisor";
            this.comboBoxEmisor.Size = new System.Drawing.Size(169, 21);
            this.comboBoxEmisor.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha de vencimiento";
            // 
            // textBoxCodigoSeguridad
            // 
            this.textBoxCodigoSeguridad.Location = new System.Drawing.Point(124, 56);
            this.textBoxCodigoSeguridad.Name = "textBoxCodigoSeguridad";
            this.textBoxCodigoSeguridad.PasswordChar = '•';
            this.textBoxCodigoSeguridad.Size = new System.Drawing.Size(169, 20);
            this.textBoxCodigoSeguridad.TabIndex = 3;
            this.textBoxCodigoSeguridad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumero_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Código de seguridad";
            // 
            // textBoxUltimos4digitos
            // 
            this.textBoxUltimos4digitos.Enabled = false;
            this.textBoxUltimos4digitos.Location = new System.Drawing.Point(124, 30);
            this.textBoxUltimos4digitos.Name = "textBoxUltimos4digitos";
            this.textBoxUltimos4digitos.Size = new System.Drawing.Size(169, 20);
            this.textBoxUltimos4digitos.TabIndex = 1;
            this.textBoxUltimos4digitos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumero_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Últimos 4 dígitos";
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(12, 191);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 7;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // checkBoxActivo
            // 
            this.checkBoxActivo.AutoSize = true;
            this.checkBoxActivo.Location = new System.Drawing.Point(9, 143);
            this.checkBoxActivo.Name = "checkBoxActivo";
            this.checkBoxActivo.Size = new System.Drawing.Size(105, 17);
            this.checkBoxActivo.TabIndex = 29;
            this.checkBoxActivo.Text = "Tarjeta asociada";
            this.checkBoxActivo.UseVisualStyleBackColor = true;
            // 
            // FormModificacionTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 226);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormModificacionTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificación de tarjeta";
            this.Load += new System.EventHandler(this.FormAltaUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUltimos4digitos;
        private System.Windows.Forms.TextBox textBoxCodigoSeguridad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.ComboBox comboBoxEmisor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaVencimiento;
        private System.Windows.Forms.CheckBox checkBoxActivo;
    }
}