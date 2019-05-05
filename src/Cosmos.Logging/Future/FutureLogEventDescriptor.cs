using System;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;
using Cosmos.Logging.ExtraSupports;

namespace Cosmos.Logging.Future {
    public class FutureLogEventDescriptor {
        private readonly ILogCallerInfo _callerInfo;
        private readonly ContextData _ownLifetimeContextData;
        private readonly ContextData _loggerLifetimeContextData;

        public FutureLogEventDescriptor(ILogCallerInfo callerInfo, ContextData loggerLifetimeContextData) {
            _callerInfo = callerInfo ?? NullLogCallerInfo.Instance;
            _ownLifetimeContextData = new ContextData();
            _loggerLifetimeContextData = loggerLifetimeContextData;
        }

        public LogEventLevel Level { get; set; }
        public string MessageTemplate { get; set; }
        public LogEventId EventId { get; set; } = new LogEventId();
        public Exception Exception { get; set; }
        public ILogCallerInfo CallerInfo => _callerInfo;
        public LogEventContext Context { get; set; } = new LogEventContext();

        public ContextData GetContextData() {
            //todo 本功能尚未完成，请勿集成
            var ret = new ContextData(_ownLifetimeContextData);
            ret.ImportUpstreamContextData(_loggerLifetimeContextData);
            return ret;
        }
    }
}