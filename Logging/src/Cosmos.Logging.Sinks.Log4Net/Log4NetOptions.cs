using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetOptions : ILoggingSinkOptions<Log4NetOptions>, ILoggingSinkOptions {
        public string Key => Internals.Constants.SinkKey;
        public string Name => $"{Internals.Constants.SinkPrefix}_{DateTime.Now:yyyyMMdd}";

        #region Append min level

        internal LogEventLevel? InternalMinLevel { get; private set; }

        public Log4NetOptions UseMinLevel(LogEventLevel level) {
            InternalMinLevel = level;
            return this;
        }

        #endregion

        #region Append configuration file path

        public Log4NetOptions UseDefaultOriginConfigFilePath() {
            OriginConfigFilePath = "log4net.config";
            WatchOriginConfigFile = false;
            return this;
        }

        public Log4NetOptions UseDefaultOriginConfigFilePathAndWatch() {
            OriginConfigFilePath = "log4net.config";
            WatchOriginConfigFile = true;
            return this;
        }

        #endregion


        public string OriginConfigFilePath { get; set; }
        public bool WatchOriginConfigFile { get; set; } = false;
    }
}