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
        private readonly Dictionary<string, csEmpresas> Empresas;

        private string _serverBD;
        private string _userBD;
        private string _pwBD;
        private string _userSAP;
        private string _pwSAP;

        public PantallaTasa()
        {
            InitializeComponent();

            Empresas = new Dictionary<string, csEmpresas>
            {
                { "DC_0215", new csEmpresas("DC_0215", "Duracreto", chbDuracreto) },
                { "WYM_TEST", new csEmpresas("WYM_TEST", "William & Molina", chbWYM) },
                { "DP_0601", new csEmpresas("DP_0601", "Distribuidora Platino", chbDP) },
                { "TEST_IP2103", new csEmpresas("TEST_IP2103", "Inmobiliaria Platino", chbIP) }
            };

            /*Empresas = new Dictionary<string, csEmpresas>
            {
                { "SBO_DURACRETO1", new csEmpresas("SBO_DURACRETO1", "Duracreto", chbDuracreto) },
                { "SBO_WILLIAM_Y_MOLINA", new csEmpresas("SBO_WILLIAM_Y_MOLINA", "William & Molina", chbWYM) },
                { "SBO_DP", new csEmpresas("SBO_DP", "Distribuidora Platino", chbDP) },
                { "SBO_TRANSPORTE_PLATINO", new csEmpresas("SBO_TRANSPORTE_PLATINO", "Transportes Platino", chbTP) },
                { "SBO_INMOBILIARIA_PLATINO", new csEmpresas("SBO_INMOBILIARIA_PLATINO", "Inmobiliaria Platino", chbIP) },
                { "SBO_INOPSA", new csEmpresas("SBO_INOPSA", "INOPSA", chbINOPSA) },
                { "SBO_AMSA", new csEmpresas("SBO_AMSA", "AMSA", chbAMSA) },
                { "SBO_SPS_SIGLO_XXI", new csEmpresas("SBO_SPS_SIGLO_XXI", "Siglo XXI", chbSXXI) }
            };*/

            EscribirLog("Se inicia la aplicación.");

            lblHost.Text = Environment.MachineName;
            lblSerie.Text = ObtenerSerie();

            dtpFechaTasa.Value = DateTime.Now;
            dtpFechaTasaFiltro.Value = DateTime.Now;
            lblDescripcion2.ForeColor = Color.Gray;
            dtpFechaTasa.Enabled = false;
            txtTasa.Enabled = false;
            btnActualizar.Enabled = false;
            btnActualizar.BackColor = System.Drawing.Color.LightGray;
            pbCarga.Visible = false;

            pnTasa.Hide();

            CargarCredenciales();
        }

        //Métodos principales
        private void CargarCredenciales()
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
                MessageBox.Show("No se encontraron las credenciales en el Administrador de Credenciales de Windows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (oSAP.ConectarSAP(objCompany))
                {
                    string Server = objCompany.ServerBD.Replace("NDB@", "").Replace("30013", "30015");
                    csConexion.IniciarConexionHANA(Server, objCompany.UserBD, objCompany.PwBD, bd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesconectarBD()
        {
            try
            {
                csCompany objCompany = new csCompany();
                oSAP.DesconectarSAP(objCompany);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTasa(string bd)
        {
            try
            {
                csORTT objORTT = new csORTT();
                objORTT.Currency = "USD";
                objORTT.RateDate = dtpFechaTasa.Value;
                objORTT.Rate = Double.Parse(txtTasa.Text);

                if(Empresas.ContainsKey(bd))
                {
                    csEmpresas empresa = Empresas[bd];
                    string bd_name = empresa.nombreDB;

                    if (oSAP.AgregarTasa(ref objORTT))
                    {
                        MessageBox.Show($"Se agregó la tasa exitosamente para {bd_name}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EscribirLog($"Se agregó la tasa exitosamente de {bd_name} para el {dtpFechaTasa.Value.Date}.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerTasa(string bd)
        {
            try
            {
                csORTT objORTT = new csORTT();
                objORTT.Currency = "USD";
                objORTT.RateDate = dtpFechaTasaFiltro.Value;

                bool tieneTasa = oSAP.ObtenerTasa(ref objORTT);
                ActualizarCheckboxes(bd, tieneTasa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Métodos auxiliares
        private static string ObtenerSerie()
        {
            string serie = string.Empty;

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    return obj["SerialNumber"]?.ToString() ?? "No disponible";
                }
            }

            return serie;
        }

        private static void EscribirLog(string log)
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerTasaSimplificado()
        {
            foreach (var empresa in Empresas)
            {
                try
                {
                    string bd = empresa.Key;
                    ConectarBD(bd);
                    ObtenerTasa(bd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ActualizarCheckboxes(string bd, bool tieneTasa)
        {
            Invoke(new Action(() => {
                if (Empresas.ContainsKey(bd))
                {
                    csEmpresas empresa = Empresas[bd];

                    empresa.checkBoxDB.Checked = tieneTasa;
                    empresa.checkBoxDB.Enabled = !tieneTasa;
                }
            }));
        }

        private void HabilitarControles()
        {
            pbCarga.Visible = false;
            btnValidar.Enabled = true;
            btnActualizar.Enabled = true;
            btnCerrarSesion.Enabled = true;
            dtpFechaTasaFiltro.Enabled = true;
            dtpFechaTasa.Enabled = true;
            txtTasa.Enabled = true;
            lblDescripcion1.ForeColor = Color.Black;
            lblDescripcion2.ForeColor = Color.Black;
            btnActualizar.BackColor = System.Drawing.Color.SteelBlue;
            btnValidar.BackColor = System.Drawing.Color.OliveDrab;
            btnCerrarSesion.BackColor = System.Drawing.Color.Brown;

            foreach(var empresa in Empresas)
            {
                empresa.Value.checkBoxDB.Enabled = !empresa.Value.checkBoxDB.Checked;
            }
        }

        private void DeshabilitarControles()
        {
            pbCarga.Style = ProgressBarStyle.Marquee;
            pbCarga.Visible = true;
            btnValidar.Enabled = false;
            btnActualizar.Enabled = false;
            btnCerrarSesion.Enabled = false;
            dtpFechaTasaFiltro.Enabled = false;
            dtpFechaTasa.Enabled = false;
            txtTasa.Enabled = false;
            lblDescripcion1.ForeColor = Color.Gray;
            lblDescripcion2.ForeColor = Color.Gray;
            chbDuracreto.Enabled = false;
            chbWYM.Enabled = false;
            chbDP.Enabled = false;
            chbTP.Enabled = false;
            chbIP.Enabled = false;
            chbINOPSA.Enabled = false;
            chbAMSA.Enabled = false;
            chbSXXI.Enabled = false;
            btnActualizar.BackColor = System.Drawing.Color.LightGray;
            btnValidar.BackColor = System.Drawing.Color.LightGray;
            btnCerrarSesion.BackColor = System.Drawing.Color.LightGray;
        }

        //Botones
        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            List<string> bds = new List<string> { };

            foreach(var empresa in Empresas)
            {
                if (empresa.Value.checkBoxDB.Checked && empresa.Value.checkBoxDB.Enabled)
                    bds.Add(empresa.Key);
            }

            if (dtpFechaTasa.Value.Date < DateTime.Now.Date)
                MessageBox.Show("La fecha no puede ser anterior a hoy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTasa.Text == null || txtTasa.Text == "")
                MessageBox.Show("El campo de tasa no puede ir vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(bds.Count == 0)
                MessageBox.Show("Se tiene que elegir al menos una empresa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DeshabilitarControles();

                var tareas = bds.Select(bd => Task.Run(() =>
                {
                    try
                    {
                        ConectarBD(bd);
                        ActualizarTasa(bd);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                })).ToList();

                await Task.WhenAll(tareas);

                dtpFechaTasaFiltro.Value = dtpFechaTasa.Value;
                txtTasa.Text = "";

                await Task.Run(() => ObtenerTasaSimplificado());

                HabilitarControles();
            }
        }

        private async void btnValidar_Click(object sender, EventArgs e)
        {

            DeshabilitarControles();

            await Task.Run(() => ObtenerTasaSimplificado());

            HabilitarControles();

            EscribirLog($"Se valida la tasa para el {dtpFechaTasaFiltro.Value.Date}");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserSAP2.Text == "")
                MessageBox.Show("El campo de usuario no puede quedar vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(lblSerie.Text != "DFPP044")
            {
                MessageBox.Show("No se puede utilizar la aplicación en este ambiente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EscribirLog($"Se intentó iniciar sesión con el usuario: {txtUserSAP2.Text}, host: {lblHost.Text}, y serie: {lblSerie}");
            }
            else
            {
                pnLogin.Hide();
                pnTasa.Show();

                EscribirLog($"Se inició sesión con el usuario de {txtUserSAP2.Text}");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            EscribirLog("Se sale de la aplicación.");
            Application.Exit();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            EscribirLog("Se cierra la sesión.");
            DesconectarBD();
            pnTasa.Hide();
            pnLogin.Show();
        }
    }
}
