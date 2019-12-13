using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Log4Net {
    /// <summary>
    /// Log4Net payload client provider
    /// </summary>
    public class Log4NetPayloadClientProvider : ILogPayloadClientProvider {
        private readonly Log4NetSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="Log4NetPayloadClientProvider"/>.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public Log4NetPayloadClientProvider(IOptions<Log4NetSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _sinkOptions = settings == null ? new Log4NetSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        /// <inheritdoc />
        public ILogPayloadClient GetClient() {
            return new Log4NetPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<Log4NetSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}