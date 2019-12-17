using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Exceptionless {
    /// <summary>
    /// Exceptionless payload client provider
    /// </summary>
    public class ExceptionlessPayloadClientProvider : ILogPayloadClientProvider {
        private readonly ExceptionlessSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="ExceptionlessPayloadClientProvider"/>.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public ExceptionlessPayloadClientProvider(IOptions<ExceptionlessSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _sinkOptions = settings == null ? new ExceptionlessSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        /// <inheritdoc />
        public ILogPayloadClient GetClient() {
            return new ExceptionlessPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<ExceptionlessSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}