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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string[] bds = { "DC_0215", "WYM_TEST", "DP_0601" };

            foreach (string bd in bds)
            {
                try
                {
                    ConectarBD(bd);
                    ActualizarTasa(bd);
                    DesconectarBD(bd);
                }
                catch (Exception ex)
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = ex.Message;
                }
            }
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

                    lblMensaje.ForeColor = Color.Green;
                    lblMensaje.Text = "Conexión exitosa a " + bd;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DesconectarBD(string bd)
        {
            try
            {
                csCompany objCompany = new csCompany();
                oSAP.DesconectarSAP(objCompany);
            }
            catch (Exception ex)
            {
                throw ex;
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
                {
                    lblMensaje.ForeColor = Color.Green;
                    lblMensaje.Text = "Se agregó la tasa exitosamente para " + bd;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
