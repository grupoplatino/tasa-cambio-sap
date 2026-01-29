using System;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using CredentialManagement;
using LN;
using BE;

namespace TasaCambioJob
{
    public class RateJob
    {
        public csSAP oSAP = new csSAP();

        private static csConfig _externalConfig;

        private static string _SLDServer;
        private static string _serverBD;
        private static string _userBD;
        private static string _pwBD;
        private static string _userSAP;
        private static string _pwSAP;

        private static double _exchangeRateUSD;
        private List<string> dbList;

        // Métodos principales
        public void Execute()
        {
            try
            {
                _externalConfig = csConfig.Load();
                LoadCredentials();
                oSAP.CleanRecordset();

                var useTest = _externalConfig?.UseTest ?? true;
                var companiesSource = useTest ? _externalConfig?.CompaniesTest : _externalConfig?.CompaniesProd;

                if (companiesSource == null || companiesSource.Count == 0)
                {
                    csLogger.Error("No hay una lista de empresas configurada. Se aborta el job.");
                    return;
                }

                dbList = companiesSource.Select(c => c.Code).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                string originDb = (_externalConfig != null && !string.IsNullOrWhiteSpace(_externalConfig.OriginDB))
                    ? _externalConfig.OriginDB
                    : string.Empty;

                if (string.IsNullOrWhiteSpace(originDb))
                {
                    csLogger.Error("No hay una empresa inicial configurada.\nSe aborta el job.");
                    return;
                }

                csLogger.Info("Inicia job Tasa de Cambio.");

                bool hasOriginRate = GetRate(originDb);

                if (!hasOriginRate)
                {
                    csLogger.Error("No se encontró tasa en la base de origen.\nSe aborta el job.");
                    return;
                }

                foreach (var bd in dbList)
                {
                    UpdateRate(bd);
                }

                csLogger.Info("Job finalizado.");
            }
            catch (Exception ex)
            {
                csLogger.Error("Fallo general: " + ex.Message + " - " + ex.StackTrace);
            }
        }

        private static void LoadCredentials()
        {
            try
            {
                using (var cred = new Credential { Target = "TasaCambio_HANA" })
                {
                    if (cred.Load())
                    {
                        _userBD = cred.Username;
                        _pwBD = cred.Password;
                    }
                }

                using (var cred = new Credential { Target = "TasaCambio_SAP" })
                {
                    if (cred.Load())
                    {
                        _userSAP = cred.Username;
                        _pwSAP = cred.Password;
                    }
                }

                using (var cred = new Credential { Target = "TasaCambio_Server" })
                {
                    if (cred.Load())
                    {
                        _SLDServer = cred.Username;
                        _serverBD = cred.Password;
                    }
                }
            }
            catch (Exception ex)
            {
                csLogger.Error("Error cargando credenciales: " + ex.Message);
            }
        }

        private bool ConnectDB(string bd)
        {
            try
            {
                csCompany objCompany = new csCompany
                {
                    SLDServer = _SLDServer,
                    ServerBD = _serverBD,
                    UserBD = _userBD,
                    PwBD = _pwBD,
                    ServerLic = "",
                    NameBD = bd,
                    UserSAP = _userSAP,
                    PwSAP = _pwSAP
                };

                if (oSAP.ConnectSAP(objCompany))
                {
                    string Server = objCompany.ServerBD.Replace("NDB@", "").Replace("30013", "30015");
                    csConnection.StartConnection(Server, objCompany.UserBD, objCompany.PwBD, bd);
                    csLogger.Info($"Conectado a {bd}");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                csLogger.Error("Error al conectar a la base de datos: " + ex.Message);
                return false;
            }
        }

        private void DisconnectDB()
        {
            try
            {
                csCompany objCompany = new csCompany();
                oSAP.DisconnectSAP(objCompany);
            }
            catch (Exception ex)
            {
                csLogger.Error("Error al desconectar de la base de datos: " + ex.Message);
            }
        }

        private bool GetRate(string bd)
        {
            bool hasRate = false;
            try
            {
                if (!ConnectDB(bd))
                {
                    csLogger.Error($"No se pudo conectar a {bd}");
                    return false;
                }

                var objORTT = new csORTT
                {
                    Currency = "USD",
                    RateDate = DateTime.Today,
                    Rate = 0,
                    DataSource = '\0',
                    UserSign = 0,
                    Update = false
                };

                hasRate = oSAP.GetRate(ref objORTT);
                _exchangeRateUSD = objORTT.Rate;

                if (hasRate)
                    csLogger.Info($"Tasa encontrada en {bd}: {objORTT.Rate} (fecha {objORTT.RateDate:d})");
                else
                    csLogger.Info($"No existe tasa en {bd} para la fecha {objORTT.RateDate:d}");
            }
            catch (Exception ex)
            {
                csLogger.Error("Error al obtener la tasa de cambio: " + ex.Message);
                hasRate = false;
            }
            finally
            {
                DisconnectDB();
                csLogger.Info($"Desconectado de {bd}");
            }

            return hasRate;
        }

        private void UpdateRate(string bd)
        {
            try
            {
                if (!ConnectDB(bd))
                {
                    csLogger.Error($"No se pudo conectar a {bd}");
                    return;
                }

                var objORTT = new csORTT
                {
                    Currency = "USD",
                    RateDate = DateTime.Today,
                    Rate = _exchangeRateUSD,
                    DataSource = 'M',
                    UserSign = 0,
                    Update = true
                };

                bool updated = oSAP.AddRate(ref objORTT);

                if (updated)
                    csLogger.Info($"Tasa actualizada en {bd}: {objORTT.Rate} (fecha {objORTT.RateDate:d})");
                else
                    csLogger.Error($"No se pudo actualizar la tasa en {bd} para la fecha {objORTT.RateDate:d}");
            }
            catch (Exception ex)
            {
                csLogger.Error($"Error al actualizar la tasa en {bd}: " + ex.Message);
            }
            finally
            {
                DisconnectDB();
                csLogger.Info($"Desconectado de {bd}");
            }
        }
    }
}
