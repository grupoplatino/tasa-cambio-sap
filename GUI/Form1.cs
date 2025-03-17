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
            try
            {
                csCompany objCompany = new csCompany();
                objCompany.ServerBD = this.txtServerBD.Text;
                objCompany.UserBD = this.txtUserBD.Text;
                objCompany.PwBD = this.txtPwBD.Text;
                objCompany.ServerLic = "";
                objCompany.NameBD = CambiarBD();
                objCompany.UserSAP = this.txtUserSAP.Text;
                objCompany.PwSAP = this.txtPwSAP.Text;

                if (oSAP.ConectarSAP(objCompany))
                {
                    string Server = objCompany.ServerBD.Replace("NDB@", "").Replace("30013", "30015");
                    csConexion.IniciarConexionHANA(Server, objCompany.UserBD, objCompany.PwBD, CambiarBD());

                    lblMensaje.ForeColor = Color.Green;
                    lblMensaje.Text = "Conexión exitosa";
                }

                ActualizarTasa();
                oSAP.DesconectarSAP(objCompany);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string CambiarBD()
        {
            return "DC_0215";
        }

        private void ActualizarTasa()
        {
            try
            {
                csORTT objORTT = new csORTT();
                objORTT.Rate = Double.Parse(txtTasa.Text);
                objORTT.RateDate = DateTime.Now;

                if (oSAP.AgregarTasa(ref objORTT))
                {
                    lblMensaje.ForeColor = Color.Green;
                    lblMensaje.Text = "Se agregó la tasa exitosamente";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
