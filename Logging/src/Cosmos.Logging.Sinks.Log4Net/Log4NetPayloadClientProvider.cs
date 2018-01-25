using System;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Configurations;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetPayloadClientProvider : ILogPayloadClientProvider {
        private readonly Log4NetSinkSettings _settings;
        private readonly LoggingConfiguration _loggingConfiguration;

        public Log4NetPayloadClientProvider(IOptions<Log4NetSinkSettings> settings, LoggingConfiguration loggingConfiguration) {
            _settings = settings == null ? new Log4NetSinkSettings() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new Log4NetPayloadClient(_settings.Name, _loggingConfiguration.GetSinkConfiguration<Log4NetSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}