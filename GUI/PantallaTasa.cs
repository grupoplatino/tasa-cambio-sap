using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using CredentialManagement;
using BE;
using LN;

namespace GUI
{
    public partial class PantallaTasa : Form
    {
        public csSAP oSAP = new csSAP();
        private static string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TasaCambio");
        private static string logPath = Path.Combine(logDirectory, $"LogTasaCambio_{DateTime.Now:yyyyMMdd}.txt");
        private readonly Dictionary<string, csCompanies> Companies;

        private string _serverBD;
        private string _userBD;
        private string _pwBD;
        private string _userSAP;
        private string _pwSAP;

        public PantallaTasa()
        {
            InitializeComponent();

            Companies = new Dictionary<string, csCompanies>
            {
                { "DC_0215", new csCompanies("DC_0215", "Duracreto", chbDuracreto) },
                { "WYM_TEST", new csCompanies("WYM_TEST", "William & Molina", chbWYM) },
                { "DP_0601", new csCompanies("DP_0601", "Distribuidora Platino", chbDP) },
                { "TEST_IP2103", new csCompanies("TEST_IP2103", "Inmobiliaria Platino", chbIP) }
            };

            /*Companies = new Dictionary<string, csCompanies>
            {
                { "SBO_DURACRETO1", new csCompanies("SBO_DURACRETO1", "Duracreto", chbDuracreto) },
                { "SBO_WILLIAM_Y_MOLINA", new csCompanies("SBO_WILLIAM_Y_MOLINA", "William & Molina", chbWYM) },
                { "SBO_DP", new csCompanies("SBO_DP", "Distribuidora Platino", chbDP) },
                { "SBO_TRANSPORTE_PLATINO", new csCompanies("SBO_TRANSPORTE_PLATINO", "Transportes Platino", chbTP) },
                { "SBO_INMOBILIARIA_PLATINO", new csCompanies("SBO_INMOBILIARIA_PLATINO", "Inmobiliaria Platino", chbIP) },
                { "SBO_INOPSA", new csCompanies("SBO_INOPSA", "INOPSA", chbINOPSA) },
                { "SBO_AMSA", new csCompanies("SBO_AMSA", "AMSA", chbAMSA) },
                { "SBO_SPS_SIGLO_XXI", new csCompanies("SBO_SPS_SIGLO_XXI", "Siglo XXI", chbSXXI) }
            };*/

            WriteLog("Se inicia la aplicación.");

            lblHost.Text = Environment.MachineName;
            lblSerie.Text = GetSeries();

            dtpRateDate.Value = DateTime.Now;
            dtpFilterRateDate.Value = DateTime.Now;
            pbRate.Visible = false;
            pbLogin.Visible = false;

            pnTasa.Hide();

            LoadCredentials();
        }

        //Métodos principales
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
                        _serverBD = cred.Username;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConectarBD(string bd)
        {
            try
            {
                csCompany objCompany = new csCompany
                {
                    ServerBD = _serverBD,
                    UserBD = _userBD,
                    PwBD = _pwBD,
                    ServerLic = "",
                    NameBD = bd,
                    UserSAP = _userSAP,
                    PwSAP = _pwSAP
                };

                if (oSAP.ConnectSAP(objCompany))
                {
                    string Server = objCompany.ServerBD.Replace("NDB@", "").Replace("30013", "30015");
                    csConnection.StartConnection(Server, objCompany.UserBD, objCompany.PwBD, bd);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisconnectBD()
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
        }

        private void GetRate(string bd)
        {
            try
            {
                csORTT objORTT = new csORTT();
                objORTT.Currency = "USD";
                objORTT.RateDate = dtpFilterRateDate.Value;

                bool tieneTasa = oSAP.GetRate(ref objORTT);
                UpdateCheckboxes(bd, tieneTasa);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Métodos auxiliares
        private void ShowMessage(string message, string title, MessageBoxButtons button, MessageBoxIcon icon)
        {
            if (InvokeRequired)
                Invoke(new Action(() => MessageBox.Show(this, message, title, button, icon)));
            else
                MessageBox.Show(this, message, title, button, icon);
        }

        private static string GetSeries()
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

        private void GetRateSimplificado()
        {
            foreach (var company in Companies)
            {
                try
                {
                    string bd = company.Key;
                    ConectarBD(bd);
                    GetRate(bd);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateCheckboxes(string bd, bool tieneTasa)
        {
            Invoke(new Action(() => {
                if (Companies.ContainsKey(bd))
                {
                    csCompanies company = Companies[bd];

                    company.checkBoxDB.Checked = tieneTasa;
                    company.checkBoxDB.Enabled = !tieneTasa;
                }
            }));
        }

        private void EnableControls()
        {
            pbRate.Visible = false;
            pbLogin.Visible = false;
            btnLogin.Enabled = true;
            btnExit.Enabled = true;
            btnValidate.Enabled = true;
            btnUpdate.Enabled = true;
            btnLogout.Enabled = true;
            dtpFilterRateDate.Enabled = true;
            dtpRateDate.Enabled = true;
            txtRate.Enabled = true;
            lblDescription1.ForeColor = Color.Black;
            lblDescription2.ForeColor = Color.Black;
            btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            btnValidate.BackColor = System.Drawing.Color.OliveDrab;
            btnLogout.BackColor = System.Drawing.Color.Brown;
            btnLogin.BackColor = System.Drawing.Color.SteelBlue;
            btnExit.BackColor = System.Drawing.Color.Firebrick;

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
            btnLogin.Enabled = false;
            btnExit.Enabled = false;
            btnValidate.Enabled = false;
            btnUpdate.Enabled = false;
            btnLogout.Enabled = false;
            dtpFilterRateDate.Enabled = false;
            dtpRateDate.Enabled = false;
            txtRate.Enabled = false;
            lblDescription1.ForeColor = Color.Gray;
            lblDescription2.ForeColor = Color.Gray;
            chbDuracreto.Enabled = false;
            chbWYM.Enabled = false;
            chbDP.Enabled = false;
            chbTP.Enabled = false;
            chbIP.Enabled = false;
            chbINOPSA.Enabled = false;
            chbAMSA.Enabled = false;
            chbSXXI.Enabled = false;
            btnUpdate.BackColor = System.Drawing.Color.LightGray;
            btnValidate.BackColor = System.Drawing.Color.LightGray;
            btnLogout.BackColor = System.Drawing.Color.LightGray;
            btnLogin.BackColor = System.Drawing.Color.LightGray;
            btnExit.BackColor = System.Drawing.Color.LightGray;
        }

        //Botones
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            List<string> bds = new List<string> { };

            foreach (var company in Companies)
            {
                if (company.Value.checkBoxDB.Checked && company.Value.checkBoxDB.Enabled)
                    bds.Add(company.Key);
            }

            if (dtpRateDate.Value.Date < DateTime.Now.Date)
            {
                ShowMessage("La fecha no puede ser anterior a hoy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtRate.Text == null || txtRate.Text == "")
            {
                ShowMessage("El campo de tasa no puede ir vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(bds.Count == 0)
            {
                ShowMessage("Se tiene que elegir al menos una empresa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DisableControls();

            var tareas = bds.Select(bd => Task.Run(() =>
            {
                try
                {
                    ConectarBD(bd);
                    UpdateRate(bd);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            })).ToList();

            await Task.WhenAll(tareas);

            dtpFilterRateDate.Value = dtpRateDate.Value;
            txtRate.Text = "";

            await Task.Run(() => GetRateSimplificado());

            EnableControls();
        }

        private async void btnValidate_Click(object sender, EventArgs e)
        {

            DisableControls();

            await Task.Run(() => GetRateSimplificado());

            EnableControls();

            WriteLog($"Se valida la tasa para el {dtpFilterRateDate.Value.Date}");
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserSAP2.Text == "")
            {
                ShowMessage("El campo de usuario no puede quedar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DisableControls();
            await Task.Run(() => ConectarBD("DP_0601"));

            bool serieExiste = await Task.Run(() => oSAP.ValidateSeries(lblSerie.Text));
            if (!serieExiste)
            {
                ShowMessage("No se puede utilizar la aplicación en esta computadora.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog($"Se intentó iniciar sesión con el usuario: {txtUserSAP2.Text}, host: {lblHost.Text}, y serie: {lblSerie.Text}");
                EnableControls();

                return;
            }

            bool usuarioExiste = await Task.Run(() => oSAP.ValidateUser(txtUserSAP2.Text));
            if (!usuarioExiste)
            {
                ShowMessage("El usuario no existe o no tiene permisos para utilizar la aplicación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            btnUpdate.BackColor = System.Drawing.Color.LightGray;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DisconnectBD();
            WriteLog("Se sale de la aplicación.");
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            WriteLog("Se cierra la sesión.");
            pnTasa.Hide();
            pnLogin.Show();
            txtUserSAP2.Text = "";
        }
    }
}
