using System.Collections.Generic;
using Cosmos.Logging.Events;
using EnumsNET;

namespace Cosmos.Logging.Configuration {
    public class LoggingSettings : ILoggerSettings {

        private static LoggingSettings DefaultSetingsCache = new LoggingSettings();
        public static LoggingSettings Defaults => DefaultSetingsCache;

        public string Level { get; set; } = Enums.GetName(LogEventLevel.Off);
        public string Name { get; set; } = string.Empty;

        public Dictionary<string, ILogSinkSettings> Sinks { get; set; }

        public LogEventLevel GetMinimumLevel() {
            var member = Enums.GetMember<LogEventLevel>(Level, true, EnumFormat.Description);
            return member?.Value ?? LogEventLevel.Off;
        }
    }
}