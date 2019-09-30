using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.TencentCloudCls
{
    public class TencentCloudClsPayloadClientProvider : ILogPayloadClientProvider
    {
        private readonly TencentCloudClsSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        public TencentCloudClsPayloadClientProvider(IOptions<TencentCloudClsSinkOptions> settings, LoggingConfiguration loggingConfiguration)
        {
            _sinkOptions = settings == null ? new TencentCloudClsSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient()
        {
            return new TencentCloudClsPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<TencentCloudClsSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}