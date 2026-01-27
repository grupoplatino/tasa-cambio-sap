using System;
using System.Data.Odbc;

namespace LN
{
    public class csConnection
    {
        public static string ConString = ""; // Cadena de conexión a HANA
        public static OdbcConnection HanaCnn; // Objeto para manejar la conexión a HANA

        public static void StartConnection(string servidor, string user, string pw, string bd) // Se inicializa la conexión a HANA
        {
            try
            {
                // Asigna los valores de conexión a la cadena de conexión de HANA
                ConString = "DRIVER={HDBODBC};UID=" + user + ";PWD=" + pw + ";SERVERNODE=" + servidor + ";CS=" + bd;

                HanaCnn = new OdbcConnection(ConString);

                try
                {
                    HanaCnn.Open(); // Se abre la conexión a HANA

                    if (HanaCnn.State.Equals(0)) // Se valida si la conexión se abrió correctamente
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
