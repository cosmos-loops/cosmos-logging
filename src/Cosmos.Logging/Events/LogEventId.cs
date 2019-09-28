using System;

namespace Cosmos.Logging.Events {
    public class LogEventId{
        private const int DefaultIntegerEventId = 0;
        
        public LogEventId() : this(string.Empty) { }

        public LogEventId(string name) : this(Guid.NewGuid().ToString(), name) { }

        public LogEventId(Guid id, string name) : this(id.ToString(), name) { }

        public LogEventId(int id, string name) : this(id.ToString(), name) { }

        public LogEventId(string id, string name) {
            var baseTime = DateTime.Now;
            Id = id;
            Timestamp = new DateTimeOffset(baseTime, TimeZoneInfo.Local.GetUtcOffset(baseTime));
            Name = name;
        }

        public DateTimeOffset Timestamp { get; }

        public string Id { get; }

        public string Name { get; }

        public int GetIntegerEventId() => int.TryParse(Id, out var ret) ? ret : DefaultIntegerEventId;
    }
}