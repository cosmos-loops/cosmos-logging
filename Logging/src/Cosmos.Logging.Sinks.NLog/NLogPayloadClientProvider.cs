using System;
using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.NLog {
    public class NLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly NLogSinkSettings _settings;
        private readonly LoggingConfiguration _loggingConfiguration;

        public NLogPayloadClientProvider(IOptions<NLogSinkSettings> settings, LoggingConfiguration loggingConfiguration) {
            _settings = settings == null ? new NLogSinkSettings() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new NLogPayloadClient(_settings.Name, _loggingConfiguration.GetSinkConfiguration<NLogSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}