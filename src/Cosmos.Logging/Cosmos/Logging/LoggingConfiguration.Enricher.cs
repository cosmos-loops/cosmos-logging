using Cosmos.Logging.Core.Enrichers;

namespace Cosmos.Logging {
    /// <summary>
    /// Logging configuration
    /// </summary>
    public partial class LoggingConfiguration {
        /// <summary>
        /// Set enricher
        /// </summary>
        /// <param name="enricher"></param>
        public void SetEnricher(ILogEventEnricher enricher) {
            if (enricher != null) {
                LogEventEnricherManager.UpdateEnricher(enricher);
            }
        }
    }
}