using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.NLog {
    /// <summary>
    /// NLog payload client provider
    /// </summary>
    public class NLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly NLogSinkOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="NLogPayloadClientProvider"/>
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public NLogPayloadClientProvider(IOptions<NLogSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new NLogSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        /// <inheritdoc />
        public ILogPayloadClient GetClient() {
            return new NLogPayloadClient(_options.Key, _loggingConfiguration.GetSinkConfiguration<NLogSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}