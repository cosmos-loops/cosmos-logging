using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.File.Core;
using Cosmos.Logging.Sinks.File.Core.Astronauts;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.File {
    /// <summary>
    /// Local file log payload client provider
    /// </summary>
    public class LocalFileLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly FileSinkOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;
        private readonly FileAstronautCache _fileAstronautCache;

        /// <summary>
        /// Create a new instance of <see cref="LocalFileLogPayloadClientProvider"/>.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public LocalFileLogPayloadClientProvider(IOptions<FileSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new FileSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
            _fileAstronautCache = new FileAstronautCache();
        }

        /// <inheritdoc />
        public ILogPayloadClient GetClient() {
            return new LocalFileLogPayloadClient(_options.Key, _fileAstronautCache,
                _loggingConfiguration.GetSinkConfiguration<FileSinkLogConfiguration>(Constants.SinkKey));
        }
    }
}