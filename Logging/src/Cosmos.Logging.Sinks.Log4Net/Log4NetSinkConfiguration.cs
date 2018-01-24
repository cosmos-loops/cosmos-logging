using Cosmos.Logging.Configurations;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetSinkConfiguration : SinkConfiguration {
        public Log4NetSinkConfiguration() : base(Internals.Constants.SinkKey) { }
    }
}