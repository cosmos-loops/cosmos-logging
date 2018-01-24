using System.Collections.Generic;
using Cosmos.Logging.Events;
using EnumsNET;

namespace Cosmos.Logging.Configurations {
    public class LoggingSettings : ILoggerSettings {

        private static readonly LoggingSettings DefaultSetingsCache = new LoggingSettings();
        public static LoggingSettings Defaults => DefaultSetingsCache;

        public string Level { get; set; } = LogEventLevel.Verbose.GetName();
        public string Name { get; set; } = string.Empty;

        public Dictionary<string, ILogSinkSettings> Sinks { get; set; }

        public LogEventLevel GetMinimumLevel() {
            var member = Enums.GetMember<LogEventLevel>(Level, true, EnumFormat.Description);
            return member?.Value ?? LogEventLevel.Verbose;
        }
    }
}