using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Enrichers {
    /// <summary>
    /// Interface for log event enricher
    /// </summary>
    public interface ILogEventEnricher {
        /// <summary>
        /// Enrich
        /// </summary>
        /// <param name="logEvent"></param>
        /// <param name="propertyFactory"></param>
        void Enrich(LogEvent logEvent, IShortcutPropertyFactory propertyFactory);
    }
}