using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Payloads {
    public class LogPayload : ILogPayload {
        private List<LogEvent> LogEvents { get; set; }

        public LogPayload(Type sourceType, string name, IEnumerable<LogEvent> events) {
            if (events == null) throw new ArgumentNullException(nameof(events));
            LogEvents = events.ToList();
            SourceType = sourceType;
            Name = name;
        }

        public LogPayload(Type sourceType, string name, params LogEvent[] events)
            : this(sourceType, name, (IEnumerable<LogEvent>) events) { }

        public IEnumerator<LogEvent> GetEnumerator() {
            return LogEvents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public string Name { get; }
        public Type SourceType { get; }

        public void Add(LogEvent logEvent) {
            if (logEvent == null) return;
            LogEvents.Add(logEvent);
        }

        public void AddRange(IEnumerable<LogEvent> logEvents) {
            if (logEvents == null || !logEvents.Any()) return;
            LogEvents.AddRange(logEvents.ToList());
        }

        public ILogPayload Export() {
            var ret = new LogPayload(SourceType, Name, LogEvents);
            Reset();
            return ret;
        }

        public void Reset() {
            LogEvents = Enumerable.Empty<LogEvent>().ToList();
        }

        public void Clear() {
            LogEvents.Clear();
        }
    }
}