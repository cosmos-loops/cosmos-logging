using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.TomatoLog.Core;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.TomatoLog {
    /// <summary>
    /// Tomato log payload client provider
    /// </summary>
    public class TomatoLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly TomatoLogSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="TomatoLogPayloadClientProvider"/>
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public TomatoLogPayloadClientProvider(IOptions<TomatoLogSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _sinkOptions = settings == null ? new TomatoLogSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        /// <inheritdoc />
        public ILogPayloadClient GetClient() {
            return new TomatoLogPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<TomatoLogSinkConfiguration>(Constants.SinkKey));
        }
    }
}