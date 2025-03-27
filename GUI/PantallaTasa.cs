using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using BE;
using LN;

namespace GUI
{
    public partial class PantallaTasa : Form
    {
        public csSAP oSAP = new csSAP();
        private static string logPath = @"C:\Aplicaciones SAP\TasaCambio\LogTasaCambio.txt";

        public PantallaTasa()
        {
            InitializeComponent();

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
        }

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

        private void ConectarBD(string bd)
        {
            try
            {
                csCompany objCompany = new csCompany();
                objCompany.ServerBD = txtServerBD.Text;
                objCompany.UserBD = txtUserBD.Text;
                objCompany.PwBD = txtPwBD.Text;
                objCompany.ServerLic = "";
                objCompany.NameBD = bd;
                objCompany.UserSAP = txtUserSAP.Text;
                objCompany.PwSAP = txtPwSAP.Text;

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

                string bd_name = "";

                if (bd == "DC_0215")
                    bd_name = "Duracreto";
                else if (bd == "WYM_TEST")
                    bd_name = "William & Molina";
                else if (bd == "DP_0601")
                    bd_name = "Distribuidora Platino";
                else if (bd == "TEST_IP2103")
                    bd_name = "Inmobiliaria Platino";

                if (oSAP.AgregarTasa(ref objORTT))
                {
                    MessageBox.Show($"Se agregó la tasa exitosamente para {bd_name}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EscribirLog($"Se agregó la tasa exitosamente de {bd_name} para el {dtpFechaTasa.Value.Date}.");
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

                if (oSAP.ObtenerTasa(ref objORTT))
                {
                    Invoke(new Action(() =>
                    {
                        switch (bd)
                        {
                            case "DC_0215":
                                chbDuracreto.Checked = true;
                                chbDuracreto.Enabled = false;
                                break;
                            case "WYM_TEST":
                                chbWYM.Checked = true;
                                chbWYM.Enabled = false;
                                break;
                            case "DP_0601":
                                chbDP.Checked = true;
                                chbDP.Enabled = false;
                                break;
                            case "TEST_IP2103":
                                chbIP.Checked = true;
                                chbIP.Enabled = false;
                                break;
                        }
                    }));
                }else
                {
                    Invoke(new Action(() =>
                    {
                        switch (bd)
                        {
                            case "DC_0215":
                                chbDuracreto.Checked = false;
                                chbDuracreto.Enabled = true;
                                break;
                            case "WYM_TEST":
                                chbWYM.Checked = false;
                                chbWYM.Enabled = true;
                                break;
                            case "DP_0601":
                                chbDP.Checked = false;
                                chbDP.Enabled = true;
                                break;
                            case "TEST_IP2103":
                                chbIP.Checked = false;
                                chbIP.Enabled = true;
                                break;
                        }
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerTasaSimplificado()
        {
            string[] bds_t = { "DC_0215", "WYM_TEST", "DP_0601", "TEST_IP2103" };
            //string[] bds_p = { "SBO_DURACRETO1", "SBO_WILLIAM_Y_MOLINA", "SBO_DP", "SBO_TRANSPORTE_PLATINO", "SBO_INMOBILIARIA_PLATINO", "SBO_INOPSA", "SBO_AMSA", "SBO_SPS_SIGLO_XXI"};

            foreach (string bd in bds_t)
            {
                try
                {
                    ConectarBD(bd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    ObtenerTasa(bd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            //Duracreto
            if (chbDuracreto.Checked)
                chbDuracreto.Enabled = false;
            else
                chbDuracreto.Enabled = true;

            //William & Molina
            if (chbWYM.Checked)
                chbWYM.Enabled = false;
            else
                chbWYM.Enabled = true;

            //Distribuidora Platino
            if (chbDP.Checked)
                chbDP.Enabled = false;
            else
                chbDP.Enabled = true;

            //Transporte Platino
            if (chbTP.Checked)
                chbTP.Enabled = false;
            else
                chbTP.Enabled = true;

            //Inmobiliaria Platino
            if (chbIP.Checked)
                chbIP.Enabled = false;
            else
                chbIP.Enabled = true;

            //INOPSA
            if (chbINOPSA.Checked)
                chbINOPSA.Enabled = false;
            else
                chbINOPSA.Enabled = true;

            //AMSA
            if (chbAMSA.Checked)
                chbAMSA.Enabled = false;
            else
                chbAMSA.Enabled = true;

            //Siglo XXI
            if (chbSXXI.Checked)
                chbSXXI.Enabled = false;
            else
                chbSXXI.Enabled = true;
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

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            List<string> bds = new List<string> { };

            if (chbDuracreto.Checked && chbDuracreto.Enabled)
                bds.Add("DC_0215");
            else if (chbWYM.Checked && chbWYM.Enabled)
                bds.Add("WYM_TEST");
            else if (chbDP.Checked && chbDP.Enabled)
                bds.Add("DP_0601");
            else if (chbTP.Checked && chbTP.Enabled)
                bds.Add("");
            else if (chbIP.Checked && chbIP.Enabled)
                bds.Add("TEST_IP2103");
            else if (chbINOPSA.Checked && chbINOPSA.Enabled)
                bds.Add("");
            else if (chbAMSA.Checked && chbAMSA.Enabled)
                bds.Add("");
            else if (chbSXXI.Checked && chbSXXI.Enabled)
                bds.Add("");

            if (dtpFechaTasa.Value.Date < DateTime.Now.Date)
                MessageBox.Show("La fecha no puede ser anterior a hoy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (txtTasa.Text == null || txtTasa.Text == "")
                MessageBox.Show("El campo de tasa no puede ir vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if(bds.Count == 0)
                MessageBox.Show("Se tiene que elegir al menos una empresa.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                DeshabilitarControles();

                foreach (string bd in bds)
                {
                    try
                    {
                        await Task.Run(() => ConectarBD(bd));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    try
                    {
                        await Task.Run(() => ActualizarTasa(bd));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                dtpFechaTasaFiltro.Value = dtpFechaTasa.Value;
                txtTasa.Text = "";

                await Task.Run(() => ObtenerTasaSimplificado());

                HabilitarControles();
            }
        }

        private async void btnValidar_Click(object sender, EventArgs e)
        {

            EscribirLog($"Se valida la tasa para el {dtpFechaTasaFiltro.Value.Date}");

            DeshabilitarControles();

            await Task.Run(() => ObtenerTasaSimplificado());

            HabilitarControles();
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
