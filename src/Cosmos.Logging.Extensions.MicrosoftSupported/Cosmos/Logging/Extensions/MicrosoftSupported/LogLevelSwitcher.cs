using Cosmos.Logging.Events;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Extensions.MicrosoftSupported {
    /// <summary>
    /// Log level switcher
    /// </summary>
    public static class LogLevelSwitcher {
        /// <summary>
        /// Switch
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static LogLevel Switch(LogEventLevel level) {
            return level switch {
                LogEventLevel.Verbose     => LogLevel.Trace,
                LogEventLevel.Debug       => LogLevel.Debug,
                LogEventLevel.Information => LogLevel.Information,
                LogEventLevel.Warning     => LogLevel.Warning,
                LogEventLevel.Error       => LogLevel.Error,
                LogEventLevel.Fatal       => LogLevel.Critical,
                LogEventLevel.Off         => LogLevel.None,
                _                         => LogLevel.None
            };
        }

        /// <summary>
        /// Switch
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static LogEventLevel Switch(LogLevel level) {
            return level switch {
                LogLevel.Trace       => LogEventLevel.Verbose,
                LogLevel.Debug       => LogEventLevel.Debug,
                LogLevel.Information => LogEventLevel.Information,
                LogLevel.Warning     => LogEventLevel.Warning,
                LogLevel.Error       => LogEventLevel.Error,
                LogLevel.Critical    => LogEventLevel.Fatal,
                LogLevel.None        => LogEventLevel.Off,
                _                    => LogEventLevel.Off
            };
        }
    }
}