using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetPayloadClientProvider : ILogPayloadClientProvider {
        private readonly Log4NetSinkSettings _settings;

        public Log4NetPayloadClientProvider(IOptions<Log4NetSinkSettings> settings) {
            _settings = settings == null ? new Log4NetSinkSettings() : settings.Value;
            //todo to get called method info and iFormatProvider
        }

        public ILogPayloadClient GetClient() {
            return new Log4NetPayloadClient(_settings.Name, _settings.Level);
        }
    }
}