using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public class ExceptionlessPayloadClientProvider : ILogPayloadClientProvider {
        private readonly ExceptionlessSinkSettings _settings;

        public ExceptionlessPayloadClientProvider(IOptions<ExceptionlessSinkSettings> settings) {
            _settings = settings == null ? new ExceptionlessSinkSettings() : settings.Value;
            //todo to get called method info and iFormatProvider
        }

        public ILogPayloadClient GetClient() {
            return new ExceptionlessPayloadClient(_settings.Name, _settings.Level);
        }
    }
}