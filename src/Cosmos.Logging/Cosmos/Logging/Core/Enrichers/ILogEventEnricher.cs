using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Enrichers
{
    public interface ILogEventEnricher
    {
        void Enrich(LogEvent logEvent, IShortcutPropertyFactory propertyFactory);
    }
}