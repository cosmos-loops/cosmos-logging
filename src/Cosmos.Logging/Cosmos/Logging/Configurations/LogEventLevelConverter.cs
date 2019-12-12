using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Log event level converter
    /// </summary>
    public static class LogEventLevelConverter {
        internal static LogEventLevel Convert(string level, LogEventLevel defaultLevel = LogEventLevel.Verbose) {
            return EnumsNET.Enums.TryParse(level, false, out LogEventLevel logEventLevel)
                ? logEventLevel
                : LogEventLevelAliasManager.AliasToRealLevel(level, defaultLevel);
        }
    }
}