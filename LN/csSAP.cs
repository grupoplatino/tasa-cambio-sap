using System;
using SAPbobsCOM;
using BE;

namespace LN
{
    public class csSAP
    {
        public static Company oCompany; // Objeto para manejar la conexión a SAP
        public static SBObob oSBObob; // Objeto para manejar operaciones de SAP
        public static Recordset oRecordSet; // Objeto para manejar recordsets
        public static Users oUsers; // Objeto para manejar usuarios de SAP
        public static int iRet = 0; // Variable para almacenar el resultado de la conexión
        public static int iErrCod = 0; // Variable para almacenar el código de error
        public static string sErrMsg = ""; // Variable para almacenar el mensaje de error

        public bool ConnectSAP(csCompany objCompany) // Conecta a SAP
        {
            try
            {
                if (oCompany == null)
                {
                    oCompany = new Company(); // Inicializa el objeto Company
                }

                if (!oCompany.Connected) // Valida si el objeto oCompany no tiene ya una conexion activa
                {
                    oCompany.SLDServer = objCompany.SLDServer;
                    oCompany.Server = objCompany.ServerBD;
                    oCompany.DbUserName = objCompany.UserBD;
                    oCompany.DbPassword = objCompany.PwBD;
                    oCompany.CompanyDB = objCompany.NameBD;
                    if (!string.IsNullOrEmpty(objCompany.ServerLic))
                    {
                        oCompany.LicenseServer = objCompany.ServerLic;
                    }
                    oCompany.UserName = objCompany.UserSAP;
                    oCompany.Password = objCompany.PwSAP;
                    oCompany.DbServerType = BoDataServerTypes.dst_HANADB;
                    oCompany.language = BoSuppLangs.ln_Spanish_La;

                    iRet = oCompany.Connect(); // Almacena el resultado de la conexion en iRet si la conexion es exitosa, iRet sera 0, si no, sera diferente de 0

                    if (iRet == 0) 
                    {
                        return true; // Retorna true si la conexion es exitosa
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg); // Obtiene el codigo y mensaje de error de la conexion de SAP
                        throw new Exception($"Error {iErrCod}: {sErrMsg}");
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DisconnectSAP(csCompany objCompany) // Desconecta de SAP
        {
            try
            {
                if (oCompany != null && oCompany.Connected) // Valida si el objeto oCompany tiene una conexion activa
                {
                    oCompany.Disconnect(); // Desconecta de SAP
                    return true; // Retorna true si la desconexion es exitosa
                }
                else
                {
                    return false; // Retorna false si no hay conexion activa
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddRate(ref csORTT objORTT) // Agrega la tasa de cambio
        {
            try
            {
                oSBObob = (SBObob)oCompany.GetBusinessObject(BoObjectTypes.BoBridge); // Se obtiene el objeto SBObob
                oSBObob.SetCurrencyRate(objORTT.Currency, objORTT.RateDate.Date, objORTT.Rate); // Se establece la tasa de cambio mediante el objeto SBObob y el método SetCurrencyRate

                return true; // Retorna true si la tasa de cambio se establece correctamente
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetRate(ref csORTT objORTT) // Obtiene la tasa de cambio
        {
            try
            {
                CleanRecordset(); // Se limpia el recordset

                oSBObob = (SBObob)oCompany.GetBusinessObject(BoObjectTypes.BoBridge); // Se obtiene el objeto SBObob
                oRecordSet = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset); // Se obtiene el objeto Recordset

                oRecordSet = oSBObob.GetCurrencyRate(objORTT.Currency, objORTT.RateDate.Date); // Se obtiene la tasa de cambio mediante el objeto SBObob y el método GetCurrencyRate

                if (oRecordSet.RecordCount == 0 || oRecordSet.Fields.Item(0).Value == null) // Valida si el recordset no tiene registros o si el campo de la tasa de cambio es nulo
                {
                    return false;
                }

                double rate;
                if (!double.TryParse(oRecordSet.Fields.Item(0).Value.ToString(), out rate) || rate <= 0) // Valida si la tasa de cambio es un número válido y mayor que cero
                {
                    return false;
                }

                objORTT.Rate = rate; // Se asigna la tasa de cambio al objeto csORTT
                return true;
            }
            catch (Exception)
            {
                return false; // Retorna false si ocurre una excepción para no interrumpir el flujo del programa
            }
            finally
            {
                CleanRecordset(); // Se limpia el recordset
            }
        }

        public bool ValidateUser(string usersap) // Valida si el usuario existe en SAP
        {
            bool exists = false;

            try
            {
                CleanRecordset(); // Se limpia el recordset

                oRecordSet = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset); // Se obtiene el objeto Recordset
                string query = $"SELECT \"USER_CODE\" FROM OUSR WHERE \"USER_CODE\" = '{usersap}'";
                oRecordSet.DoQuery(query);

                if (oRecordSet.RecordCount > 0) // Valida si el recordset tiene registros significando que el usuario existe
                    exists = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CleanRecordset(); // Se limpia el recordset
            }

            return exists;
        }

        public bool ValidateComputer(string host, string usersap) // Valida si la combinacion de host y usuario existe en SAP
        {
            bool exists = false;

            try
            {
                CleanRecordset(); // Se limpia el recordset

                oRecordSet = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset); // Se obtiene el objeto Recordset
                string query = $"SELECT \"USER_CODE\" FROM OUSR WHERE \"U_Host\" = '{host}' AND \"USER_CODE\" = '{usersap}'"; // Selecciona el usuario y host de la tabla OUSR
                oRecordSet.DoQuery(query);

                if (oRecordSet.RecordCount > 0) // Valida si el recordset tiene registros significando que la combinacion existe
                    exists = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CleanRecordset(); // Se limpia el recordset
            }

            return exists;
        }

        public string GetErrorMessage(Exception ex) // Mejor manejo de errores
        {
            return $"Error: {ex.Message}\nStackTrace: {ex.StackTrace}"; // Retorna el mensaje de error y la traza de la pila
        }

        private int cleanCount = 0; // Contador para el garbage collector
        public void CleanRecordset() // Para limpiar el recordset
        {
            try
            {
                if (oRecordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet); // Libera el objeto COM
                    oRecordSet = null;
                }

                cleanCount++;

                if (cleanCount >= 10) // Cada 10 veces que se llama a esta funcion se hace un garbage collector
                {
                    GC.Collect();
                    cleanCount = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
