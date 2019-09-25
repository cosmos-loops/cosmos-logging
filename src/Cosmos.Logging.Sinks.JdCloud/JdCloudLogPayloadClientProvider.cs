using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.JdCloud
{
    public class JdCloudLogPayloadClientProvider : ILogPayloadClientProvider
    {
        private readonly JdCloudLogSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        public JdCloudLogPayloadClientProvider(IOptions<JdCloudLogSinkOptions> settings, LoggingConfiguration loggingConfiguration)
        {
            _sinkOptions = settings == null ? new JdCloudLogSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient()
        {
            return new JdCloudLogPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<JdCloudLogSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}