using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.TencentCloudCls.Core;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.TencentCloudCls {
    /// <summary>
    /// Tencent Cloud CLS payload client provider
    /// </summary>
    public class TencentCloudClsPayloadClientProvider : ILogPayloadClientProvider {
        private readonly TencentCloudClsSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="TencentCloudClsPayloadClientProvider"/>.
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="loggingConfiguration"></param>
        public TencentCloudClsPayloadClientProvider(IOptions<TencentCloudClsSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _sinkOptions = settings == null ? new TencentCloudClsSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        /// <inheritdoc />
        public ILogPayloadClient GetClient() {
            return new TencentCloudClsPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<TencentCloudClsSinkConfiguration>(Constants.SinkKey));
        }
    }
}