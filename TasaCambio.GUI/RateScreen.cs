using System;
using System.IO;
using System.Linq;
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
        public csSAP oSAP = new csSAP();
        private string logDirectory = string.Empty;
        private string logPath = string.Empty;
        private readonly Dictionary<string, csCompanies> Companies;
        private string initialDB = string.Empty;

        private string _SLDServer;
        private string _serverBD;
        private string _userBD;
        private string _pwBD;
        private string _userSAP;
        private string _pwSAP;

        public RateScreen()
        {
            InitializeComponent();

            oSAP.CleanRecordset();

            var cfg = csConfig.Load();

            if (!string.IsNullOrWhiteSpace(cfg.LogDirectory))
                logDirectory = cfg.LogDirectory;

            if (!string.IsNullOrWhiteSpace(logDirectory))
                logPath = Path.Combine(logDirectory, $"LogTasaCambio_{DateTime.Now:yyyyMMdd}.txt");

            Companies = new Dictionary<string, csCompanies>();
            bool useTest = cfg.UseTest.HasValue ? cfg.UseTest.Value : true;
            var source = useTest ? cfg.CompaniesTest : cfg.CompaniesProd;
            foreach (var item in source)
            {
                CheckBox cb = FindCheckBoxByName(item.CheckBox);
                if (cb == null) cb = new CheckBox();
                Companies[item.Code] = new csCompanies(item.Code, item.Name, cb);
            }

            if (!string.IsNullOrWhiteSpace(cfg.InitialDB))
                initialDB = cfg.InitialDB;

            WriteLog("Se inicia la aplicación.");

            VerticalSeparator separator = new VerticalSeparator
            {
                Height = 200,
                Location = new Point(150, 50)
            };

            Controls.Add(separator);

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
        private void LoadCredentials()
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

        private bool ConnectDB(string bd)
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

                if (oSAP.ConnectSAP(objCompany) == false)
                {
                    string Server = objCompany.ServerBD.Replace("NDB@", "").Replace("30013", "30015");
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

        private void DisconnectDB()
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

        private void GetRate(string bd)
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

                bool hasRate = oSAP.GetRate(ref objORTT); 

                UpdateCheckboxes(bd, hasRate);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRate(string bd)
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
                    string bd_name = company.nameDB;

                    if (oSAP.AddRate(ref objORTT))
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
        private void ShowMessage(string message, string title, MessageBoxButtons button, MessageBoxIcon icon)
        {
            if (InvokeRequired)
                Invoke(new Action(() => MessageBox.Show(this, message, title, button, icon)));
            else
                MessageBox.Show(this, message, title, button, icon);
        }

        private void TxtRate_KeyPress(object sender, KeyPressEventArgs e)
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

        private string GetSeries()
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

        private void WriteLog(string log)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(logPath)) return;

                var dir = Path.GetDirectoryName(logPath);
                if (!string.IsNullOrWhiteSpace(dir)) Directory.CreateDirectory(dir);

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

        private CheckBox FindCheckBoxByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            foreach (Control c in this.Controls)
            {
                var found = FindControlRecursive(c, name) as CheckBox;
                if (found != null) return found;
            }
            return null;
        }

        private Control FindControlRecursive(Control parent, string name)
        {
            if (parent == null) return null;
            if (string.Equals(parent.Name, name, StringComparison.OrdinalIgnoreCase)) return parent;
            foreach (Control c in parent.Controls)
            {
                var res = FindControlRecursive(c, name);
                if (res != null) return res;
            }
            return null;
        }

        private void GetRateSimplified()
        {
            foreach (var company in Companies)
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

        private void UpdateCheckboxes(string bd, bool hasRate)
        {
            Invoke(new Action(() => {
                if (Companies.ContainsKey(bd))
                {
                    csCompanies company = Companies[bd];

                    company.checkBoxDB.Checked = hasRate;
                    company.checkBoxDB.Enabled = !hasRate;
                }
            }));
        }

        private void EnableControls()
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

        private void DisableControls()
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

        private void DisableAllControls(Control parent)
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
                    DisableAllControls(control);
                }
            }
        }

        // Eventos
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserSAP2.Text == "")
            {
                ShowMessage("El campo de usuario no puede quedar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DisableControls();

            bool isConnected = await Task.Run(() => ConnectDB(initialDB));
            if (!isConnected)
            {
                ShowMessage("No se pudo conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableControls();
                return;
            }

            bool userExist = await Task.Run(() => oSAP.ValidateUser(txtUserSAP2.Text));
            if (!userExist)
            {
                ShowMessage("El usuario no existe o no tiene permisos para utilizar la aplicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Se intentó iniciar sesión con el usuario: {txtUserSAP2.Text}, host: {lblHost.Text}, y serie: {lblSerie.Text}");
                EnableControls();

                return;
            }

            bool hostExist = await Task.Run(() => oSAP.ValidateComputer(lblHost.Text, txtUserSAP2.Text));
            if (!hostExist)
            {
                ShowMessage("No se puede utilizar la aplicación en esta computadora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Se intentó iniciar sesión con el usuario: {txtUserSAP2.Text}, host: {lblHost.Text}, y serie: {lblSerie.Text}");
                EnableControls();

                return;
            }

            pnLogin.Hide();
            pnTasa.Show();

            WriteLog($"Se inició sesión con el usuario de {txtUserSAP2.Text}");
            EnableControls();

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

            DisconnectDB();
        }

        private async void btnValidate_Click(object sender, EventArgs e)
        {
            DisableControls();

            await Task.Run(() => GetRateSimplified());
            EnableControls();

            WriteLog($"Se valida la tasa para el {dtpFilterRateDate.Value.Date}");
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string rate = txtRate.Text;
            string date = dtpRateDate.Value.ToString("yyyy-MM-dd");

            if (dtpRateDate.Value.Date < DateTime.Now.Date)
            {
                ShowMessage("La fecha no puede ser anterior a hoy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtRate.Text))
            {
                ShowMessage("El campo de tasa no puede ir vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtRate.Text, out _))
            {
                ShowMessage("El campo de tasa debe ser un valor numérico decimal.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> bds = new List<string> { };
            foreach (var company in Companies)
            {
                if (company.Value.checkBoxDB.Checked && company.Value.checkBoxDB.Enabled)
                    bds.Add(company.Key);
            }

            if (bds.Count == 0)
            {
                ShowMessage("Se tiene que elegir al menos una empresa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            System.Windows.Forms.DialogResult result = MessageBox.Show(
                $"¿Está seguro de establecer la tasa de cambio '{rate}' para la fecha '{date}' en las sociedades seleccionadas?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            DisableControls();

            foreach (var bd in bds)
            {
                try
                {
                    await Task.Run(() => ConnectDB(bd));
                    await Task.Run(() => UpdateRate(bd));
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dtpFilterRateDate.Value = dtpRateDate.Value;
            txtRate.Text = "";

            await Task.Run(() => GetRateSimplified());

            EnableControls();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            WriteLog("Se cierra la sesión.");
            pnTasa.Hide();
            pnLogin.Show();
            txtUserSAP2.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            WriteLog("Se sale de la aplicación.");
            Application.Exit();
        }
    }
}
