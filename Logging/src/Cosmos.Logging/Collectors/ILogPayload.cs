using System.Collections.Generic;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Collectors {
    public interface ILogPayload : IEnumerable<LogEvent> {
        void Add(LogEvent logEvent);
        void AddRange(IEnumerable<LogEvent> logEvents);
        ILogPayload Export();
        void Reset();
        void Clear();
    }
}