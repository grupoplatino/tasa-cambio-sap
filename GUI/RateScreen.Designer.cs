namespace GUI
{
    partial class RateScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RateScreen));
            this.pnLogin = new System.Windows.Forms.Panel();
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtUserSAP2 = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pbxLogoSAP1 = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblUserSAP2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pbxLogoGP1 = new System.Windows.Forms.PictureBox();
            this.pbLogin = new System.Windows.Forms.ProgressBar();
            this.pnTasa = new System.Windows.Forms.Panel();
            this.chbAA = new System.Windows.Forms.CheckBox();
            this.verticalSeparator1 = new GUI.VerticalSeparator();
            this.chbESMV = new System.Windows.Forms.CheckBox();
            this.chbINVP = new System.Windows.Forms.CheckBox();
            this.chbSCP = new System.Windows.Forms.CheckBox();
            this.pbcLogoSAP2 = new System.Windows.Forms.PictureBox();
            this.pbRate = new System.Windows.Forms.ProgressBar();
            this.dtpFilterRateDate = new System.Windows.Forms.DateTimePicker();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.chbIP = new System.Windows.Forms.CheckBox();
            this.chbAMSA = new System.Windows.Forms.CheckBox();
            this.chbINOPSA = new System.Windows.Forms.CheckBox();
            this.chbSXXI = new System.Windows.Forms.CheckBox();
            this.chbTP = new System.Windows.Forms.CheckBox();
            this.chbDP = new System.Windows.Forms.CheckBox();
            this.chbWYM = new System.Windows.Forms.CheckBox();
            this.lblDescription1 = new System.Windows.Forms.Label();
            this.chbDC = new System.Windows.Forms.CheckBox();
            this.dtpRateDate = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription2 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.pbxLogoGP2 = new System.Windows.Forms.PictureBox();
            this.pnLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoSAP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoGP1)).BeginInit();
            this.pnTasa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcLogoSAP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoGP2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLogin
            // 
            this.pnLogin.Controls.Add(this.lblSerie);
            this.pnLogin.Controls.Add(this.lblHost);
            this.pnLogin.Controls.Add(this.txtUserSAP2);
            this.pnLogin.Controls.Add(this.btnExit);
            this.pnLogin.Controls.Add(this.pbxLogoSAP1);
            this.pnLogin.Controls.Add(this.lblVersion);
            this.pnLogin.Controls.Add(this.lblUserSAP2);
            this.pnLogin.Controls.Add(this.btnLogin);
            this.pnLogin.Controls.Add(this.pbxLogoGP1);
            this.pnLogin.Controls.Add(this.pbLogin);
            this.pnLogin.Location = new System.Drawing.Point(2, 2);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Size = new System.Drawing.Size(709, 498);
            this.pnLogin.TabIndex = 46;
            // 
            // lblSerie
            // 
            this.lblSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblSerie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSerie.Location = new System.Drawing.Point(7, 22);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(86, 13);
            this.lblSerie.TabIndex = 73;
            this.lblSerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHost
            // 
            this.lblHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblHost.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHost.Location = new System.Drawing.Point(7, 7);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(86, 13);
            this.lblHost.TabIndex = 72;
            this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUserSAP2
            // 
            this.txtUserSAP2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUserSAP2.Location = new System.Drawing.Point(280, 220);
            this.txtUserSAP2.Name = "txtUserSAP2";
            this.txtUserSAP2.Size = new System.Drawing.Size(143, 22);
            this.txtUserSAP2.TabIndex = 71;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Firebrick;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Location = new System.Drawing.Point(280, 458);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(143, 30);
            this.btnExit.TabIndex = 65;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbxLogoSAP1
            // 
            this.pbxLogoSAP1.Image = global::GUI.Properties.Resources.logo_sap;
            this.pbxLogoSAP1.Location = new System.Drawing.Point(10, 466);
            this.pbxLogoSAP1.Name = "pbxLogoSAP1";
            this.pbxLogoSAP1.Size = new System.Drawing.Size(99, 22);
            this.pbxLogoSAP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogoSAP1.TabIndex = 42;
            this.pbxLogoSAP1.TabStop = false;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblVersion.Location = new System.Drawing.Point(661, 478);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(37, 13);
            this.lblVersion.TabIndex = 41;
            this.lblVersion.Text = "v1.0.0";
            // 
            // lblUserSAP2
            // 
            this.lblUserSAP2.AutoSize = true;
            this.lblUserSAP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserSAP2.Location = new System.Drawing.Point(278, 198);
            this.lblUserSAP2.Name = "lblUserSAP2";
            this.lblUserSAP2.Size = new System.Drawing.Size(95, 16);
            this.lblUserSAP2.TabIndex = 39;
            this.lblUserSAP2.Text = "Usuario SAP";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogin.Location = new System.Drawing.Point(280, 254);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(143, 30);
            this.btnLogin.TabIndex = 36;
            this.btnLogin.Text = "Iniciar sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pbxLogoGP1
            // 
            this.pbxLogoGP1.Image = global::GUI.Properties.Resources.logo_gp;
            this.pbxLogoGP1.Location = new System.Drawing.Point(229, 21);
            this.pbxLogoGP1.Name = "pbxLogoGP1";
            this.pbxLogoGP1.Size = new System.Drawing.Size(239, 78);
            this.pbxLogoGP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogoGP1.TabIndex = 35;
            this.pbxLogoGP1.TabStop = false;
            // 
            // pbLogin
            // 
            this.pbLogin.Location = new System.Drawing.Point(281, 421);
            this.pbLogin.Name = "pbLogin";
            this.pbLogin.Size = new System.Drawing.Size(142, 20);
            this.pbLogin.TabIndex = 74;
            this.pbLogin.UseWaitCursor = true;
            // 
            // pnTasa
            // 
            this.pnTasa.Controls.Add(this.chbAA);
            this.pnTasa.Controls.Add(this.verticalSeparator1);
            this.pnTasa.Controls.Add(this.chbESMV);
            this.pnTasa.Controls.Add(this.chbINVP);
            this.pnTasa.Controls.Add(this.chbSCP);
            this.pnTasa.Controls.Add(this.pbcLogoSAP2);
            this.pnTasa.Controls.Add(this.pbRate);
            this.pnTasa.Controls.Add(this.dtpFilterRateDate);
            this.pnTasa.Controls.Add(this.btnValidate);
            this.pnTasa.Controls.Add(this.btnLogout);
            this.pnTasa.Controls.Add(this.chbIP);
            this.pnTasa.Controls.Add(this.chbAMSA);
            this.pnTasa.Controls.Add(this.chbINOPSA);
            this.pnTasa.Controls.Add(this.chbSXXI);
            this.pnTasa.Controls.Add(this.chbTP);
            this.pnTasa.Controls.Add(this.chbDP);
            this.pnTasa.Controls.Add(this.chbWYM);
            this.pnTasa.Controls.Add(this.lblDescription1);
            this.pnTasa.Controls.Add(this.chbDC);
            this.pnTasa.Controls.Add(this.dtpRateDate);
            this.pnTasa.Controls.Add(this.btnUpdate);
            this.pnTasa.Controls.Add(this.lblTitle);
            this.pnTasa.Controls.Add(this.lblDescription2);
            this.pnTasa.Controls.Add(this.txtRate);
            this.pnTasa.Controls.Add(this.pbxLogoGP2);
            this.pnTasa.Location = new System.Drawing.Point(2, 2);
            this.pnTasa.Name = "pnTasa";
            this.pnTasa.Size = new System.Drawing.Size(709, 498);
            this.pnTasa.TabIndex = 43;
            // 
            // chbAA
            // 
            this.chbAA.AutoSize = true;
            this.chbAA.Location = new System.Drawing.Point(263, 302);
            this.chbAA.Name = "chbAA";
            this.chbAA.Size = new System.Drawing.Size(112, 20);
            this.chbAA.TabIndex = 74;
            this.chbAA.Text = "Autos Aliados";
            this.chbAA.UseVisualStyleBackColor = true;
            // 
            // verticalSeparator1
            // 
            this.verticalSeparator1.BackColor = System.Drawing.Color.Gainsboro;
            this.verticalSeparator1.Location = new System.Drawing.Point(407, 155);
            this.verticalSeparator1.Name = "verticalSeparator1";
            this.verticalSeparator1.Size = new System.Drawing.Size(1, 275);
            this.verticalSeparator1.TabIndex = 73;
            this.verticalSeparator1.Text = "verticalSeparator1";
            // 
            // chbESMV
            // 
            this.chbESMV.AutoSize = true;
            this.chbESMV.Location = new System.Drawing.Point(26, 382);
            this.chbESMV.Name = "chbESMV";
            this.chbESMV.Size = new System.Drawing.Size(209, 20);
            this.chbESMV.TabIndex = 72;
            this.chbESMV.Text = "Escuela Santa Maria del Valle";
            this.chbESMV.UseVisualStyleBackColor = true;
            // 
            // chbINVP
            // 
            this.chbINVP.AutoSize = true;
            this.chbINVP.Location = new System.Drawing.Point(26, 408);
            this.chbINVP.Name = "chbINVP";
            this.chbINVP.Size = new System.Drawing.Size(142, 20);
            this.chbINVP.TabIndex = 71;
            this.chbINVP.Text = "Inversiones Platino";
            this.chbINVP.UseVisualStyleBackColor = true;
            // 
            // chbSCP
            // 
            this.chbSCP.AutoSize = true;
            this.chbSCP.Location = new System.Drawing.Point(26, 356);
            this.chbSCP.Name = "chbSCP";
            this.chbSCP.Size = new System.Drawing.Size(165, 20);
            this.chbSCP.TabIndex = 70;
            this.chbSCP.Text = "Servicios Corporativos";
            this.chbSCP.UseVisualStyleBackColor = true;
            // 
            // pbcLogoSAP2
            // 
            this.pbcLogoSAP2.Image = global::GUI.Properties.Resources.logo_sap;
            this.pbcLogoSAP2.Location = new System.Drawing.Point(307, 456);
            this.pbcLogoSAP2.Name = "pbcLogoSAP2";
            this.pbcLogoSAP2.Size = new System.Drawing.Size(99, 22);
            this.pbcLogoSAP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcLogoSAP2.TabIndex = 69;
            this.pbcLogoSAP2.TabStop = false;
            // 
            // pbRate
            // 
            this.pbRate.Location = new System.Drawing.Point(448, 356);
            this.pbRate.Name = "pbRate";
            this.pbRate.Size = new System.Drawing.Size(135, 20);
            this.pbRate.TabIndex = 67;
            this.pbRate.UseWaitCursor = true;
            // 
            // dtpFilterRateDate
            // 
            this.dtpFilterRateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterRateDate.Location = new System.Drawing.Point(26, 185);
            this.dtpFilterRateDate.Name = "dtpFilterRateDate";
            this.dtpFilterRateDate.Size = new System.Drawing.Size(139, 22);
            this.dtpFilterRateDate.TabIndex = 66;
            this.dtpFilterRateDate.Value = new System.DateTime(2025, 3, 19, 11, 41, 4, 705);
            // 
            // btnValidate
            // 
            this.btnValidate.BackColor = System.Drawing.Color.OliveDrab;
            this.btnValidate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValidate.FlatAppearance.BorderSize = 0;
            this.btnValidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnValidate.Location = new System.Drawing.Point(26, 448);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(110, 30);
            this.btnValidate.TabIndex = 65;
            this.btnValidate.Text = "Validar";
            this.btnValidate.UseVisualStyleBackColor = false;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Brown;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnLogout.Location = new System.Drawing.Point(557, 448);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(125, 30);
            this.btnLogout.TabIndex = 64;
            this.btnLogout.Text = "Cerrar sesión";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // chbIP
            // 
            this.chbIP.AutoSize = true;
            this.chbIP.Location = new System.Drawing.Point(26, 329);
            this.chbIP.Name = "chbIP";
            this.chbIP.Size = new System.Drawing.Size(142, 20);
            this.chbIP.TabIndex = 63;
            this.chbIP.Text = "Inmobiliaria Platino";
            this.chbIP.UseVisualStyleBackColor = true;
            // 
            // chbAMSA
            // 
            this.chbAMSA.AutoSize = true;
            this.chbAMSA.Location = new System.Drawing.Point(263, 275);
            this.chbAMSA.Name = "chbAMSA";
            this.chbAMSA.Size = new System.Drawing.Size(67, 20);
            this.chbAMSA.TabIndex = 62;
            this.chbAMSA.Text = "AMSA";
            this.chbAMSA.UseVisualStyleBackColor = true;
            // 
            // chbINOPSA
            // 
            this.chbINOPSA.AutoSize = true;
            this.chbINOPSA.Location = new System.Drawing.Point(263, 222);
            this.chbINOPSA.Name = "chbINOPSA";
            this.chbINOPSA.Size = new System.Drawing.Size(79, 20);
            this.chbINOPSA.TabIndex = 61;
            this.chbINOPSA.Text = "INOPSA";
            this.chbINOPSA.UseVisualStyleBackColor = true;
            // 
            // chbSXXI
            // 
            this.chbSXXI.AutoSize = true;
            this.chbSXXI.Location = new System.Drawing.Point(263, 249);
            this.chbSXXI.Name = "chbSXXI";
            this.chbSXXI.Size = new System.Drawing.Size(82, 20);
            this.chbSXXI.TabIndex = 60;
            this.chbSXXI.Text = "Siglo XXI";
            this.chbSXXI.UseVisualStyleBackColor = true;
            // 
            // chbTP
            // 
            this.chbTP.AutoSize = true;
            this.chbTP.Location = new System.Drawing.Point(26, 302);
            this.chbTP.Name = "chbTP";
            this.chbTP.Size = new System.Drawing.Size(146, 20);
            this.chbTP.TabIndex = 59;
            this.chbTP.Text = "Transportes Platino";
            this.chbTP.UseVisualStyleBackColor = true;
            // 
            // chbDP
            // 
            this.chbDP.AutoSize = true;
            this.chbDP.Location = new System.Drawing.Point(26, 249);
            this.chbDP.Name = "chbDP";
            this.chbDP.Size = new System.Drawing.Size(149, 20);
            this.chbDP.TabIndex = 58;
            this.chbDP.Text = "Distribuidora Platino";
            this.chbDP.UseVisualStyleBackColor = true;
            // 
            // chbWYM
            // 
            this.chbWYM.AutoSize = true;
            this.chbWYM.Location = new System.Drawing.Point(26, 222);
            this.chbWYM.Name = "chbWYM";
            this.chbWYM.Size = new System.Drawing.Size(128, 20);
            this.chbWYM.TabIndex = 57;
            this.chbWYM.Text = "William && Molina";
            this.chbWYM.UseVisualStyleBackColor = true;
            // 
            // lblDescription1
            // 
            this.lblDescription1.AutoSize = true;
            this.lblDescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription1.Location = new System.Drawing.Point(23, 152);
            this.lblDescription1.Name = "lblDescription1";
            this.lblDescription1.Size = new System.Drawing.Size(214, 18);
            this.lblDescription1.TabIndex = 56;
            this.lblDescription1.Text = "Empresas con tasa de cambio:";
            // 
            // chbDC
            // 
            this.chbDC.AutoSize = true;
            this.chbDC.Location = new System.Drawing.Point(26, 275);
            this.chbDC.Name = "chbDC";
            this.chbDC.Size = new System.Drawing.Size(88, 20);
            this.chbDC.TabIndex = 55;
            this.chbDC.Text = "Duracreto";
            this.chbDC.UseVisualStyleBackColor = true;
            // 
            // dtpRateDate
            // 
            this.dtpRateDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRateDate.Location = new System.Drawing.Point(448, 221);
            this.dtpRateDate.Name = "dtpRateDate";
            this.dtpRateDate.Size = new System.Drawing.Size(139, 22);
            this.dtpRateDate.TabIndex = 54;
            this.dtpRateDate.Value = new System.DateTime(2025, 3, 19, 11, 41, 4, 705);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdate.Location = new System.Drawing.Point(448, 302);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(114, 30);
            this.btnUpdate.TabIndex = 50;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(160, 111);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(338, 20);
            this.lblTitle.TabIndex = 49;
            this.lblTitle.Text = "Actualización de tasa de cambio global";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription2
            // 
            this.lblDescription2.AutoSize = true;
            this.lblDescription2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription2.Location = new System.Drawing.Point(445, 152);
            this.lblDescription2.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblDescription2.Name = "lblDescription2";
            this.lblDescription2.Size = new System.Drawing.Size(247, 54);
            this.lblDescription2.TabIndex = 48;
            this.lblDescription2.Text = "Seleccione la fecha e ingrese el tipo de cambio para las empresas seleccionadas:";
            // 
            // txtRate
            // 
            this.txtRate.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRate.Location = new System.Drawing.Point(448, 260);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(139, 22);
            this.txtRate.TabIndex = 47;
            // 
            // pbxLogoGP2
            // 
            this.pbxLogoGP2.Image = global::GUI.Properties.Resources.logo_gp;
            this.pbxLogoGP2.Location = new System.Drawing.Point(229, 21);
            this.pbxLogoGP2.Name = "pbxLogoGP2";
            this.pbxLogoGP2.Size = new System.Drawing.Size(239, 78);
            this.pbxLogoGP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogoGP2.TabIndex = 46;
            this.pbxLogoGP2.TabStop = false;
            // 
            // RateScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(713, 502);
            this.Controls.Add(this.pnTasa);
            this.Controls.Add(this.pnLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(731, 549);
            this.Name = "RateScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualización de tasa de cambio global";
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoSAP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoGP1)).EndInit();
            this.pnTasa.ResumeLayout(false);
            this.pnTasa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbcLogoSAP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogoGP2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.PictureBox pbxLogoSAP1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblUserSAP2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pbxLogoGP1;
        private System.Windows.Forms.Panel pnTasa;
        private System.Windows.Forms.ProgressBar pbRate;
        private System.Windows.Forms.DateTimePicker dtpFilterRateDate;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.CheckBox chbIP;
        private System.Windows.Forms.CheckBox chbAMSA;
        private System.Windows.Forms.CheckBox chbINOPSA;
        private System.Windows.Forms.CheckBox chbSXXI;
        private System.Windows.Forms.CheckBox chbTP;
        private System.Windows.Forms.CheckBox chbDP;
        private System.Windows.Forms.CheckBox chbWYM;
        private System.Windows.Forms.Label lblDescription1;
        private System.Windows.Forms.CheckBox chbDC;
        private System.Windows.Forms.DateTimePicker dtpRateDate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription2;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.PictureBox pbxLogoGP2;
        private System.Windows.Forms.PictureBox pbcLogoSAP2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtUserSAP2;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.ProgressBar pbLogin;
        private System.Windows.Forms.CheckBox chbSCP;
        private System.Windows.Forms.CheckBox chbESMV;
        private System.Windows.Forms.CheckBox chbINVP;
        private VerticalSeparator verticalSeparator1;
        private System.Windows.Forms.CheckBox chbAA;
    }
}

