using System.Text;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.File.Formatings.Helpers.Internals {
    internal static class InternalCallerInfoHelper {
        public static string GetCallerInfoString(LogEvent logEvent) {
            var caller = logEvent.CallerInfo;
            switch (logEvent.Level) {
                case LogEventLevel.Verbose:
                case LogEventLevel.Debug:
                case LogEventLevel.Information:
                    return string.IsNullOrWhiteSpace(caller.MemberName)
                        ? string.Empty
                        : caller.MemberName;

                case LogEventLevel.Warning:
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    return $"{caller.FilePath}({caller.LineNumber}):{caller.MemberName}";
            }

            return string.Empty;
        }

        public static string GetCallerInfoString(LogEvent logEvent, string commandAlias2) {
            var caller = logEvent.CallerInfo;
            switch (logEvent.Level) {
                case LogEventLevel.Verbose:
                case LogEventLevel.Debug:
                case LogEventLevel.Information:
                    return commandAlias2.Contains("m") && !string.IsNullOrWhiteSpace(caller.MemberName)
                        ? caller.MemberName
                        : string.Empty;

                case LogEventLevel.Warning:
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    var stringBuilder = new StringBuilder();
                    if (commandAlias2.Contains("f"))
                        stringBuilder.Append(caller.FilePath);
                    if (commandAlias2.Contains("n"))
                        stringBuilder.Append($"({caller.LineNumber})");
                    if (commandAlias2.Contains("m"))
                        stringBuilder.Append(stringBuilder.Length == 0 ? caller.MemberName : $":{caller.MemberName}");
                    return stringBuilder.Length == 0 ? string.Empty : stringBuilder.ToString();

                default: return string.Empty;
            }
        }
    }
}