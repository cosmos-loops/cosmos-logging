using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public class ExceptionlessSinkSettings : ILogSinkSettings {
        public string Key => Internals.Constants.SinkKey;
        public string Name { get; set; } = $"{Internals.Constants.SinkPrefix}_{DateTime.Now:yyyyMMdd_HHmmssffff}";
        public LogEventLevel? Level { get; set; }

        public void RemoveConfig() {
            OriginConfigFilePath = string.Empty;
            OriginConfigFileType = FileTypes.JSON;
        }

        public void UseAppSettings(string environmentName = "") {
            if (string.IsNullOrWhiteSpace(environmentName))
                UseJsonConfig("appsettings.json");
            else
                UseJsonConfig($"appsettings.{environmentName}.json");
        }

        public void UseJsonConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginConfigFilePath = path;
            OriginConfigFileType = FileTypes.JSON;
        }

        public void UseXmlConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginConfigFilePath = path;
            OriginConfigFileType = FileTypes.XML;
        }

        internal string OriginConfigFilePath { get; set; }
        internal FileTypes OriginConfigFileType { get; set; } = FileTypes.JSON;


        public string ApiKey { get; set; }
    }
}