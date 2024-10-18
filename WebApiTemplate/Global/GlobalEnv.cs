using Extension;
using Model.SSO;

namespace Global
{
    public sealed class GlobalConfig
    {
        public static GlobalConfig Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private static readonly Lazy<GlobalConfig> lazy = new Lazy<GlobalConfig>();

        private readonly string env;
        private readonly string _appName;
        private readonly string _appVersion;
        private readonly string _sqliteDatabaseName;
        private readonly string _sqliteConStr;
        private readonly string _logLevel;


        public GlobalConfig()
        {

            var builder = new ConfigurationBuilder();

            var appsettingFilename = "appsettings.json";
            builder.AddJsonFile(appsettingFilename, optional: false, reloadOnChange: true);

            // Build the configuration object
            var configuration = builder.Build();
            env = configuration.GetValue("AppConfig:Env", "uat");
            _sqliteDatabaseName = configuration.GetValue("AppConfig:DBFileName", "olif.sqlite");
            _sqliteConStr = $"Data Source={AppContext.BaseDirectory}{_sqliteDatabaseName};Version=3;";
            _logLevel = configuration.GetValue("AppConfig:LogLevel", "debug");

          
        }

       
        public string Environment { get { return env; } }
        public string AppName { get { return _appName; } }
        public string AppVersion { get { return _appVersion; } }
       
        public string SqliteConnectionString { get { return _sqliteConStr; } }
        public string SqliteDatabaseName { get { return _sqliteDatabaseName; } }

        public string LogLevel => _logLevel;

    }
   
}
