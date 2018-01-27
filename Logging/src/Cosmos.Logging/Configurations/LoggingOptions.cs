using System.Collections.Generic;
using Cosmos.Logging.Events;
using EnumsNET;

namespace Cosmos.Logging.Configurations {
    public class LoggingOptions : ILoggingOptions {

        private static readonly LoggingOptions DefaultSetingsCache = new LoggingOptions();
        public static LoggingOptions Defaults => DefaultSetingsCache;

        public string Level { get; set; } = LogEventLevel.Verbose.GetName();
        public string Name { get; set; } = string.Empty;

        public Dictionary<string, ILoggingSinkOptions> Sinks { get; set; }

        public LogEventLevel GetMinimumLevel() {
            var member = Enums.GetMember<LogEventLevel>(Level, true, EnumFormat.Description);
            return member?.Value ?? LogEventLevel.Verbose;
        }
    }
}