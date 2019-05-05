using System;
using System.Collections.Generic;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Payloads {
    public interface ILogPayload : IEnumerable<LogEvent> {
        string Name { get; }
        Type SourceType { get; }
        void Add(LogEvent logEvent);
        void AddRange(IEnumerable<LogEvent> logEvents);
        ILogPayload Export();
        void Reset();
        void Clear();
    }
}