using System;
using System.IO;
using Microsoft.Extensions.Logging;
using NReco.Logging.File;

namespace SprdCore
{
    public static class Logging
    {
        public static FileInfo LogFile;
        public static ILogger Logger;

        static Logging()
        {
            var directory = Path.Join(Path.GetTempPath(), "SPRD");
            LogFile = new FileInfo(Path.Join(directory,
                string.Format("sprd-{0}.log", DateTime.Now.ToString("yyyy-MM-dd"))));


            var loggerSettings = new FileLoggerOptions()
            {
                FileSizeLimitBytes = 1024 * 8,
                MaxRollingFiles = 5,
                Append = true
            };
            var fileAppender = new FileLoggerProvider(LogFile.FullName, loggerSettings);
            fileAppender.MinLevel = LogLevel.Debug;

            var factory = new LoggerFactory();
            factory.AddProvider(fileAppender);

            Logger = factory.CreateLogger("SPRD_FILE");

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            Logger.LogInformation("Starting SPRD version {0}", version);

            Logger.LogTrace("Log settings: FileSizeLimitBytes='{0}' MaxRollingFiles='{1}' Append='{2}' MinLevel='{3}'", loggerSettings.FileSizeLimitBytes, loggerSettings.MaxRollingFiles, loggerSettings.Append,  fileAppender.MinLevel);

        }
    }
}