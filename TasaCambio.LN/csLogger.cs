using System;
using System.IO;

namespace LN
{
    public static class csLogger
    {
        private static readonly object _lock = new object();

        private static string GetLogDirectory()
        {
            try
            {
                var cfg = csConfig.Load();
                var dir = cfg.LogDirectory;
                if (string.IsNullOrWhiteSpace(dir))
                {
                    dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                }

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                return dir;
            }
            catch
            {
                try
                {
                    var fallback = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
                    if (!Directory.Exists(fallback)) Directory.CreateDirectory(fallback);
                    return fallback;
                }
                catch
                {
                    return AppDomain.CurrentDomain.BaseDirectory;
                }
            }
        }

        private static string GetLogFilePath()
        {
            var dir = GetLogDirectory();
            return Path.Combine(dir, $"TasaCambio_{DateTime.Now:yyyyMMdd}.log");
        }

        public static void Info(string message)
        {
            Write("INFO", message);
        }

        public static void Error(string message)
        {
            Write("ERROR", message);
        }

        public static void Debug(string message)
        {
            Write("DEBUG", message);
        }

        private static void Write(string level, string message)
        {
            try
            {
                var path = GetLogFilePath();
                lock (_lock)
                {
                    File.AppendAllText(path, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}{Environment.NewLine}");
                    try
                    {
                        if (!string.Equals(level, "DEBUG", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}");
                        }
                    }
                    catch
                    {
                        // Ignora errores al escribir en consola
                    }
                }
            }
            catch
            {
                // Evita el throw en caso de error en logging
            }
        }
    }
}
