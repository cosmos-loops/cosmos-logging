using System;
using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public class ExceptionlessPayloadClientProvider : ILogPayloadClientProvider {
        private readonly ExceptionlessSinkSettings _settings;
        private readonly LoggingConfiguration _loggingConfiguration;

        public ExceptionlessPayloadClientProvider(IOptions<ExceptionlessSinkSettings> settings, LoggingConfiguration loggingConfiguration) {
            _settings = settings == null ? new ExceptionlessSinkSettings() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new ExceptionlessPayloadClient(_settings.Name, _loggingConfiguration.GetSinkConfiguration<ExceptionlessSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}