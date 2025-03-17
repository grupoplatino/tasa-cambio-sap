using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using BE;

namespace LN
{
    public class csSAP
    {
        public static SAPbobsCOM.Company oCompany;
        public static int iRet = 0;
        public static int iErrCod = 0;
        public static string sErrMsg = "";

        public bool ConectarSAP(csCompany objCompany)
        {
            try
            {
                if (oCompany == null || oCompany.Connected)
                {
                    oCompany = new Company();
                    oCompany.Server = objCompany.ServerBD;
                    oCompany.DbUserName = objCompany.UserBD;
                    oCompany.DbPassword = objCompany.PwBD;
                    oCompany.CompanyDB = objCompany.NameBD;
                    if (objCompany.ServerLic != "")
                        oCompany.LicenseServer = objCompany.ServerLic;
                    oCompany.UserName = objCompany.UserSAP;
                    oCompany.Password = objCompany.PwSAP;
                    oCompany.DbServerType = BoDataServerTypes.dst_HANADB;
                    oCompany.language = BoSuppLangs.ln_Spanish_La;

                    iRet = oCompany.Connect();

                    if (iRet == 0)
                    {
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod, ": ", sErrMsg));
                    }
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

        public bool DesconectarSAP(csCompany objCompany)
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

        public bool AgregarTasa(ref csORTT objORTT)
        {
            /*SAPbobsCOM.Recordset oRecordset = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            string query = "INSERT INTO ORTT (\"RateDate\", \"Currency\", \"Rate\", \"DataSource\", \"UserSign\") VALUES ('2025-03-14', 'USD', 25.50, 'O', 7);";

            oRecordset.DoQuery(query);*/



            return true;
        }
    }
}
