using CalculatorServer.Model;
using CalculatorServer.Utils.Constants;
using CalculatorServer.Utils.Readers;
using NLog;

namespace CalculatorServer.Utils.Configuration
{
    internal sealed class Configuration
    {
        #region Constructors
        public Configuration()
        {
            Settings = LoadServerData();
            ConfigLogger();
        }
        #endregion

        #region Private fields

        #region Singleton fields
        private static Configuration instance = null;
        private static readonly object padlock = new object();
        #endregion

        #endregion

        #region Properties

        #region Singleton properties
        public static Configuration Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Configuration();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public Settings Settings { get; private set; }
        #endregion

        #region Private methods
        private Settings LoadServerData()
        {
            return JsonReader<Settings>.TryReadObject(Paths.ConfigFile);
        }

        private void ConfigLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget()
            {
                FileName = Settings.LoggingFile
            };
            var logconsole = new NLog.Targets.ConsoleTarget();

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            LogManager.Configuration = config;
        }
        #endregion
    }
}
