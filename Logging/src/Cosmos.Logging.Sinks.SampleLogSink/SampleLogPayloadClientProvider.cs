using Cosmos.Logging.Collectors;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleLogPayloadClientProvider : ILogPayloadClientProvider {
        private readonly SampleLogSinkSettings _settings;

        public SampleLogPayloadClientProvider(SampleLogSinkSettings settings) {
            _settings = settings ?? new SampleLogSinkSettings();
        }

        public ILogPayloadClient GetClient() {
            return new SampleLogPayloadClient(_settings.Name, _settings.Level);
        }
    }
}