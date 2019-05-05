using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.NLog {
    public class NLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly NLogSinkOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;

        public NLogPayloadClientProvider(IOptions<NLogSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new NLogSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new NLogPayloadClient(_options.Key, _loggingConfiguration.GetSinkConfiguration<NLogSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}