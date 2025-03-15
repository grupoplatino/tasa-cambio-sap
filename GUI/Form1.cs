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

                if (oSAP.AgregarTasa(ref objORTT))
                    lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "Se agregó la tasa exitosamente";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
