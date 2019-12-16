using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Payloads {
    /// <summary>
    /// Payload
    /// </summary>
    public class LogPayload : ILogPayload {
        private List<LogEvent> LogEvents { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="LogPayload"/>.
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="name"></param>
        /// <param name="events"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public LogPayload(Type sourceType, string name, IEnumerable<LogEvent> events) {
            if (events == null) throw new ArgumentNullException(nameof(events));
            LogEvents = events.ToList();
            SourceType = sourceType;
            Name = name;
        }

        /// <summary>
        /// Create a new instance of <see cref="LogPayload"/>.
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="name"></param>
        /// <param name="events"></param>
        public LogPayload(Type sourceType, string name, params LogEvent[] events)
            : this(sourceType, name, (IEnumerable<LogEvent>) events) { }

        /// <inheritdoc />
        public IEnumerator<LogEvent> GetEnumerator() {
            return LogEvents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public Type SourceType { get; }

        /// <inheritdoc />
        public void Add(LogEvent logEvent) {
            if (logEvent == null) return;
            LogEvents.Add(logEvent);
        }

        /// <inheritdoc />
        public void AddRange(IEnumerable<LogEvent> logEvents) {
            if (logEvents == null || !logEvents.Any()) return;
            LogEvents.AddRange(logEvents.ToList());
        }

        /// <inheritdoc />
        public ILogPayload Export() {
            var ret = new LogPayload(SourceType, Name, LogEvents);
            Reset();
            return ret;
        }

        /// <inheritdoc />
        public void Reset() {
            LogEvents = Enumerable.Empty<LogEvent>().ToList();
        }

        /// <inheritdoc />
        public void Clear() {
            LogEvents.Clear();
        }
    }
}