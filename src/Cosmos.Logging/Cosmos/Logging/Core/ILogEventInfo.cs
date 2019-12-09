using System;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface for log event info
    /// </summary>
    public interface ILogEventInfo {
        /// <summary>
        /// Gets state namespace
        /// </summary>
        string StateNamespace { get; }

        /// <summary>
        /// Gets event id
        /// </summary>
        LogEventId EventId { get; }

        /// <summary>
        /// Gets timespace
        /// </summary>
        DateTimeOffset Timestamp { get; }

        /// <summary>
        /// Gets log event level
        /// </summary>
        LogEventLevel Level { get; }

        /// <summary>
        /// Gets send mode
        /// </summary>
        LogEventSendMode SendMode { get; }

        /// <summary>
        /// Gets exception
        /// </summary>
        Exception Exception { get; }

        /// <summary>
        /// Gets caller info
        /// </summary>
        ILogCallerInfo CallerInfo { get; }

        /// <summary>
        /// To log event
        /// </summary>
        /// <returns></returns>
        LogEvent ToLogEvent();

        /// <summary>
        /// To contextual log event
        /// </summary>
        /// <returns></returns>
        IContextualLogEvent ToContextualLogEvent();
    }
}