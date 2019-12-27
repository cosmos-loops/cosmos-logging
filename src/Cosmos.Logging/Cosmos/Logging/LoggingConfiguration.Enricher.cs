using Cosmos.Logging.Core.Enrichers;
using Cosmos.Optionals;

namespace Cosmos.Logging {
    /// <summary>
    /// Logging configuration
    /// </summary>
    public partial class LoggingConfiguration {
        /// <summary>
        /// Set enricher
        /// </summary>
        /// <param name="enricher"></param>
        public void SetEnricher(Maybe<ILogEventEnricher> enricher) {
            if (enricher.HasValue) {
                LogEventEnricherManager.UpdateEnricher(enricher.Value);
            }
        }
    }
}