using System;
using Cosmos.Logging.Core.LogFields;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public static class Fields {
        public static ILogField Level(LogEventLevel level) {
            return new LogEventLevelField(level);
        }

        public static ILogField Message(string messageTemplate, bool append = false) {
            return new MessageTemplateField(messageTemplate, append);
        }

        public static ILogField Exception(Exception exception) {
            return new ExceptionField(exception);
        }

        public static ILogField Args(params object[] args) {
            return new ArgsField(args);
        }

        public static ILogField Tags(params string[] tags) {
            return new TagsField(tags);
        }

        public static ILogField EventId() {
            return new EventIdField();
        }

        public static ILogField EventId(string name) {
            return new EventIdField(name);
        }

        public static ILogField EventId(Guid id, string name) {
            return new EventIdField(id, name);
        }

        public static ILogField EventId(int id, string name) {
            return new EventIdField(id, name);
        }

        public static ILogField EventId(string id, string name) {
            return new EventIdField(id, name);
        }

        public static ILogField EventId(LogEventId eventId) {
            return new EventIdField(eventId);
        }
    }
}