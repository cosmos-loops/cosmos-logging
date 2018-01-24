using Cosmos.Logging.Configurations;

namespace Cosmos.Logging.Sinks.NLog {
    public class NLogSinkConfiguration : SinkConfiguration {
        public NLogSinkConfiguration() : base(Internals.Constants.SinkKey) { }
    }
}