using System;
using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.NLog {
    public class NLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly NLoggingOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;

        public NLogPayloadClientProvider(IOptions<NLoggingOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new NLoggingOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new NLogPayloadClient(_options.Name, _loggingConfiguration.GetSinkConfiguration<NLogSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}