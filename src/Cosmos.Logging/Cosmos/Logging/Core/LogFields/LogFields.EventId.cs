using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.LogFields {
    /// <summary>
    /// EventId field
    /// </summary>
    public class EventIdField : ILogField<LogEventId> {
        /// <summary>
        /// Create a new instance of <see cref="EventIdField"/>.
        /// </summary>
        public EventIdField() => Value = new LogEventId();

        /// <summary>
        /// Create a new instance of <see cref="EventIdField"/>.
        /// </summary>
        /// <param name="name"></param>
        public EventIdField(string name) => Value = new LogEventId(name);

        /// <summary>
        /// Create a new instance of <see cref="EventIdField"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public EventIdField(Guid id, string name) => Value = new LogEventId(id, name);

        /// <summary>
        /// Create a new instance of <see cref="EventIdField"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public EventIdField(int id, string name) => Value = new LogEventId(id, name);

        /// <summary>
        /// Create a new instance of <see cref="EventIdField"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public EventIdField(string id, string name) => Value = new LogEventId(id, name);

        /// <summary>
        /// Create a new instance of <see cref="EventIdField"/>.
        /// </summary>
        /// <param name="eventId"></param>
        public EventIdField(LogEventId eventId) => Value = eventId;

        /// <inheritdoc />
        public LogFieldTypes Type => LogFieldTypes.EventId;

        /// <inheritdoc />
        public LogEventId Value { get; }

        /// <inheritdoc />
        public int Sort { get; set; } = 1;
    }
}