using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.NLog {
    public class NLoggingOptions : ILoggingSinkOptions<NLoggingOptions>, ILoggingSinkOptions {
        public string Key => Internals.Constants.SinkKey;
        public string Name => $"{Internals.Constants.SinkPrefix}_{DateTime.Now:yyyyMMdd}";
        internal LogEventLevel InternalMinLevel { get; private set; }

        public NLoggingOptions UseMinLevel(LogEventLevel level) {
            InternalMinLevel = level;
            return this;
        }

        public global::NLog.Config.LoggingConfiguration OriginConfiguration { get; set; }

        public void UseDefaultOriginConfigFilePath() => OriginConfigFilePath = "nlog.config";
        public string OriginConfigFilePath { get; set; }

        public void EnableUsingDefaultConfig() => DoesUsedDefaultConfig = true;
        public void DisableUsingDefaultConfig() => DoesUsedDefaultConfig = false;
        internal bool DoesUsedDefaultConfig { get; set; } = true;
    }
}