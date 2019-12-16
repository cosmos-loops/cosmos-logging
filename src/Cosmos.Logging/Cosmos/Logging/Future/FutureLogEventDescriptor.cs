using System;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;
using Cosmos.Logging.ExtraSupports;

namespace Cosmos.Logging.Future {
    /// <summary>
    /// Future log event descriptor
    /// </summary>
    public class FutureLogEventDescriptor {
        private readonly ILogCallerInfo _callerInfo;
        private readonly ContextData _ownLifetimeContextData;
        private readonly ContextData _loggerLifetimeContextData;

        /// <summary>
        /// Create a new instance of <see cref="FutureLogEventDescriptor"/>
        /// </summary>
        /// <param name="callerInfo"></param>
        /// <param name="loggerLifetimeContextData"></param>
        public FutureLogEventDescriptor(ILogCallerInfo callerInfo, ContextData loggerLifetimeContextData) {
            _callerInfo = callerInfo ?? NullLogCallerInfo.Instance;
            _ownLifetimeContextData = new ContextData();
            _loggerLifetimeContextData = loggerLifetimeContextData;
        }

        /// <summary>
        /// Gets or sets log event level
        /// </summary>
        public LogEventLevel Level { get; set; }

        /// <summary>
        /// Gets or sets message template
        /// </summary>
        public string MessageTemplate { get; set; }

        /// <summary>
        /// Gets or sets event id
        /// </summary>
        public LogEventId EventId { get; set; } = new LogEventId();

        /// <summary>
        /// Gets or sets exception
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets caller info
        /// </summary>
        public ILogCallerInfo CallerInfo => _callerInfo;

        /// <summary>
        /// Gets or sets context
        /// </summary>
        public LogEventContext Context { get; set; } = new LogEventContext();

        /// <summary>
        /// Get context data
        /// </summary>
        /// <returns></returns>
        public ContextData GetContextData() {
            //todo 本功能尚未完成，请勿集成
            var ret = new ContextData(_ownLifetimeContextData);
            ret.ImportUpstreamContextData(_loggerLifetimeContextData);
            return ret;
        }
    }
}