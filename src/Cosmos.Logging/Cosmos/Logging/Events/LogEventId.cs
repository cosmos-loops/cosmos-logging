using System;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Log event id
    /// </summary>
    public partial class LogEventId {
        private const int DefaultIntegerEventId = 0;

        private readonly LogEventId _parentEventId;

        /// <summary>
        /// Create a new instance of <see cref="LogEventId"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="traceId"></param>
        internal LogEventId(string id, string name, string traceId) {
            Id = id;
            Name = name;
            TraceId = traceId;
            Timestamp = Now();
            _parentEventId = default;
        }

        /// <summary>
        /// Create a new instance of <see cref="LogEventId"/>.
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        internal LogEventId(LogEventId eventId, string id, string name) {
            Id = id;
            Name = name;
            TraceId = eventId.TraceId;
            Timestamp = Now();
            _parentEventId = eventId;
        }

        private static DateTimeOffset Now() {
            var _ = DateTime.Now;
            return new DateTimeOffset(_, TimeZoneInfo.Local.GetUtcOffset(_));
        }

        #region Basic ops

        /// <summary>
        /// Gets timestamp
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// Gets log event id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets trace id
        /// </summary>
        public string TraceId { get; }

        /// <summary>
        /// Gets or sets business trace id
        /// </summary>
        public string BusinessTraceId { get; set; }

        /// <summary>
        /// Gets or sets Logging Scope trace id
        /// </summary>
        public string LoggingScopeTraceId { get; set; }

        /// <summary>
        /// Gets log event name
        /// </summary>
        public string Name { get; }

        #endregion

        #region Parent ops

        /// <summary>
        /// Has parent event id
        /// </summary>
        public bool HasParentEventId => _parentEventId != null;

        /// <summary>
        /// Gets parent event id
        /// </summary>
        public LogEventId Parent => _parentEventId;

        #endregion

        #region Getter

        /// <summary>
        /// Get integer event id
        /// </summary>
        /// <returns></returns>
        public int GetIntegerEventId() => int.TryParse(Id, out var ret) ? ret : DefaultIntegerEventId;

        #endregion

    }
}