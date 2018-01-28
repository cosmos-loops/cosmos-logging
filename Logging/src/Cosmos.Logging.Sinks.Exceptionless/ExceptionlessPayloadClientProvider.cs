using System;
using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public class ExceptionlessPayloadClientProvider : ILogPayloadClientProvider {
        private readonly ExceptionlessSinkOptions _sinkOptions;
        private readonly LoggingConfiguration _loggingConfiguration;

        public ExceptionlessPayloadClientProvider(IOptions<ExceptionlessSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _sinkOptions = settings == null ? new ExceptionlessSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new ExceptionlessPayloadClient(_sinkOptions.Key, _loggingConfiguration.GetSinkConfiguration<ExceptionlessSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}