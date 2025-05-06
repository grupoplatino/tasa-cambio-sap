using System;
using System.Data.Odbc;

namespace LN
{
    public class csConnection
    {
        public static string ConString = "";
        public static OdbcConnection HanaCnn;

        public static void StartConnection(string servidor, string user, string pw, string bd) // Se inicializa la conexión a HANA
        {
            try
            {
                ConString = "DRIVER={HDBODBC};UID=" + user + ";PWD=" + pw + ";SERVERNODE=" + servidor + ";CS=" + bd;

                HanaCnn = new OdbcConnection(ConString);

                try
                {
                    HanaCnn.Open(); // Se abre la conexión a HANA

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
