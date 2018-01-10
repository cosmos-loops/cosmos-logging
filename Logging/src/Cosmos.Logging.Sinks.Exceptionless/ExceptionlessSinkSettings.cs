using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Settings;
using Exceptionless;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public class ExceptionlessSinkSettings : ILogSinkSettings {
        public string Key => "Exceptionless";
        public string Name { get; set; } = $"ExceptionlessSink_{DateTime.Now.ToString("yyyyMMdd_HHmmssffff")}";
        public LogEventLevel? Level { get; set; }

        public void RemoveFilePath() {
            OriginConfigFilePath = string.Empty;
            OriginConfigFileType = FileTypes.JSON;
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

        public void UseYamlConfig(string path) {
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            OriginConfigFilePath = path;
            OriginConfigFileType = FileTypes.YAML;
        }

        internal string OriginConfigFilePath { get; set; }
        internal FileTypes OriginConfigFileType { get; set; } = FileTypes.JSON;


        public string ApiKey { get; set; }
    }
}