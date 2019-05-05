using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetPayloadClientProvider : ILogPayloadClientProvider {
        private readonly Log4NetSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        public Log4NetPayloadClientProvider(IOptions<Log4NetSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _sinkOptions = settings == null ? new Log4NetSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new Log4NetPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<Log4NetSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}