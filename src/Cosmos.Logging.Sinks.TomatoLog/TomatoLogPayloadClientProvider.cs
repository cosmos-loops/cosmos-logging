using System;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Sinks.TomatoLog.Core;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.TomatoLog
{
    public class TomatoLogPayloadClientProvider : ILogPayloadClientProvider
    {
        private readonly TomatoLogSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        public TomatoLogPayloadClientProvider(IOptions<TomatoLogSinkOptions> settings, LoggingConfiguration loggingConfiguration)
        {
            _sinkOptions = settings == null ? new TomatoLogSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient()
        {
            return new TomatoLogPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<TomatoLogSinkConfiguration>(Constants.SinkKey));
        }
    }
}