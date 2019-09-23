using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.AliyunSls
{
    public class AliyunSlsPayloadClientProvider : ILogPayloadClientProvider
    {
        private readonly AliyunSlsSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        public AliyunSlsPayloadClientProvider(IOptions<AliyunSlsSinkOptions> settings, LoggingConfiguration loggingConfiguration)
        {
            _sinkOptions = settings == null ? new AliyunSlsSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient()
        {
            return new AliyunSlsPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<AliyunSlsSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}