using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace LN
{
    public class csConexion
    {
        public static string Cadena = "";
        public static OdbcConnection HanaCnn;

        public static void IniciarConexionHANA(string servidor, string user, string pw, string bd)
        {
            try
            {
                Cadena = "DRIVER={HDBODBC};UID=" + user + ";PWD=" + pw + ";SERVERNODE=" + servidor + ";CS=" + bd;

                HanaCnn = new OdbcConnection(Cadena);

                try
                {
                    HanaCnn.Open();

                    if (HanaCnn.State.Equals(0))
                        throw new Exception("Error de conexión HANA");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
