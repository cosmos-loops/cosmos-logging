using Cosmos.Logging.Configurations;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleLogConfiguration : SinkConfiguration {
        public SampleLogConfiguration() : base(Internals.Constants.SinkKey) { }
    }
}