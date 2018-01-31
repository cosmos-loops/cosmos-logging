using NLog;
using NLog.Config;
using NLog.Targets;

namespace Cosmos.Logging.Sinks.NLog {
    public class DefaultLoggingTarget : global::NLog.Config.LoggingConfiguration {
        public DefaultLoggingTarget() {

            var consoleTarget = new ColoredConsoleTarget {Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}"};
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);

            AddTarget("_default_console", consoleTarget);
            LoggingRules.Add(rule1);
        }
    }
}