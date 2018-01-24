using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleLogSinkSettings : ILogSinkSettings {
        public string Key => Internals.Constants.SinkKey;
        public string Name { get; set; } = $"{Internals.Constants.SinkPrefix}_{DateTime.Now:yyyyMMdd_HHmmssffff}";
        public LogEventLevel? Level { get; set; }
    }
}