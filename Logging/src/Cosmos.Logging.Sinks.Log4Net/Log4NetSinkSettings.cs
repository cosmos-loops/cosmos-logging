using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetSinkSettings : ILogSinkSettings {
        public string Key => Internals.Constants.SinkKey;
        public string Name { get; set; } = $"{Internals.Constants.SinkPrefix}_{DateTime.Now:yyyyMMdd_HHmmssffff}";
        public LogEventLevel? Level { get; set; }

        public void UseDefaultOriginConfigFilePath() {
            OriginConfigFilePath = "log4net.config";
            WatchOriginConfigFile = false;
        }

        public void UseDefaultOriginConfigFilePathAndWatch() {
            OriginConfigFilePath = "log4net.config";
            WatchOriginConfigFile = true;
        }

        public string OriginConfigFilePath { get; set; }
        public bool WatchOriginConfigFile { get; set; } = false;
    }
}