using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.JdCloud {
    /// <summary>
    /// JdCloud log payload client provider
    /// </summary>
    public class JdCloudLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly JdCloudLogSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="JdCloudLogPayloadClientProvider"/>.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public JdCloudLogPayloadClientProvider(IOptions<JdCloudLogSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _sinkOptions = settings == null ? new JdCloudLogSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        /// <inheritdoc />
        public ILogPayloadClient GetClient() {
            return new JdCloudLogPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<JdCloudLogSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}