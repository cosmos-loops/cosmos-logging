using System;
using System.Collections.Generic;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.Exceptions.Configurations;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;
using Cosmos.Logging.ExtraSupports;

namespace Cosmos.Logging.Extensions.Exceptions.Core {
    /// <summary>
    /// Exception destructuring processor
    /// </summary>
    public sealed class ExceptionDestructuringProcessor {
        private readonly IExceptionDestructurer _reflectionBasedDestructurer;
        private readonly Dictionary<Type, IExceptionDestructurer> _destructurers;
        private readonly IDestructuringOptions _destructuringOptions;

        /// <inheritdoc />
        public ExceptionDestructuringProcessor() {
            _destructuringOptions = FinalDestructuringOptions.Current;
            if (_destructuringOptions == null)
                throw new ArgumentException("Final destructuring options cannot be null.",
                    nameof(FinalDestructuringOptions.Current));

            _reflectionBasedDestructurer = new ReflectionBasedDestructurer(_destructuringOptions.DestructureDepth);
            _destructurers = new Dictionary<Type, IExceptionDestructurer>();
            foreach (var destructurer in _destructuringOptions.Destructurers)
            foreach (var targetType in destructurer.TargetTypes)
                _destructurers.Add(targetType, destructurer);
        }

        /// <summary>
        /// Destructure the destructured object into LogEvent by built-in property factory
        /// </summary>
        /// <param name="logEvent"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Process(LogEvent logEvent) {
            if (logEvent is null)
                throw new ArgumentNullException(nameof(logEvent));

            if (logEvent.Exception != null) {
                var destructuredObject = Destructure(logEvent.Exception);

                logEvent.AddExtraProperty(_destructuringOptions.Name, destructuredObject, true);
                logEvent.ContextData.SetExceptionDetail(_destructuringOptions.Name, destructuredObject, logEvent.Exception, false);
            }
        }

        /// <summary>
        /// Destructure the destructured object into LogEvent by given property factory.
        /// </summary>
        /// <param name="logEvent"></param>
        /// <param name="factory"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Process(LogEvent logEvent, IShortcutPropertyFactory factory) {
            if (logEvent is null)
                throw new ArgumentNullException(nameof(logEvent));

            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            if (logEvent.Exception != null) {
                var destructuredObject = Destructure(logEvent.Exception);

                logEvent.AddExtraProperty(factory.CreateProperty(_destructuringOptions.Name, destructuredObject, true).AsExtra());
                logEvent.ContextData.SetExceptionDetail(_destructuringOptions.Name, destructuredObject, logEvent.Exception, false);
            }
        }


        private IReadOnlyDictionary<string, object> Destructure(Exception exception) {
            var data = new ExceptionPropertyBag(exception, _destructuringOptions.Filter);
            var type = exception.GetType();

            if (_destructurers.TryGetValue(type, out var destructurer)) {
                destructurer.Destructure(exception, data, Destructure);
            }
            else {
                _reflectionBasedDestructurer.Destructure(exception, data, Destructure);
            }

            return data.GetProperties();
        }
    }
}