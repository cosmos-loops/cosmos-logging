using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using NHibernate;

namespace Cosmos.Logging.Extensions.NHibernate {
    /// <summary>
    /// NHibernate logger wrapper factory
    /// </summary>
    public class NHibernateLoggerWrapperFactory : INHibernateLoggerFactory {
        private readonly ILoggingServiceProvider _loggingServiceProvider;
        private readonly RenderingConfiguration _renderingOptions;
        private readonly Func<string, LogEventLevel, bool> _filter;
        private static readonly Func<string, LogEventLevel, bool> TrueFilter = (s, l) => true;

        /// <inheritdoc />
        public NHibernateLoggerWrapperFactory(ILoggingServiceProvider loggingServiceProvider, RenderingConfiguration renderingOptions)
            : this(loggingServiceProvider, renderingOptions, TrueFilter) { }

        /// <inheritdoc />
        public NHibernateLoggerWrapperFactory(ILoggingServiceProvider loggingServiceProvider, RenderingConfiguration renderingOptions, Func<string, LogEventLevel, bool> filter) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _renderingOptions = renderingOptions ?? new RenderingConfiguration();
            _filter = filter ?? TrueFilter;
        }

        /// <inheritdoc />
        public INHibernateLogger LoggerFor(string keyName) {
            return new NHibernateLoggerWrapper(_loggingServiceProvider.GetLogger(keyName, _filter, LogEventSendMode.Automatic, _renderingOptions));
        }

        /// <inheritdoc />
        public INHibernateLogger LoggerFor(Type type) {
            return new NHibernateLoggerWrapper(_loggingServiceProvider.GetLogger(type, _filter, LogEventSendMode.Automatic, _renderingOptions));
        }
    }
}