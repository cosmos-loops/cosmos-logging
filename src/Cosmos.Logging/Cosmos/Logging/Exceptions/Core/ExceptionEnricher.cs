using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Enrichers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Exceptions.Core {
    internal sealed class ExceptionEnricher : ILogEventEnricher {
        private readonly ExceptionDestructuringProcessor _processor;
        
        public ExceptionEnricher(ExceptionDestructuringProcessor processor) {
            _processor = processor ?? throw new ArgumentNullException(nameof(processor));
        }

        public void Enrich(LogEvent logEvent, IShortcutPropertyFactory propertyFactory) {
            if (propertyFactory is null)
                _processor.Process(logEvent);
            else
                _processor.Process(logEvent, propertyFactory);
        }
    }
}