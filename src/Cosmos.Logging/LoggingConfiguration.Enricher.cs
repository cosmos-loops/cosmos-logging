using Cosmos.Logging.Core.Enrichers;

namespace Cosmos.Logging {
    public partial class LoggingConfiguration {
        public void SetEnricher(ILogEventEnricher enricher) {
            if (enricher != null) {
                LogEventEnricherManager.UpdateEnricher(enricher);
            }
        }
    }
}