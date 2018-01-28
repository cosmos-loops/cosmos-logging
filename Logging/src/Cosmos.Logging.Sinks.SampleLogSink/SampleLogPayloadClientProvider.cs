using System;
using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly SampleOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;

        public SampleLogPayloadClientProvider(IOptions<SampleOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new SampleOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new SampleLogPayloadClient(_options.Key, _loggingConfiguration.GetSinkConfiguration<SampleLogConfiguration>(Internals.Constants.SinkKey));
        }
    }
}