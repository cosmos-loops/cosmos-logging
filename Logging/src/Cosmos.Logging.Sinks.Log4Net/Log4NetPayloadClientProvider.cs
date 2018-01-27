using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Configurations;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetPayloadClientProvider : ILogPayloadClientProvider {
        private readonly Log4NetOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;

        public Log4NetPayloadClientProvider(IOptions<Log4NetOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new Log4NetOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new Log4NetPayloadClient(_options.Name, _loggingConfiguration.GetSinkConfiguration<Log4NetSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}