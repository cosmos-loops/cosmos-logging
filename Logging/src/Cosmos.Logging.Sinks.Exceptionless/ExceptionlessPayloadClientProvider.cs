using System;
using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public class ExceptionlessPayloadClientProvider : ILogPayloadClientProvider {
        private readonly ExceptionlessOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;

        public ExceptionlessPayloadClientProvider(IOptions<ExceptionlessOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new ExceptionlessOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new ExceptionlessPayloadClient(_options.Name, _loggingConfiguration.GetSinkConfiguration<ExceptionlessSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}