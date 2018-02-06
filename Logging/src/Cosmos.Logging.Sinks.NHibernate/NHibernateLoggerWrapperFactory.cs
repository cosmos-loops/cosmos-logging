using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using NHibernate;

namespace Cosmos.Logging.Sinks.NHibernate {
    public class NHibernateLoggerWrapperFactory : global::NHibernate.ILoggerFactory {
        private readonly ILoggingServiceProvider _loggingServiceProvider;
        private readonly RendingConfiguration _renderingOptions;
        private readonly Func<string, LogEventLevel, bool> _filter;
        private static readonly Func<string, LogEventLevel, bool> TrueFilter = (s, l) => true;

        public NHibernateLoggerWrapperFactory(ILoggingServiceProvider loggingServiceProvider, RendingConfiguration renderingOptions) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _renderingOptions = renderingOptions ?? new RendingConfiguration();
            _filter = TrueFilter;
        }

        public NHibernateLoggerWrapperFactory(ILoggingServiceProvider loggingServiceProvider, RendingConfiguration renderingOptions, Func<string, LogEventLevel, bool> filter) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _renderingOptions = renderingOptions ?? new RendingConfiguration();
            _filter = filter ?? TrueFilter;
        }

        public IInternalLogger LoggerFor(string keyName) {
            return new NHibernateLoggerWrapper(_loggingServiceProvider.GetLogger(keyName, _filter, LogEventSendMode.Automatic, _renderingOptions));
        }

        public IInternalLogger LoggerFor(Type type) {
            return new NHibernateLoggerWrapper(_loggingServiceProvider.GetLogger(type, _filter, LogEventSendMode.Automatic, _renderingOptions));
        }
    }
}