using System;
using System.Collections.Generic;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Future {
    public class FutureLogEventDescriptor {
        private readonly ILogCallerInfo _callerInfo;
        public FutureLogEventDescriptor(ILogCallerInfo callerInfo) => _callerInfo = callerInfo ?? NullLogCallerInfo.Instance;

        public LogEventLevel Level { get; set; }
        public string MessageTemplate { get; set; }
        public LogEventId EventId { get; set; }
        public Exception Exception { get; set; }
        public ILogCallerInfo CallerInfo => _callerInfo;
        public LogEventContext Context { get; set; } = new LogEventContext();
    }
}