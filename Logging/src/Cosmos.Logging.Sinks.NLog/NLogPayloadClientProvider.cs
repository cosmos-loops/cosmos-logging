using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.NLog {
    public class NLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly NLogSinkSettings _settings;

        public NLogPayloadClientProvider(IOptions<NLogSinkSettings> settings) {
            _settings = settings == null ? new NLogSinkSettings() : settings.Value;
            //todo to get called method info and iFormatProvider
        }

        public ILogPayloadClient GetClient() {
            return new NLogPayloadClient(_settings.Name, _settings.Level);
        }
    }
}