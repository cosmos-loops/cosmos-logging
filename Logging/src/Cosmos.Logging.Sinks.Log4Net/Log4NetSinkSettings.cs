using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Settings;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetSinkSettings : ILogSinkSettings {
        public string Key => "Log4Net";
        public string Name { get; set; } = $"Log4NetSink_{DateTime.Now.ToString("yyyyMMdd_HHmmssffff")}";
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