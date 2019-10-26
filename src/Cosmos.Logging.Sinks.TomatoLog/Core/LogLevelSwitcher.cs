using Cosmos.Logging.Events;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Sinks.TomatoLog.Core
{
    internal static class LogLevelSwitcher {
        public static LogLevel Switch(LogEventLevel level) {
            switch (level) {
                case LogEventLevel.Verbose: return LogLevel.Trace;
                case LogEventLevel.Debug: return LogLevel.Debug;
                case LogEventLevel.Information: return LogLevel.Information;
                case LogEventLevel.Warning: return LogLevel.Warning;
                case LogEventLevel.Error: return LogLevel.Error;
                case LogEventLevel.Fatal: return LogLevel.Critical;
                case LogEventLevel.Off: return LogLevel.None;
                default: return LogLevel.None;
            }
        }

        public static LogEventLevel Switch(LogLevel level) {
            switch (level) {
                case LogLevel.Trace: return LogEventLevel.Verbose;
                case LogLevel.Debug: return LogEventLevel.Debug;
                case LogLevel.Information: return LogEventLevel.Information;
                case LogLevel.Warning: return LogEventLevel.Warning;
                case LogLevel.Error: return LogEventLevel.Error;
                case LogLevel.Critical: return LogEventLevel.Fatal;
                case LogLevel.None: return LogEventLevel.Off;
                default: return LogEventLevel.Off;
            }
        }
    }
}