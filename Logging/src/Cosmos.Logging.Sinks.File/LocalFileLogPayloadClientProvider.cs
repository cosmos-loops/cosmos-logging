using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.File {
    public class LocalFileLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly FileSinkOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;

        public LocalFileLogPayloadClientProvider(IOptions<FileSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new FileSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new LocalFileLogPayloadClient(_options.Key, _loggingConfiguration.GetSinkConfiguration<FileSinkLogConfiguration>(Internals.Constants.SinkKey));
        }
    }
}