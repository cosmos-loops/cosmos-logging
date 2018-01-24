using Cosmos.Logging.Configurations;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public class ExceptionlessSinkConfiguration : SinkConfiguration {
        public ExceptionlessSinkConfiguration() : base(Internals.Constants.SinkKey) { }
    }
}