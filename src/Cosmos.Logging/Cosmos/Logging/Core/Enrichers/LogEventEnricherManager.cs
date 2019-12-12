using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core.Enrichers
{
    public static class LogEventEnricherManager
    {
        private static readonly List<ILogEventEnricher> _enrichers;
        private static readonly IShortcutPropertyFactory _propertyFactory;

        static LogEventEnricherManager()
        {
            _enrichers = new List<ILogEventEnricher>();
            _propertyFactory = MessageParameterProcessorCache.Get();
        }

        public static void Enricher(LogEvent logEvent)
        {
            if (logEvent is null)
                throw new ArgumentNullException(nameof(logEvent));

            if (_enrichers is null || !_enrichers.Any())
                return;

            if (_propertyFactory is null)
                return;

            foreach (var enricher in _enrichers)
                enricher.Enrich(logEvent, _propertyFactory);
        }

        internal static void UpdateEnricher(ILogEventEnricher enricher)
        {
            if (enricher == null)
                throw new ArgumentNullException(nameof(enricher));

            _enrichers.Add(enricher);
        }
    }
}