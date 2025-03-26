
namespace GUI
{
    partial class PantallaTasa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaTasa));
            this.pnLogin = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPwSAP = new System.Windows.Forms.TextBox();
            this.txtUserSAP = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pnTasa = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pbCarga = new System.Windows.Forms.ProgressBar();
            this.dtpFechaTasaFiltro = new System.Windows.Forms.DateTimePicker();
            this.btnValidar = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.chbIP = new System.Windows.Forms.CheckBox();
            this.chbAMSA = new System.Windows.Forms.CheckBox();
            this.chbINOPSA = new System.Windows.Forms.CheckBox();
            this.chbSXXI = new System.Windows.Forms.CheckBox();
            this.chbTP = new System.Windows.Forms.CheckBox();
            this.chbDP = new System.Windows.Forms.CheckBox();
            this.chbWYM = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbDuracreto = new System.Windows.Forms.CheckBox();
            this.dtpFechaTasa = new System.Windows.Forms.DateTimePicker();
            this.txtServerBD = new System.Windows.Forms.TextBox();
            this.txtPwBD = new System.Windows.Forms.TextBox();
            this.txtUserBD = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTasa = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnTasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLogin
            // 
            this.pnLogin.Controls.Add(this.btnSalir);
            this.pnLogin.Controls.Add(this.pictureBox2);
            this.pnLogin.Controls.Add(this.label3);
            this.pnLogin.Controls.Add(this.label5);
            this.pnLogin.Controls.Add(this.label6);
            this.pnLogin.Controls.Add(this.txtPwSAP);
            this.pnLogin.Controls.Add(this.txtUserSAP);
            this.pnLogin.Controls.Add(this.btnLogin);
            this.pnLogin.Controls.Add(this.pictureBox3);
            this.pnLogin.Location = new System.Drawing.Point(2, 2);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(579, 498);
            this.pnLogin.TabIndex = 46;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Brown;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalir.Location = new System.Drawing.Point(216, 329);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(143, 30);
            this.btnSalir.TabIndex = 65;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI.Properties.Resources.logo_sap;
            this.pictureBox2.Location = new System.Drawing.Point(234, 456);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(532, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "v1.0.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "Contraseña";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 39;
            this.label6.Text = "Usuario:";
            // 
            // txtPwSAP
            // 
            this.txtPwSAP.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPwSAP.Location = new System.Drawing.Point(216, 242);
            this.txtPwSAP.Name = "txtPwSAP";
            this.txtPwSAP.Size = new System.Drawing.Size(143, 22);
            this.txtPwSAP.TabIndex = 38;
            this.txtPwSAP.Text = "Sap1983";
            this.txtPwSAP.UseSystemPasswordChar = true;
            // 
            // txtUserSAP
            // 
            this.txtUserSAP.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUserSAP.Location = new System.Drawing.Point(216, 187);
            this.txtUserSAP.Name = "txtUserSAP";
            this.txtUserSAP.Size = new System.Drawing.Size(143, 22);
            this.txtUserSAP.TabIndex = 37;
            this.txtUserSAP.Text = "manager2";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Location = new System.Drawing.Point(216, 293);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(143, 30);
            this.btnLogin.TabIndex = 36;
            this.btnLogin.Text = "Iniciar sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::GUI.Properties.Resources.logo_gp;
            this.pictureBox3.Location = new System.Drawing.Point(164, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(239, 78);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            // 
            // pnTasa
            // 
            this.pnTasa.Controls.Add(this.pictureBox4);
            this.pnTasa.Controls.Add(this.pbCarga);
            this.pnTasa.Controls.Add(this.dtpFechaTasaFiltro);
            this.pnTasa.Controls.Add(this.btnValidar);
            this.pnTasa.Controls.Add(this.btnCerrarSesion);
            this.pnTasa.Controls.Add(this.chbIP);
            this.pnTasa.Controls.Add(this.chbAMSA);
            this.pnTasa.Controls.Add(this.chbINOPSA);
            this.pnTasa.Controls.Add(this.chbSXXI);
            this.pnTasa.Controls.Add(this.chbTP);
            this.pnTasa.Controls.Add(this.chbDP);
            this.pnTasa.Controls.Add(this.chbWYM);
            this.pnTasa.Controls.Add(this.label4);
            this.pnTasa.Controls.Add(this.chbDuracreto);
            this.pnTasa.Controls.Add(this.dtpFechaTasa);
            this.pnTasa.Controls.Add(this.txtServerBD);
            this.pnTasa.Controls.Add(this.txtPwBD);
            this.pnTasa.Controls.Add(this.txtUserBD);
            this.pnTasa.Controls.Add(this.btnActualizar);
            this.pnTasa.Controls.Add(this.label2);
            this.pnTasa.Controls.Add(this.label1);
            this.pnTasa.Controls.Add(this.txtTasa);
            this.pnTasa.Controls.Add(this.pictureBox1);
            this.pnTasa.Location = new System.Drawing.Point(2, 2);
            this.pnTasa.Name = "pnTasa";
            this.pnTasa.Size = new System.Drawing.Size(579, 498);
            this.pnTasa.TabIndex = 43;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::GUI.Properties.Resources.logo_sap;
            this.pictureBox4.Location = new System.Drawing.Point(234, 456);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(99, 22);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 69;
            this.pictureBox4.TabStop = false;
            // 
            // pbCarga
            // 
            this.pbCarga.Location = new System.Drawing.Point(312, 356);
            this.pbCarga.Name = "pbCarga";
            this.pbCarga.Size = new System.Drawing.Size(135, 20);
            this.pbCarga.TabIndex = 67;
            this.pbCarga.UseWaitCursor = true;
            // 
            // dtpFechaTasaFiltro
            // 
            this.dtpFechaTasaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTasaFiltro.Location = new System.Drawing.Point(26, 185);
            this.dtpFechaTasaFiltro.Name = "dtpFechaTasaFiltro";
            this.dtpFechaTasaFiltro.Size = new System.Drawing.Size(139, 22);
            this.dtpFechaTasaFiltro.TabIndex = 66;
            this.dtpFechaTasaFiltro.Value = new System.DateTime(2025, 3, 19, 11, 41, 4, 705);
            // 
            // btnValidar
            // 
            this.btnValidar.BackColor = System.Drawing.Color.OliveDrab;
            this.btnValidar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValidar.FlatAppearance.BorderSize = 0;
            this.btnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnValidar.Location = new System.Drawing.Point(26, 448);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(110, 30);
            this.btnValidar.TabIndex = 65;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = false;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Brown;
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrarSesion.Location = new System.Drawing.Point(431, 448);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(125, 30);
            this.btnCerrarSesion.TabIndex = 64;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // chbIP
            // 
            this.chbIP.AutoSize = true;
            this.chbIP.Location = new System.Drawing.Point(26, 329);
            this.chbIP.Name = "chbIP";
            this.chbIP.Size = new System.Drawing.Size(148, 21);
            this.chbIP.TabIndex = 63;
            this.chbIP.Text = "Inmobiliaria Platino";
            this.chbIP.UseVisualStyleBackColor = true;
            // 
            // chbAMSA
            // 
            this.chbAMSA.AutoSize = true;
            this.chbAMSA.Location = new System.Drawing.Point(26, 383);
            this.chbAMSA.Name = "chbAMSA";
            this.chbAMSA.Size = new System.Drawing.Size(68, 21);
            this.chbAMSA.TabIndex = 62;
            this.chbAMSA.Text = "AMSA";
            this.chbAMSA.UseVisualStyleBackColor = true;
            // 
            // chbINOPSA
            // 
            this.chbINOPSA.AutoSize = true;
            this.chbINOPSA.Location = new System.Drawing.Point(26, 356);
            this.chbINOPSA.Name = "chbINOPSA";
            this.chbINOPSA.Size = new System.Drawing.Size(81, 21);
            this.chbINOPSA.TabIndex = 61;
            this.chbINOPSA.Text = "INOPSA";
            this.chbINOPSA.UseVisualStyleBackColor = true;
            // 
            // chbSXXI
            // 
            this.chbSXXI.AutoSize = true;
            this.chbSXXI.Location = new System.Drawing.Point(26, 410);
            this.chbSXXI.Name = "chbSXXI";
            this.chbSXXI.Size = new System.Drawing.Size(86, 21);
            this.chbSXXI.TabIndex = 60;
            this.chbSXXI.Text = "Siglo XXI";
            this.chbSXXI.UseVisualStyleBackColor = true;
            // 
            // chbTP
            // 
            this.chbTP.AutoSize = true;
            this.chbTP.Location = new System.Drawing.Point(26, 302);
            this.chbTP.Name = "chbTP";
            this.chbTP.Size = new System.Drawing.Size(147, 21);
            this.chbTP.TabIndex = 59;
            this.chbTP.Text = "Transporte Platino";
            this.chbTP.UseVisualStyleBackColor = true;
            // 
            // chbDP
            // 
            this.chbDP.AutoSize = true;
            this.chbDP.Location = new System.Drawing.Point(26, 275);
            this.chbDP.Name = "chbDP";
            this.chbDP.Size = new System.Drawing.Size(157, 21);
            this.chbDP.TabIndex = 58;
            this.chbDP.Text = "Distribuidora Platino";
            this.chbDP.UseVisualStyleBackColor = true;
            // 
            // chbWYM
            // 
            this.chbWYM.AutoSize = true;
            this.chbWYM.Location = new System.Drawing.Point(26, 248);
            this.chbWYM.Name = "chbWYM";
            this.chbWYM.Size = new System.Drawing.Size(132, 21);
            this.chbWYM.TabIndex = 57;
            this.chbWYM.Text = "William && Molina";
            this.chbWYM.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 18);
            this.label4.TabIndex = 56;
            this.label4.Text = "Empresas con tasa de cambio:";
            // 
            // chbDuracreto
            // 
            this.chbDuracreto.AutoSize = true;
            this.chbDuracreto.Location = new System.Drawing.Point(26, 221);
            this.chbDuracreto.Name = "chbDuracreto";
            this.chbDuracreto.Size = new System.Drawing.Size(93, 21);
            this.chbDuracreto.TabIndex = 55;
            this.chbDuracreto.Text = "Duracreto";
            this.chbDuracreto.UseVisualStyleBackColor = true;
            // 
            // dtpFechaTasa
            // 
            this.dtpFechaTasa.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTasa.Location = new System.Drawing.Point(312, 221);
            this.dtpFechaTasa.Name = "dtpFechaTasa";
            this.dtpFechaTasa.Size = new System.Drawing.Size(139, 22);
            this.dtpFechaTasa.TabIndex = 54;
            this.dtpFechaTasa.Value = new System.DateTime(2025, 3, 19, 11, 41, 4, 705);
            // 
            // txtServerBD
            // 
            this.txtServerBD.Location = new System.Drawing.Point(456, 15);
            this.txtServerBD.Name = "txtServerBD";
            this.txtServerBD.ReadOnly = true;
            this.txtServerBD.Size = new System.Drawing.Size(100, 22);
            this.txtServerBD.TabIndex = 53;
            this.txtServerBD.Text = "NDB@192.168.1.9:30013";
            this.txtServerBD.Visible = false;
            // 
            // txtPwBD
            // 
            this.txtPwBD.Location = new System.Drawing.Point(456, 71);
            this.txtPwBD.Name = "txtPwBD";
            this.txtPwBD.ReadOnly = true;
            this.txtPwBD.Size = new System.Drawing.Size(100, 22);
            this.txtPwBD.TabIndex = 52;
            this.txtPwBD.Text = "Sap5erver";
            this.txtPwBD.UseSystemPasswordChar = true;
            this.txtPwBD.Visible = false;
            // 
            // txtUserBD
            // 
            this.txtUserBD.Location = new System.Drawing.Point(456, 43);
            this.txtUserBD.Name = "txtUserBD";
            this.txtUserBD.ReadOnly = true;
            this.txtUserBD.Size = new System.Drawing.Size(100, 22);
            this.txtUserBD.TabIndex = 51;
            this.txtUserBD.Text = "SYSTEM";
            this.txtUserBD.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnActualizar.Location = new System.Drawing.Point(312, 302);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(114, 30);
            this.btnActualizar.TabIndex = 50;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(338, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "Actualización de tasa de cambio global";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 152);
            this.label1.MaximumSize = new System.Drawing.Size(250, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 54);
            this.label1.TabIndex = 48;
            this.label1.Text = "Seleccione la fecha e ingrese el tipo de cambio para las empresas seleccionadas:";
            // 
            // txtTasa
            // 
            this.txtTasa.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTasa.Location = new System.Drawing.Point(312, 260);
            this.txtTasa.Name = "txtTasa";
            this.txtTasa.Size = new System.Drawing.Size(139, 22);
            this.txtTasa.TabIndex = 47;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.logo_gp;
            this.pictureBox1.Location = new System.Drawing.Point(164, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // PantallaTasa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(583, 502);
            this.Controls.Add(this.pnTasa);
            this.Controls.Add(this.pnLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(601, 549);
            this.MinimumSize = new System.Drawing.Size(601, 549);
            this.Name = "PantallaTasa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupo Platino";
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnTasa.ResumeLayout(false);
            this.pnTasa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPwSAP;
        private System.Windows.Forms.TextBox txtUserSAP;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel pnTasa;
        private System.Windows.Forms.ProgressBar pbCarga;
        private System.Windows.Forms.DateTimePicker dtpFechaTasaFiltro;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.CheckBox chbIP;
        private System.Windows.Forms.CheckBox chbAMSA;
        private System.Windows.Forms.CheckBox chbINOPSA;
        private System.Windows.Forms.CheckBox chbSXXI;
        private System.Windows.Forms.CheckBox chbTP;
        private System.Windows.Forms.CheckBox chbDP;
        private System.Windows.Forms.CheckBox chbWYM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbDuracreto;
        private System.Windows.Forms.DateTimePicker dtpFechaTasa;
        private System.Windows.Forms.TextBox txtServerBD;
        private System.Windows.Forms.TextBox txtPwBD;
        private System.Windows.Forms.TextBox txtUserBD;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTasa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnSalir;
    }
}

