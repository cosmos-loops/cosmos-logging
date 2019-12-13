using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.AliyunSls.Internals;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.AliyunSls {
    /// <summary>
    /// Aliyun SLS Payload client provider
    /// </summary>
    public class AliyunSlsPayloadClientProvider : ILogPayloadClientProvider {
        private readonly AliyunSlsSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="AliyunSlsPayloadClientProvider"/>.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public AliyunSlsPayloadClientProvider(IOptions<AliyunSlsSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _sinkOptions = settings == null ? new AliyunSlsSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        /// <inheritdoc />
        public ILogPayloadClient GetClient() {
            return new AliyunSlsPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<AliyunSlsSinkConfiguration>(Constants.SinkKey));
        }
    }
}