using System;
using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly SampleLogSinkSettings _settings;
        private readonly LoggingConfiguration _loggingConfiguration;

        public SampleLogPayloadClientProvider(IOptions<SampleLogSinkSettings> settings, LoggingConfiguration loggingConfiguration) {
            _settings = settings == null ? new SampleLogSinkSettings() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new SampleLogPayloadClient(_settings.Name, _loggingConfiguration.GetSinkConfiguration<SampleLogConfiguration>(Internals.Constants.SinkKey));
        }
    }
}