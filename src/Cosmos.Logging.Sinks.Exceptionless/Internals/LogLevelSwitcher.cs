using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.Exceptionless.Internals {
    internal static class LogLevelSwitcher {
        public static global::Exceptionless.Logging.LogLevel Switch(LogEventLevel level) {
            switch (level) {
                case LogEventLevel.Verbose:
                    return global::Exceptionless.Logging.LogLevel.Trace;
                case LogEventLevel.Debug:
                    return global::Exceptionless.Logging.LogLevel.Debug;
                case LogEventLevel.Information:
                    return global::Exceptionless.Logging.LogLevel.Info;
                case LogEventLevel.Warning:
                    return global::Exceptionless.Logging.LogLevel.Warn;
                case LogEventLevel.Error:
                    return global::Exceptionless.Logging.LogLevel.Error;
                case LogEventLevel.Fatal:
                    return global::Exceptionless.Logging.LogLevel.Fatal;
                case LogEventLevel.Off:
                    return global::Exceptionless.Logging.LogLevel.Off;
                default:
                    return global::Exceptionless.Logging.LogLevel.Info;
            }
        }
    }
}