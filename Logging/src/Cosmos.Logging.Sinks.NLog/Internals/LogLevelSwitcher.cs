using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.NLog.Internals {
    internal static class LogLevelSwitcher {
        public static global::NLog.LogLevel Switch(LogEventLevel level) {
            switch (level) {
                case LogEventLevel.Verbose:
                    return global::NLog.LogLevel.Trace;
                case LogEventLevel.Debug:
                    return global::NLog.LogLevel.Debug;
                case LogEventLevel.Information:
                    return global::NLog.LogLevel.Info;
                case LogEventLevel.Warning:
                    return global::NLog.LogLevel.Warn;
                case LogEventLevel.Error:
                    return global::NLog.LogLevel.Error;
                case LogEventLevel.Fatal:
                    return global::NLog.LogLevel.Fatal;
                case LogEventLevel.Off:
                    return global::NLog.LogLevel.Off;
                default:
                    return global::NLog.LogLevel.Info;
            }
        }
    }
}