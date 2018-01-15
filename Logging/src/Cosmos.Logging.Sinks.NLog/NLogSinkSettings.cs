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

        public void UseDefaultOriginConfigFilePath() => OriginConfigFilePath = "nlog.config";
        public string OriginConfigFilePath { get; set; }

        public void EnableUsingDefaultConfig() => DoesUsedDefaultConfig = true;
        public void DisableUsingDefaultConfig() => DoesUsedDefaultConfig = false;
        internal bool DoesUsedDefaultConfig { get; set; } = true;
    }
}