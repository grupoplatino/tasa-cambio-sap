using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using CredentialManagement;
using BE;
using LN;

namespace GUI
{
    public partial class RateScreen : Form
    {
        public csSAP oSAP = new csSAP(); // Instancia de la clase SAP
        private static string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TasaCambio"); // Se utiliza el %appdata% del usuario
        private static string logPath = Path.Combine(logDirectory, $"LogTasaCambio_{DateTime.Now:yyyyMMdd}.txt"); // Se crea un log por día
        private readonly Dictionary<string, csCompanies> Companies; // Diccionario de empresas, se utiliza para validar la tasa de cambio
        private static string initialDB = "SBO_DP"; // Base de datos inicial, se utiliza para validar el usuario

        private string _SLDServer; // Servidor SLD de la base de datos
        private string _serverBD; // Servidor de la base de datos
        private string _userBD; // Usuario de HANA
        private string _pwBD; // Contraseña de HANA
        private string _userSAP; // Usuario de SAP
        private string _pwSAP; // Contraseña de SAP

        public RateScreen()
        {
            InitializeComponent();

            oSAP.CleanRecordset();

            // Bases de datos de prueba
            /*Companies = new Dictionary<string, csCompanies>
            {
                { "IP_TEST_TOMMY", new csCompanies("IP_TEST_TOMMY", "Inmobiliaria Platino", chbIP) },
                { "WYM_TEST", new csCompanies("WYM_TEST", "William & Molina", chbWYM) },
                { "TEST_DC_1104", new csCompanies("TEST_DC_1104", "Duracreto", chbDC) },
                { "TEST_TP_1504", new csCompanies("TEST_TP_1504", "Transportes Platino", chbTP) },
            };*/

            // Bases de datos productivas
            Companies = new Dictionary<string, csCompanies>
            {
                { "SBO_DURACRETO1", new csCompanies("SBO_DURACRETO1", "Duracreto", chbDC) },
                { "SBO_WILLIAM_Y_MOLINA", new csCompanies("SBO_WILLIAM_Y_MOLINA", "William & Molina", chbWYM) },
                { "SBO_DP", new csCompanies("SBO_DP", "Distribuidora Platino", chbDP) },
                { "SBO_TRANSPORTE_PLATINO", new csCompanies("SBO_TRANSPORTE_PLATINO", "Transportes Platino", chbTP) },
                { "SBO_INMOBILIARIA_PLATINO", new csCompanies("SBO_INMOBILIARIA_PLATINO", "Inmobiliaria Platino", chbIP) },
                { "SBO_INOPSA", new csCompanies("SBO_INOPSA", "INOPSA", chbINOPSA) },
                { "SBO_AMSA", new csCompanies("SBO_AMSA", "AMSA", chbAMSA) },
                { "SBO_SPS_SIGLO_XXI", new csCompanies("SBO_SPS_SIGLO_XXI", "Siglo XXI", chbSXXI) },
                { "SBO_CORPORATIVO_PLATINO", new csCompanies("SBO_CORPORATIVO_PLATINO", "Servicios Corporativos", chbSCP) },
                { "INVERSIONES_PLATINO", new csCompanies("INVERSIONES_PLATINO", "Inversiones Platino", chbINVP) },
                { "SBO_ESMV", new csCompanies("SBO_ESMV", "Escuela Santa Maria del Valle", chbESMV) },
                { "SBO_AUTOS_ALIADOS", new csCompanies("SBO_AUTOS_ALIADOS", "Autos Aliados", chbAA) }
            };

            WriteLog("Se inicia la aplicación.");

            // Se crea un separador vertical para la pantalla de login
            VerticalSeparator separator = new VerticalSeparator
            {
                Height = 200,
                Location = new Point(150, 50)
            };

            Controls.Add(separator);

            // Se inicializan los controles
            lblHost.Text = Environment.MachineName;
            lblSerie.Text = GetSeries();

            dtpRateDate.Value = DateTime.Now;
            dtpFilterRateDate.Value = DateTime.Now;
            pbRate.Visible = false;
            pbLogin.Visible = false;

            pnTasa.Hide();

            txtRate.KeyPress += TxtRate_KeyPress;

            LoadCredentials();
        }

        // Métodos principales
        private void LoadCredentials() // Carga las credenciales de la base de datos y del usuario SAP desde el almacén de credenciales de Windows
        {
            try
            {
                using (var cred = new Credential { Target = "TasaCambio_HANA" })
                {
                    if (cred.Load())
                    {
                        _userBD = cred.Username;
                        _pwBD = cred.Password;
                    }
                }

                using (var cred = new Credential { Target = "TasaCambio_SAP" })
                {
                    if (cred.Load())
                    {
                        _userSAP = cred.Username;
                        _pwSAP = cred.Password;
                    }
                }

                using (var cred = new Credential { Target = "TasaCambio_Server" })
                {
                    if (cred.Load())
                    {
                        _SLDServer = cred.Username;
                        _serverBD = cred.Password;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ConnectDB(string bd) // Conecta a la base de datos de SAP/HANA
        {
            try
            {
                csCompany objCompany = new csCompany
                {
                    SLDServer = _SLDServer,
                    ServerBD = _serverBD,
                    UserBD = _userBD,
                    PwBD = _pwBD,
                    ServerLic = "",
                    NameBD = bd,
                    UserSAP = _userSAP,
                    PwSAP = _pwSAP
                };

                if (oSAP.ConnectSAP(objCompany)) // Se conecta a la base de datos de SAP
                {
                    string Server = objCompany.ServerBD.Replace("NDB@", "").Replace("30013", "30015"); // Se cambia el puerto de la base de datos de SAP a HANA
                    csConnection.StartConnection(Server, objCompany.UserBD, objCompany.PwBD, bd);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog(oSAP.GetErrorMessage(ex));
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DisconnectDB() // Desconecta de la base de datos
        {
            try
            {
                csCompany objCompany = new csCompany();
                oSAP.DisconnectSAP(objCompany);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetRate(string bd) // Obtiene la tasa de cambio de la base de datos
        {
            try
            {
                csORTT objORTT = new csORTT
                {
                    Currency = string.Empty,
                    RateDate = DateTime.MinValue,
                    Rate = 0,
                    DataSource = '\0',
                    UserSign = 0,
                    Update = false
                };

                objORTT.Currency = "USD";
                objORTT.RateDate = dtpFilterRateDate.Value;

                bool hasRate = oSAP.GetRate(ref objORTT); // Valida si tiene tasa de cambio para la base de datos 

                UpdateCheckboxes(bd, hasRate); // Actualiza los checkboxes de las empresas
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRate(string bd) // Actualiza la tasa de cambio en la base de datos
        {
            try
            {
                csORTT objORTT = new csORTT();
                objORTT.Currency = "USD";
                objORTT.RateDate = dtpRateDate.Value;
                objORTT.Rate = Double.Parse(txtRate.Text);

                if(Companies.ContainsKey(bd))
                {
                    csCompanies company = Companies[bd];
                    string bd_name = company.nameDB; // Nombre de la base de datos

                    if (oSAP.AddRate(ref objORTT)) // Agrega la tasa de cambio a la base de datos
                    {
                        ShowMessage($"Se agregó la tasa exitosamente para {bd_name}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        WriteLog($"Se agregó la tasa exitosamente de {bd_name} para el {dtpRateDate.Value.Date}.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DisconnectDB();
                WriteLog($"Se desconectó de {bd}");
            }
        }

        // Métodos auxiliares
        private void ShowMessage(string message, string title, MessageBoxButtons button, MessageBoxIcon icon) // Muestra un mensaje en la pantalla
        {
            if (InvokeRequired)
                Invoke(new Action(() => MessageBox.Show(this, message, title, button, icon))); //  Invoca el método en el hilo de la interfaz de usuario
            else
                MessageBox.Show(this, message, title, button, icon);
        }

        private void TxtRate_KeyPress(object sender, KeyPressEventArgs e) // Valida que el campo de tasa solo acepte números y un punto decimal
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private string GetSeries() // Obtiene el número de serie de la computadora
        {
            string series = string.Empty;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["SerialNumber"]?.ToString() ?? "No disponible";
                }
            }

            return series;
        }

        private void WriteLog(string log) // Escribe un log en el archivo de texto
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(logPath));

                using (StreamWriter writer = new StreamWriter(logPath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {log}");
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetRateSimplified() // Metodo simplificado para obtener la tasa de cambio y reutilizar el código
        {
            foreach (var company in Companies) // Recorre el diccionario de empresas
            {
                try
                {
                    string bd = company.Key;
                    ConnectDB(bd);
                    GetRate(bd);
                    WriteLog("Se obtuvo la tasa de " + bd);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    DisconnectDB();
                    WriteLog("Se desconectó de " + company.Key);
                }
            }
        }

        private void UpdateCheckboxes(string bd, bool hasRate) // Actualiza los checkboxes de las empresas
        {
            Invoke(new Action(() => {
                if (Companies.ContainsKey(bd))
                {
                    csCompanies company = Companies[bd];

                    company.checkBoxDB.Checked = hasRate; // Marca el checkbox si tiene tasa de cambio
                    company.checkBoxDB.Enabled = !hasRate; // Deshabilita el checkbox si tiene tasa de cambio
                }
            }));
        }

        private void EnableControls() // Habilita los controles de la pantalla
        {
            pbRate.Visible = false;
            pbLogin.Visible = false;
            dtpFilterRateDate.Enabled = true;
            dtpRateDate.Enabled = true;
            txtRate.Enabled = true;
            lblDescription1.ForeColor = Color.Black;
            lblDescription2.ForeColor = Color.Black;
            btnLogin.Enabled = true;
            btnExit.Enabled = true;
            btnValidate.Enabled = true;
            btnUpdate.Enabled = true;
            btnLogout.Enabled = true;
            btnUpdate.BackColor = Color.SteelBlue;
            btnValidate.BackColor = Color.OliveDrab;
            btnLogout.BackColor = Color.Brown;
            btnLogin.BackColor = Color.SteelBlue;
            btnExit.BackColor = Color.Firebrick;

            foreach (var company in Companies)
            {
                company.Value.checkBoxDB.Enabled = !company.Value.checkBoxDB.Checked;
            }
        }

        private void DisableControls() // Deshabilita los controles de la pantalla
        {
            pbRate.Style = ProgressBarStyle.Marquee;
            pbLogin.Style = ProgressBarStyle.Marquee;
            pbRate.Visible = true;
            pbLogin.Visible = true;
            txtRate.Enabled = false;
            lblDescription1.ForeColor = Color.Gray;
            lblDescription2.ForeColor = Color.Gray;

            DisableAllControls(this);
        }

        private void DisableAllControls(Control parent) // Método recursivo para deshabilitar todos los controles
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = false;
                    control.BackColor = Color.LightGray;
                }
                else if (control is CheckBox)
                {
                    control.Enabled = false;
                }
                else if (control is DateTimePicker)
                {
                    control.Enabled = false;
                }
                else if (control.HasChildren)
                {
                    DisableAllControls(control); //  Llamada recursiva para controles que contienen otros controles
                }
            }
        }

        // Eventos
        private async void btnLogin_Click(object sender, EventArgs e) // Inicia sesión en la aplicación
        {
            if (txtUserSAP2.Text == "")
            {
                ShowMessage("El campo de usuario no puede quedar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DisableControls();

            bool isConnected = await Task.Run(() => ConnectDB(initialDB)); // Conecta a la base de datos inicial para validar el usuario
            if (!isConnected)
            {
                ShowMessage("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableControls();
                return;
            }

            bool userExist = await Task.Run(() => oSAP.ValidateUser(txtUserSAP2.Text)); // Valida si el usuario existe en SAP
            if (!userExist)
            {
                ShowMessage("El usuario no existe o no tiene permisos para utilizar la aplicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Se intentó iniciar sesión con el usuario: {txtUserSAP2.Text}, host: {lblHost.Text}, y serie: {lblSerie.Text}");
                EnableControls();

                return;
            }

            // Valida si el hostname de la computadora esta en el campo de usuario de U_Host en el usuario de SAP
            bool hostExist = await Task.Run(() => oSAP.ValidateComputer(lblHost.Text, txtUserSAP2.Text)); 
            if (!hostExist)
            {
                ShowMessage("No se puede utilizar la aplicación en esta computadora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Se intentó iniciar sesión con el usuario: {txtUserSAP2.Text}, host: {lblHost.Text}, y serie: {lblSerie.Text}");
                EnableControls();

                return;
            }

            // Cambia de panel de login al gestor de la tasa
            pnLogin.Hide();
            pnTasa.Show();

            WriteLog($"Se inició sesión con el usuario de {txtUserSAP2.Text}");
            EnableControls();

            // Deshabilita los controles de la pantalla
            lblDescription2.ForeColor = Color.Gray;
            dtpRateDate.Enabled = false;
            txtRate.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.BackColor = Color.LightGray;
            chbDC.Enabled = false;
            chbWYM.Enabled = false;
            chbDP.Enabled = false;
            chbTP.Enabled = false;
            chbIP.Enabled = false;
            chbINOPSA.Enabled = false;
            chbAMSA.Enabled = false;
            chbSXXI.Enabled = false;
            chbSCP.Enabled = false;
            chbINVP.Enabled = false;
            chbESMV.Enabled = false;
            chbAA.Enabled = false;

            DisconnectDB(); // Desconecta de la base de datos inicial
        }

        private async void btnValidate_Click(object sender, EventArgs e) // Valida la tasa de cambio
        {
            DisableControls();

            await Task.Run(() => GetRateSimplified()); // Obtiene la tasa de cambio de todas las bases de datos

            EnableControls();

            WriteLog($"Se valida la tasa para el {dtpFilterRateDate.Value.Date}");
        }

        private async void btnUpdate_Click(object sender, EventArgs e) // Actualiza la tasa de cambio
        {
            string rate = txtRate.Text;
            string date = dtpRateDate.Value.ToString("yyyy-MM-dd");

            if (dtpRateDate.Value.Date < DateTime.Now.Date) // Valida que la fecha no sea anterior a hoy
            {
                ShowMessage("La fecha no puede ser anterior a hoy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtRate.Text)) // Valida que el campo de tasa no esté vacío
            {
                ShowMessage("El campo de tasa no puede ir vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtRate.Text, out _)) // Valida que el campo de tasa sea un número decimal
            {
                ShowMessage("El campo de tasa debe ser un valor numérico decimal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> bds = new List<string> { };
            foreach (var company in Companies)
            {
                if (company.Value.checkBoxDB.Checked && company.Value.checkBoxDB.Enabled)
                    bds.Add(company.Key); // Agrega la base de datos a la lista si el checkbox está marcado
            }

            if (bds.Count == 0) // Valida que al menos una base de datos esté seleccionada
            {
                ShowMessage("Se tiene que elegir al menos una empresa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            System.Windows.Forms.DialogResult result = MessageBox.Show(
                $"¿Está seguro de establecer la tasa de cambio '{rate}' para la fecha '{date}' en las sociedades seleccionadas?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ); // Muestra un mensaje de confirmación

            if (result != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            DisableControls();

            foreach (var bd in bds) // Recorre la lista de bases de datos seleccionadas
            {
                try
                {
                    await Task.Run(() => ConnectDB(bd)); // Conecta a la base de datos de SAP
                    await Task.Run(() => UpdateRate(bd)); // Actualiza la tasa de cambio en la base de datos y se desconecta de SAP
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dtpFilterRateDate.Value = dtpRateDate.Value;
            txtRate.Text = "";

            await Task.Run(() => GetRateSimplified()); // Obtiene la tasa de cambio de todas las bases de datos luego de actualizar la tasa en las empresas seleccionadas

            EnableControls();
        }

        private void btnLogout_Click(object sender, EventArgs e) // Cambia de panel de la pantalla de gestor de tasa a la de login
        {
            // No hace falta poner la funcion de desconectar de la base de datos, ya que se desconecta al actualizar la tasa y validarla

            WriteLog("Se cierra la sesión.");
            pnTasa.Hide();
            pnLogin.Show();
            txtUserSAP2.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e) // Cierra la aplicación
        {
            // No hace falta poner la funcion de desconectar de la base de datos, ya que se desconecta al actualizar la tasa y validarla

            WriteLog("Se sale de la aplicación.");
            Application.Exit();
        }
    }
}
