using System;
using SAPbobsCOM;
using BE;

namespace LN
{
    public class csSAP
    {
        public static Company oCompany;
        public static SBObob oSBObob;
        public static Recordset oRecordSet;
        public static Users oUsers;
        public static int iRet = 0;
        public static int iErrCod = 0;
        public static string sErrMsg = "";

        public bool ConnectSAP(csCompany objCompany)
        {
            try
            {
                if (oCompany == null)
                {
                    oCompany = new Company();
                }

                if (!oCompany.Connected)
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
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
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

        public bool DisconnectSAP(csCompany objCompany)
        {
            try
            {
                if (oCompany != null && oCompany.Connected) 
                {
                    oCompany.Disconnect();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddRate(ref csORTT objORTT)
        {
            try
            {
                oSBObob = (SBObob)oCompany.GetBusinessObject(BoObjectTypes.BoBridge);
                oSBObob.SetCurrencyRate(objORTT.Currency, objORTT.RateDate.Date, objORTT.Rate); // Se establece la tasa de cambio mediante el objeto SBObob y el método SetCurrencyRate

                return true; // Retorna true si la tasa de cambio se establece correctamente
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetRate(ref csORTT objORTT)
        {
            try
            {
                CleanRecordset();

                oSBObob = (SBObob)oCompany.GetBusinessObject(BoObjectTypes.BoBridge);
                oRecordSet = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);

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

                objORTT.Rate = rate;
                return true;
            }
            catch (Exception)
            {
                return false; // Retorna false si ocurre una excepción para no interrumpir el flujo del programa
            }
            finally
            {
                CleanRecordset();
            }
        }

        public bool ValidateUser(string usersap)
        {
            bool exists = false;

            try
            {
                CleanRecordset();

                oRecordSet = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                string query = $"SELECT \"USER_CODE\" FROM OUSR WHERE \"USER_CODE\" = '{usersap}'";
                oRecordSet.DoQuery(query);

                if (oRecordSet.RecordCount > 0)
                    exists = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CleanRecordset();
            }

            return exists;
        }

        public bool ValidateComputer(string host, string usersap)
        {
            bool exists = false;

            try
            {
                CleanRecordset();

                oRecordSet = (Recordset)oCompany.GetBusinessObject(BoObjectTypes.BoRecordset);
                string query = $"SELECT \"USER_CODE\" FROM OUSR WHERE \"U_Host\" = '{host}' AND \"USER_CODE\" = '{usersap}'";
                oRecordSet.DoQuery(query);

                if (oRecordSet.RecordCount > 0)
                    exists = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CleanRecordset();
            }

            return exists;
        }

        public string GetErrorMessage(Exception ex)
        {
            return $"Error: {ex.Message}\nStackTrace: {ex.StackTrace}";
        }

        private int cleanCount = 0;
        public void CleanRecordset()
        {
            try
            {
                if (oRecordSet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet);
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
