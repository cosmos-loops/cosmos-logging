using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    /// <summary>
    /// Sample log payload client provider
    /// </summary>
    public class SampleLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly SampleOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="SampleLogPayloadClientProvider"/>
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public SampleLogPayloadClientProvider(IOptions<SampleOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new SampleOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        /// <inheritdoc />
        public ILogPayloadClient GetClient() {
            return new SampleLogPayloadClient(_options.Key, _loggingConfiguration.GetSinkConfiguration<SampleLogConfiguration>(Internals.Constants.SinkKey));
        }
    }
}