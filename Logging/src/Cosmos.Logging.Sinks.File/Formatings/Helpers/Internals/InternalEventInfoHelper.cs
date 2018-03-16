using System.Text;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.File.Formatings.Helpers.Internals {
    internal static class InternalEventInfoHelper {
        public static string GetEventInfoString(LogEvent logEvent) {
            var eventId = logEvent.EventId;
            return $"[{m0(eventId.Id)} {m1(eventId.Name)}]";

            string m0(string id) => string.IsNullOrWhiteSpace(id) ? "no_id" : id;
            string m1(string name) => string.IsNullOrWhiteSpace(name) ? "null" : name;
        }

        public static string GetEventInfoString(LogEvent logEvent, string commandAlias2) {
            var eventId = logEvent.EventId;

            var stringBuilder = new StringBuilder();
            if (commandAlias2.Contains("I"))
                stringBuilder.Append(m0(eventId.Id));

            if (commandAlias2.Contains("N"))
                stringBuilder.Append(stringBuilder.Length == 0 ? m1(eventId.Name) : $" {m1(eventId.Name)}");

            return stringBuilder.Length == 0 ? string.Empty : $"[{stringBuilder}]";

            string m0(string id) => string.IsNullOrWhiteSpace(id) ? "no_id" : id;
            string m1(string name) => string.IsNullOrWhiteSpace(name) ? "null" : name;
        }
    }
}