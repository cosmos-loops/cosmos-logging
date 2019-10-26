using System;
using Cosmos.Logging.Core.Payloads;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Console
{
    public class ConsolePayloadClientProvider: ILogPayloadClientProvider
    {
        private readonly ConsoleSinkOptions _options;
        private readonly LoggingConfiguration _loggingConfiguration;
        
        public ConsolePayloadClientProvider(IOptions<ConsoleSinkOptions> settings, LoggingConfiguration loggingConfiguration) {
            _options = settings == null ? new ConsoleSinkOptions() : settings.Value;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        public ILogPayloadClient GetClient() {
            return new ConsolePayloadClient(_options.Key, _loggingConfiguration.GetSinkConfiguration<ConsoleSinkConfiguration>(Internals.Constants.SinkKey));
        }
    }
}