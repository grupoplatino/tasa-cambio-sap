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
                    WriteLog("No hay una lista de empresas configurada. Se aborta el job.");
                    return;
                }

                dbList = companiesSource.Select(c => c.Code).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

                string originDb = (_externalConfig != null && !string.IsNullOrWhiteSpace(_externalConfig.OriginDB))
                    ? _externalConfig.OriginDB
                    : string.Empty;

                if (string.IsNullOrWhiteSpace(originDb))
                {
                    WriteLog("No hay una empresa inicial configurada.\nSe aborta el job.");
                    return;
                }

                WriteLog("Inicia job Tasa de Cambio.");

                bool hasOriginRate = GetRate(originDb);

                if (!hasOriginRate)
                {
                    WriteLog("No se encontró tasa en la base de origen.\nSe aborta el job.");
                    return;
                }

                foreach (var bd in dbList)
                {
                    UpdateRate(bd);
                }

                WriteLog("Job finalizado.");
            }
            catch (Exception ex)
            {
                WriteLog("Fallo general: " + ex.Message + " - " + ex.StackTrace);
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
                WriteLog("Error cargando credenciales: " + ex.Message);
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
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                WriteLog("Error al conectar a la base de datos: " + ex.Message);
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
                WriteLog("Error al desconectar de la base de datos: " + ex.Message);
            }
        }

        private bool GetRate(string bd)
        {
            bool hasRate = false;
            try
            {
                if (!ConnectDB(bd))
                {
                    WriteLog($"No se pudo conectar a {bd}");
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
                    WriteLog($"\nTasa encontrada en {bd}: {objORTT.Rate} (fecha {objORTT.RateDate:d})");
                else
                    WriteLog($"\nNo existe tasa en {bd} para la fecha {objORTT.RateDate:d}");
            }
            catch (Exception ex)
            {
                WriteLog("\nError al obtener la tasa de cambio: " + ex.Message);
                hasRate = false;
            }
            finally
            {
                DisconnectDB();
                WriteLog($"Desconectado de {bd}\n");
            }

            return hasRate;
        }

        private void UpdateRate(string bd)
        {
            try
            {
                if (!ConnectDB(bd))
                {
                    WriteLog($"No se pudo conectar a {bd}");
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
                    WriteLog($"Tasa actualizada en {bd}: {objORTT.Rate} (fecha {objORTT.RateDate:d})");
                else
                    WriteLog($"No se pudo actualizar la tasa en {bd} para la fecha {objORTT.RateDate:d}");
            }
            catch (Exception ex)
            {
                WriteLog("Error al actualizar la tasa de cambio: " + ex.Message);
            }
            finally
            {
                DisconnectDB();
                WriteLog($"Desconectado de {bd}\n");
            }
        }

        private static void WriteLog(string log)
        {
            try
            {
                if (_externalConfig != null && !string.IsNullOrWhiteSpace(_externalConfig.LogDirectory))
                {
                    string logDir = _externalConfig.LogDirectory;
                    string logPath = Path.Combine(logDir, $"LogTasaCambio_{DateTime.Now:yyyyMMdd}.txt");
                    var dir = Path.GetDirectoryName(logPath);
                    if (!string.IsNullOrWhiteSpace(dir)) Directory.CreateDirectory(dir);
                    using (StreamWriter writer = new StreamWriter(logPath, true))
                    {
                        writer.WriteLine($"{DateTime.Now}: {log}");
                    }
                }
            }
            catch
            {
                // Ignorar errores de logging
            }
            finally
            {
                Console.WriteLine(log);
            }
        }
    }
}
