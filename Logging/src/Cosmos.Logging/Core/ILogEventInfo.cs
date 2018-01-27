using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core {
    public interface ILogEventInfo {
        DateTimeOffset Timestamp { get; }
        LogEventLevel Level { get; }
        LogEventSendMode SendMode { get; }
        Exception Exception { get; }
    }
}