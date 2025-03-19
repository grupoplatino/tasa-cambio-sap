using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using LN;

namespace GUI
{
    public partial class Form1 : Form
    {
        public csSAP oSAP = new csSAP();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dtpFechaTasa.Enabled = false;
            txtTasa.Enabled = false;
            btnActualizar.Enabled = false;
            pbCarga.Visible = false;
        }

        private void ConectarBD(string bd)
        {
            try
            {
                csCompany objCompany = new csCompany();
                objCompany.ServerBD = this.txtServerBD.Text;
                objCompany.UserBD = this.txtUserBD.Text;
                objCompany.PwBD = this.txtPwBD.Text;
                objCompany.ServerLic = "";
                objCompany.NameBD = bd;
                objCompany.UserSAP = this.txtUserSAP.Text;
                objCompany.PwSAP = this.txtPwSAP.Text;

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

                if (oSAP.AgregarTasa(ref objORTT))
                    MessageBox.Show("Se agregó la tasa exitosamente para " + bd, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    this.Invoke(new Action(() =>
                    {
                        switch (bd)
                        {
                            case "DC_0215":
                                this.chbDuracreto.Checked = true;
                                this.chbDuracreto.Enabled = false;
                                break;
                            case "WYM_TEST":
                                this.chbWYM.Checked = true;
                                this.chbWYM.Enabled = false;
                                break;
                            case "DP_0601":
                                this.chbDP.Checked = true;
                                this.chbDP.Enabled = false;
                                break;
                        }
                    }));
                }else
                {
                    this.Invoke(new Action(() =>
                    {
                        switch (bd)
                        {
                            case "DC_0215":
                                this.chbDuracreto.Checked = false;
                                this.chbDuracreto.Enabled = true;
                                break;
                            case "WYM_TEST":
                                this.chbWYM.Checked = false;
                                this.chbWYM.Enabled = true;
                                break;
                            case "DP_0601":
                                this.chbDP.Checked = false;
                                this.chbDP.Enabled = true;
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
            string[] bds = { "DC_0215", "WYM_TEST", "DP_0601" };

            foreach (string bd in bds)
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
            btnRefrescar.Enabled = true;
            btnActualizar.Enabled = true;
            btnCerrar.Enabled = true;
            dtpFechaTasaFiltro.Enabled = true;
            dtpFechaTasa.Enabled = true;
            txtTasa.Enabled = true;

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

            //Siglo XXI
            if (chbSXXI.Checked)
                chbSXXI.Enabled = false;
            else
                chbSXXI.Enabled = true;

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

            //Escuela Santa Maria del Valle
            if (chbESMV.Checked)
                chbESMV.Enabled = false;
            else
                chbESMV.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            pbCarga.Style = ProgressBarStyle.Marquee;
            pbCarga.Visible = true;
            btnRefrescar.Enabled = false;
            btnActualizar.Enabled = false;
            btnCerrar.Enabled = false;
            dtpFechaTasaFiltro.Enabled = false;
            dtpFechaTasa.Enabled = false;
            txtTasa.Enabled = false;
            chbDuracreto.Enabled = false;
            chbWYM.Enabled = false;
            chbDP.Enabled = false;
            chbTP.Enabled = false;
            chbSXXI.Enabled = false;
            chbINOPSA.Enabled = false;
            chbAMSA.Enabled = false;
            chbESMV.Enabled = false;
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
            else if (chbSXXI.Checked && chbSXXI.Enabled)
                bds.Add("");
            else if (chbINOPSA.Checked && chbINOPSA.Enabled)
                bds.Add("");
            else if (chbAMSA.Checked && chbAMSA.Enabled)
                bds.Add("");
            else if (chbESMV.Checked && chbESMV.Enabled)
                bds.Add("");

            DeshabilitarControles();

            if (dtpFechaTasa.Value.Date < DateTime.Now.Date)
                MessageBox.Show("La fecha no puede ser anterior a hoy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtTasa.Text == null || txtTasa.Text == "")
                MessageBox.Show("El campo de tasa no puede ir vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
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
            }

            await Task.Run(() => ObtenerTasaSimplificado());
            txtTasa.Text = "";
            HabilitarControles();
        }

        private async void btnRefrescar_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();

            await Task.Run(() => ObtenerTasaSimplificado());

            HabilitarControles();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DesconectarBD();
            Application.Exit();
        }
    }
}
