using System;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core {
    public interface ILogEventInfo {
        string StateNamespace { get; }
        DateTimeOffset Timestamp { get; }
        LogEventLevel Level { get; }
        LogEventSendMode SendMode { get; }
        Exception Exception { get; }
        ILogCallerInfo CallerInfo { get; }
    }
}