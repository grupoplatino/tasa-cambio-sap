
namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtPwSAP = new System.Windows.Forms.TextBox();
            this.txtUserSAP = new System.Windows.Forms.TextBox();
            this.txtServerBD = new System.Windows.Forms.TextBox();
            this.txtPwBD = new System.Windows.Forms.TextBox();
            this.txtUserBD = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtpFechaTasa = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPwSAP
            // 
            this.txtPwSAP.Location = new System.Drawing.Point(470, 123);
            this.txtPwSAP.Name = "txtPwSAP";
            this.txtPwSAP.ReadOnly = true;
            this.txtPwSAP.Size = new System.Drawing.Size(100, 22);
            this.txtPwSAP.TabIndex = 28;
            this.txtPwSAP.Text = "Sap1983";
            this.txtPwSAP.UseSystemPasswordChar = true;
            this.txtPwSAP.Visible = false;
            // 
            // txtUserSAP
            // 
            this.txtUserSAP.Location = new System.Drawing.Point(470, 95);
            this.txtUserSAP.Name = "txtUserSAP";
            this.txtUserSAP.ReadOnly = true;
            this.txtUserSAP.Size = new System.Drawing.Size(100, 22);
            this.txtUserSAP.TabIndex = 27;
            this.txtUserSAP.Text = "manager2";
            this.txtUserSAP.Visible = false;
            // 
            // txtServerBD
            // 
            this.txtServerBD.Location = new System.Drawing.Point(470, 11);
            this.txtServerBD.Name = "txtServerBD";
            this.txtServerBD.ReadOnly = true;
            this.txtServerBD.Size = new System.Drawing.Size(100, 22);
            this.txtServerBD.TabIndex = 26;
            this.txtServerBD.Text = "NDB@192.168.1.9:30013";
            this.txtServerBD.Visible = false;
            // 
            // txtPwBD
            // 
            this.txtPwBD.Location = new System.Drawing.Point(470, 67);
            this.txtPwBD.Name = "txtPwBD";
            this.txtPwBD.ReadOnly = true;
            this.txtPwBD.Size = new System.Drawing.Size(100, 22);
            this.txtPwBD.TabIndex = 25;
            this.txtPwBD.Text = "Sap5erver";
            this.txtPwBD.UseSystemPasswordChar = true;
            this.txtPwBD.Visible = false;
            // 
            // txtUserBD
            // 
            this.txtUserBD.Location = new System.Drawing.Point(470, 39);
            this.txtUserBD.Name = "txtUserBD";
            this.txtUserBD.ReadOnly = true;
            this.txtUserBD.Size = new System.Drawing.Size(100, 22);
            this.txtUserBD.TabIndex = 24;
            this.txtUserBD.Text = "SYSTEM";
            this.txtUserBD.Visible = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(12, 345);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 17);
            this.lblMensaje.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(532, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "v1.0.0";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnActualizar.Location = new System.Drawing.Point(227, 278);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(114, 38);
            this.btnActualizar.TabIndex = 21;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Actualización de tasa de cambio global";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "Seleccione la fecha e ingrese la tasa de cambio:";
            // 
            // txtTasa
            // 
            this.txtTasa.Location = new System.Drawing.Point(213, 242);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(139, 22);
            this.txtTasa.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.logo_gp;
            this.pictureBox1.Location = new System.Drawing.Point(171, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // dtpFechaTasa
            // 
            this.dtpFechaTasa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTasa.Location = new System.Drawing.Point(213, 208);
            this.dtpFechaTasa.MinDate = new System.DateTime(2025, 3, 18, 13, 36, 21, 257);
            this.dtpFechaTasa.Name = "dtpFechaTasa";
            this.dtpFechaTasa.Size = new System.Drawing.Size(139, 22);
            this.dtpFechaTasa.TabIndex = 29;
            this.dtpFechaTasa.Value = new System.DateTime(2025, 3, 18, 13, 36, 21, 257);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(581, 371);
            this.Controls.Add(this.dtpFechaTasa);
            this.Controls.Add(this.txtPwSAP);
            this.Controls.Add(this.txtUserSAP);
            this.Controls.Add(this.txtServerBD);
            this.Controls.Add(this.txtPwBD);
            this.Controls.Add(this.txtUserBD);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTasa);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(599, 418);
            this.MinimumSize = new System.Drawing.Size(599, 399);
            this.Name = "Form1";
            this.Text = "Grupo Platino";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPwSAP;
        private System.Windows.Forms.TextBox txtUserSAP;
        private System.Windows.Forms.TextBox txtServerBD;
        private System.Windows.Forms.TextBox txtPwBD;
        private System.Windows.Forms.TextBox txtUserBD;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtpFechaTasa;
    }
}

