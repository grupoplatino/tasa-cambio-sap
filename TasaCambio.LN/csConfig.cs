using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LN
{
    public class csConfig
    {
        public class CompanyItem
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string CheckBox { get; set; }
        }
        public List<CompanyItem> CompaniesTest { get; set; } = new List<CompanyItem>();
        public List<CompanyItem> CompaniesProd { get; set; } = new List<CompanyItem>();
        public bool? UseTest { get; set; } = null;
        public bool? UseGUI { get; set; } = null;
        public string OriginDB { get; set; } = string.Empty;
        public string InitialDB { get; set; } = string.Empty;
        public string LogDirectory { get; set; } = string.Empty;
        // Optional query templates that can be stored in the JSON config for security
        public string QueryValidateUser { get; set; } = string.Empty;
        public string QueryValidateComputer { get; set; } = string.Empty;

        private const string ConfigFileName = "exchange_config.json";

        public static csConfig Load()
        {
            var cfg = new csConfig();

            try
            {
                var path = FindConfigPath();
                if (string.IsNullOrEmpty(path) || !File.Exists(path))
                    return cfg;

                var text = File.ReadAllText(path);

                var j = JObject.Parse(text);

                cfg.UseTest = j["UseTest"]?.ToObject<bool?>();
                cfg.UseGUI = j["UseGUI"]?.ToObject<bool?>();
                cfg.OriginDB = j["OriginDB"]?.ToObject<string>() ?? string.Empty;
                cfg.InitialDB = j["InitialDB"]?.ToObject<string>() ?? string.Empty;
                cfg.LogDirectory = j["LogDirectory"]?.ToObject<string>() ?? string.Empty;
                cfg.QueryValidateUser = j["QueryValidateUser"]?.ToObject<string>() ?? string.Empty;
                cfg.QueryValidateComputer = j["QueryValidateComputer"]?.ToObject<string>() ?? string.Empty;

                bool useTestVal = cfg.UseTest ?? true;
                bool loadFull = cfg.UseGUI ?? false;

                var companiesToken = j["Companies"] as JObject;
                if (companiesToken != null)
                {
                    var section = useTestVal ? companiesToken["Test"] : companiesToken["Prod"];
                    if (section is JArray arr)
                    {
                        foreach (var item in arr)
                        {
                            if (item == null) continue;
                            var code = item["Code"]?.ToObject<string>();
                            if (string.IsNullOrWhiteSpace(code)) continue;

                            if (loadFull)
                            {
                                var name = item["Name"]?.ToObject<string>() ?? string.Empty;
                                var chk = item["CheckBox"]?.ToObject<string>() ?? string.Empty;
                                if (useTestVal) cfg.CompaniesTest.Add(new CompanyItem { Code = code, Name = name, CheckBox = chk });
                                else cfg.CompaniesProd.Add(new CompanyItem { Code = code, Name = name, CheckBox = chk });
                            }
                            else
                            {
                                if (useTestVal) cfg.CompaniesTest.Add(new CompanyItem { Code = code });
                                else cfg.CompaniesProd.Add(new CompanyItem { Code = code });
                            }
                        }
                    }
                }
            }
            catch
            {
                // Ignorar errores y devolver configuración por defecto
            }

            return cfg;
        }

        private static string FindConfigPath()
        {
            try
            {
                string dir = AppDomain.CurrentDomain.BaseDirectory;
                var current = new DirectoryInfo(dir);
                while (current != null)
                {
                    var candidate = Path.Combine(current.FullName, ConfigFileName);
                    if (File.Exists(candidate)) return candidate;
                    candidate = Path.Combine(current.FullName, "Config", ConfigFileName);
                    if (File.Exists(candidate)) return candidate;
                    current = current.Parent;
                }
            }
            catch
            {
                // Ignorar errores
            }

            return null;
        }
    }
}

