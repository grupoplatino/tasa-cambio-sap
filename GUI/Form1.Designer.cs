
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtpFechaTasa = new System.Windows.Forms.DateTimePicker();
            this.chbDuracreto = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbWYM = new System.Windows.Forms.CheckBox();
            this.chbDP = new System.Windows.Forms.CheckBox();
            this.chbTP = new System.Windows.Forms.CheckBox();
            this.chbSXXI = new System.Windows.Forms.CheckBox();
            this.chbINOPSA = new System.Windows.Forms.CheckBox();
            this.chbAMSA = new System.Windows.Forms.CheckBox();
            this.chbESMV = new System.Windows.Forms.CheckBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.dtpFechaTasaFiltro = new System.Windows.Forms.DateTimePicker();
            this.pbCarga = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPwSAP
            // 
            this.txtPwSAP.Location = new System.Drawing.Point(459, 127);
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
            this.txtUserSAP.Location = new System.Drawing.Point(459, 99);
            this.txtUserSAP.Name = "txtUserSAP";
            this.txtUserSAP.ReadOnly = true;
            this.txtUserSAP.Size = new System.Drawing.Size(100, 22);
            this.txtUserSAP.TabIndex = 27;
            this.txtUserSAP.Text = "manager2";
            this.txtUserSAP.Visible = false;
            // 
            // txtServerBD
            // 
            this.txtServerBD.Location = new System.Drawing.Point(459, 15);
            this.txtServerBD.Name = "txtServerBD";
            this.txtServerBD.ReadOnly = true;
            this.txtServerBD.Size = new System.Drawing.Size(100, 22);
            this.txtServerBD.TabIndex = 26;
            this.txtServerBD.Text = "NDB@192.168.1.9:30013";
            this.txtServerBD.Visible = false;
            // 
            // txtPwBD
            // 
            this.txtPwBD.Location = new System.Drawing.Point(459, 71);
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
            this.txtUserBD.Location = new System.Drawing.Point(459, 43);
            this.txtUserBD.Name = "txtUserBD";
            this.txtUserBD.ReadOnly = true;
            this.txtUserBD.Size = new System.Drawing.Size(100, 22);
            this.txtUserBD.TabIndex = 24;
            this.txtUserBD.Text = "SYSTEM";
            this.txtUserBD.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(543, 492);
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
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnActualizar.Location = new System.Drawing.Point(315, 302);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(114, 30);
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
            this.label2.Location = new System.Drawing.Point(97, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Actualización de tasa de cambio global";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(312, 152);
            this.label1.MaximumSize = new System.Drawing.Size(250, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 54);
            this.label1.TabIndex = 19;
            this.label1.Text = "Seleccione la fecha e ingrese el tipo de cambio para las empresas seleccionadas:";
            // 
            // txtTasa
            // 
            this.txtTasa.Location = new System.Drawing.Point(315, 260);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(139, 22);
            this.txtTasa.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.logo_gp;
            this.pictureBox1.Location = new System.Drawing.Point(167, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // dtpFechaTasa
            // 
            this.dtpFechaTasa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTasa.Location = new System.Drawing.Point(315, 221);
            this.dtpFechaTasa.Name = "dtpFechaTasa";
            this.dtpFechaTasa.Size = new System.Drawing.Size(139, 22);
            this.dtpFechaTasa.TabIndex = 29;
            this.dtpFechaTasa.Value = new System.DateTime(2025, 3, 19, 11, 41, 4, 705);
            // 
            // chbDuracreto
            // 
            this.chbDuracreto.AutoSize = true;
            this.chbDuracreto.Location = new System.Drawing.Point(29, 221);
            this.chbDuracreto.Name = "chbDuracreto";
            this.chbDuracreto.Size = new System.Drawing.Size(93, 21);
            this.chbDuracreto.TabIndex = 30;
            this.chbDuracreto.Text = "Duracreto";
            this.chbDuracreto.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "Empresas con tasa de cambio:";
            // 
            // chbWYM
            // 
            this.chbWYM.AutoSize = true;
            this.chbWYM.Location = new System.Drawing.Point(29, 248);
            this.chbWYM.Name = "chbWYM";
            this.chbWYM.Size = new System.Drawing.Size(130, 21);
            this.chbWYM.TabIndex = 32;
            this.chbWYM.Text = "William y Molina";
            this.chbWYM.UseVisualStyleBackColor = true;
            // 
            // chbDP
            // 
            this.chbDP.AutoSize = true;
            this.chbDP.Location = new System.Drawing.Point(29, 275);
            this.chbDP.Name = "chbDP";
            this.chbDP.Size = new System.Drawing.Size(157, 21);
            this.chbDP.TabIndex = 33;
            this.chbDP.Text = "Distribuidora Platino";
            this.chbDP.UseVisualStyleBackColor = true;
            // 
            // chbTP
            // 
            this.chbTP.AutoSize = true;
            this.chbTP.Location = new System.Drawing.Point(29, 302);
            this.chbTP.Name = "chbTP";
            this.chbTP.Size = new System.Drawing.Size(147, 21);
            this.chbTP.TabIndex = 34;
            this.chbTP.Text = "Transporte Platino";
            this.chbTP.UseVisualStyleBackColor = true;
            // 
            // chbSXXI
            // 
            this.chbSXXI.AutoSize = true;
            this.chbSXXI.Location = new System.Drawing.Point(29, 329);
            this.chbSXXI.Name = "chbSXXI";
            this.chbSXXI.Size = new System.Drawing.Size(86, 21);
            this.chbSXXI.TabIndex = 35;
            this.chbSXXI.Text = "Siglo XXI";
            this.chbSXXI.UseVisualStyleBackColor = true;
            // 
            // chbINOPSA
            // 
            this.chbINOPSA.AutoSize = true;
            this.chbINOPSA.Location = new System.Drawing.Point(29, 356);
            this.chbINOPSA.Name = "chbINOPSA";
            this.chbINOPSA.Size = new System.Drawing.Size(81, 21);
            this.chbINOPSA.TabIndex = 36;
            this.chbINOPSA.Text = "INOPSA";
            this.chbINOPSA.UseVisualStyleBackColor = true;
            // 
            // chbAMSA
            // 
            this.chbAMSA.AutoSize = true;
            this.chbAMSA.Location = new System.Drawing.Point(29, 383);
            this.chbAMSA.Name = "chbAMSA";
            this.chbAMSA.Size = new System.Drawing.Size(68, 21);
            this.chbAMSA.TabIndex = 37;
            this.chbAMSA.Text = "AMSA";
            this.chbAMSA.UseVisualStyleBackColor = true;
            // 
            // chbESMV
            // 
            this.chbESMV.AutoSize = true;
            this.chbESMV.Location = new System.Drawing.Point(29, 410);
            this.chbESMV.Name = "chbESMV";
            this.chbESMV.Size = new System.Drawing.Size(218, 21);
            this.chbESMV.TabIndex = 38;
            this.chbESMV.Text = "Escuela Santa María del Valle";
            this.chbESMV.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Brown;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrar.Location = new System.Drawing.Point(459, 449);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 30);
            this.btnCerrar.TabIndex = 41;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = System.Drawing.Color.OliveDrab;
            this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrescar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefrescar.Location = new System.Drawing.Point(29, 448);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(110, 30);
            this.btnRefrescar.TabIndex = 42;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // dtpFechaTasaFiltro
            // 
            this.dtpFechaTasaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTasaFiltro.Location = new System.Drawing.Point(29, 185);
            this.dtpFechaTasaFiltro.Name = "dtpFechaTasaFiltro";
            this.dtpFechaTasaFiltro.Size = new System.Drawing.Size(139, 22);
            this.dtpFechaTasaFiltro.TabIndex = 44;
            this.dtpFechaTasaFiltro.Value = new System.DateTime(2025, 3, 19, 11, 41, 4, 705);
            // 
            // pbCarga
            // 
            this.pbCarga.Location = new System.Drawing.Point(227, 453);
            this.pbCarga.Name = "pbCarga";
            this.pbCarga.Size = new System.Drawing.Size(135, 20);
            this.pbCarga.TabIndex = 45;
            this.pbCarga.UseWaitCursor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(583, 509);
            this.Controls.Add(this.pbCarga);
            this.Controls.Add(this.dtpFechaTasaFiltro);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.chbESMV);
            this.Controls.Add(this.chbAMSA);
            this.Controls.Add(this.chbINOPSA);
            this.Controls.Add(this.chbSXXI);
            this.Controls.Add(this.chbTP);
            this.Controls.Add(this.chbDP);
            this.Controls.Add(this.chbWYM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbDuracreto);
            this.Controls.Add(this.dtpFechaTasa);
            this.Controls.Add(this.txtPwSAP);
            this.Controls.Add(this.txtUserSAP);
            this.Controls.Add(this.txtServerBD);
            this.Controls.Add(this.txtPwBD);
            this.Controls.Add(this.txtUserBD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTasa);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(601, 556);
            this.MinimumSize = new System.Drawing.Size(601, 556);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupo Platino";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtpFechaTasa;
        private System.Windows.Forms.CheckBox chbDuracreto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbWYM;
        private System.Windows.Forms.CheckBox chbDP;
        private System.Windows.Forms.CheckBox chbTP;
        private System.Windows.Forms.CheckBox chbSXXI;
        private System.Windows.Forms.CheckBox chbINOPSA;
        private System.Windows.Forms.CheckBox chbAMSA;
        private System.Windows.Forms.CheckBox chbESMV;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.DateTimePicker dtpFechaTasaFiltro;
        private System.Windows.Forms.ProgressBar pbCarga;
    }
}

