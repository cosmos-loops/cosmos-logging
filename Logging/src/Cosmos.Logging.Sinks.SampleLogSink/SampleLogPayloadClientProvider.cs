using Cosmos.Logging.Collectors;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly SampleLogSinkSettings _settings;

        public SampleLogPayloadClientProvider(IOptions<SampleLogSinkSettings> settings) {
            _settings = settings == null ? new SampleLogSinkSettings() : settings.Value;
        }

        public ILogPayloadClient GetClient() {
            return new SampleLogPayloadClient(_settings.Name, _settings.Level);
        }
    }
}