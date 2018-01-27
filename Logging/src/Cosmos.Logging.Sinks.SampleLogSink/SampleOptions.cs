using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleOptions : ILoggingSinkOptions<SampleOptions>, ILoggingSinkOptions {
        public SampleOptions() { }
        public string Key => Internals.Constants.SinkKey;
        public string Name => $"{Internals.Constants.SinkPrefix}_{DateTime.Now:yyyyMMdd}";
        internal LogEventLevel InternalMinLevel { get; private set; }

        public SampleOptions UseMinLevel(LogEventLevel level) {
            InternalMinLevel = level;
            return this;
        }
    }
}