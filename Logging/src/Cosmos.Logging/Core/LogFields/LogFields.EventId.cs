using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.LogFields {
    public class EventIdField : ILogField<LogEventId> {
        public EventIdField() => Value = new LogEventId();
        public EventIdField(string name) => Value = new LogEventId(name);
        public EventIdField(Guid id, string name) => Value = new LogEventId(id, name);
        public EventIdField(int id, string name) => Value = new LogEventId(id, name);
        public EventIdField(string id, string name) => Value = new LogEventId(id, name);
        public EventIdField(LogEventId eventId) => Value = eventId;
        public LogFieldTypes Type => LogFieldTypes.EventId;
        public LogEventId Value { get; }
        public int Sort { get; set; } = 1;
    }
}