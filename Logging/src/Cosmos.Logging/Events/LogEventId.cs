using System;

namespace Cosmos.Logging.Events {
    public struct LogEventId {
        public LogEventId(string name) : this(Guid.NewGuid().ToString(), name) { }

        public LogEventId(Guid id, string name) : this(id.ToString(), name) { }

        public LogEventId(int id, string name) : this(id.ToString(), name) { }

        public LogEventId(string id, string name) {
            Id = id;
            Timestamp = DateTimeOffset.Now;
            Name = name;
        }

        public DateTimeOffset Timestamp { get; }

        public string Id { get; }

        public string Name { get; }
    }
}