using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Settings;
using NLog.Config;

namespace Cosmos.Logging.Sinks.NLog {
    public class NLogSinkSettings : ILogSinkSettings {
        public string Key => "NLog";
        public string Name { get; set; } = $"NLogSink_{DateTime.Now.ToString("yyyyMMdd_HHmmssffff")}";
        public LogEventLevel? Level { get; set; }

        public LoggingConfiguration OriginConfiguration { get; set; }

        public void RemoveConfig() {
            OriginConfigFilePath = string.Empty;
            OriginConfigType = FileTypes.XML;
        }

        public void UseXmlConfig(string path) {
            OriginConfigFilePath = path;
            OriginConfigType = FileTypes.XML;
        }

        public void UseJsonConfig(string path) {
            OriginConfigFilePath = path;
            OriginConfigType = FileTypes.JSON;
        }

        public void UseDefaultOriginConfigFilePath() => OriginConfigFilePath = "nlog.config";
        internal string OriginConfigFilePath { get; set; }
        internal FileTypes OriginConfigType { get; set; } = FileTypes.XML;

        public void EnableUsingDefaultConfig() => DoesUsedDefaultConfig = true;
        public void DisableUsingDefaultConfig() => DoesUsedDefaultConfig = false;
        internal bool DoesUsedDefaultConfig { get; set; }
    }
}