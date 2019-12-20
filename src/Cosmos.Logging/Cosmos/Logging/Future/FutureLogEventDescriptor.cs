using System;
using System.Collections.Generic;
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

            Context = new LogEventContext(_ownLifetimeContextData);
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
        /// Gets or sets log track id
        /// </summary>
        public string TrackId { get; set; }

        /// <summary>
        /// Gets or sets log track name
        /// </summary>
        public string TrackName { get; set; }

        /// <summary>
        /// Gets or sets business trace id
        /// </summary>
        public string BusinessTraceId { get; set; }

        /// <summary>
        /// Gets or sets exception
        /// </summary>
        public Exception Exception {
            get => _ownLifetimeContextData.GetException();
            set => _ownLifetimeContextData.SetException(value);
        }

        /// <summary>
        /// Gets caller info
        /// </summary>
        public ILogCallerInfo CallerInfo => _callerInfo;

        /// <summary>
        /// Gets or sets context
        /// </summary>
        public LogEventContext Context { get; }

        /// <summary>
        /// Get context data
        /// </summary>
        /// <returns></returns>
        public ContextData GetContextData() {
            var copy = _ownLifetimeContextData.Copy();
            copy.ImportUpstreamContextData(_loggerLifetimeContextData);
            return copy;
        }

        /// <summary>
        /// Get track
        /// </summary>
        /// <returns></returns>
        public LogTrack GetLogTrack() {
            return new LogTrack(TrackId, TrackName, BusinessTraceId);
        }
    }
}