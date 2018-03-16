using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.File.Core;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.File {
    public class LocalFileLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly FileSinkOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;
        private readonly FileAstronautCache _fileAstronautCache;

        public LocalFileLogPayloadClientProvider(IOptions<FileSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new FileSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
            _fileAstronautCache = new FileAstronautCache();
        }

        public ILogPayloadClient GetClient() {
            return new LocalFileLogPayloadClient(_options.Key, _fileAstronautCache,
                _loggingConfiguration.GetSinkConfiguration<FileSinkLogConfiguration>(Constants.SinkKey));
        }
    }
}