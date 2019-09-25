using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using NHibernate;

namespace Cosmos.Logging.Extensions.NHibernate
{
    public class NHibernateLoggerWrapperFactory : INHibernateLoggerFactory
    {
        private readonly ILoggingServiceProvider _loggingServiceProvider;
        private readonly RendingConfiguration _renderingOptions;
        private readonly Func<string, LogEventLevel, bool> _filter;
        private static readonly Func<string, LogEventLevel, bool> TrueFilter = (s, l) => true;

        public NHibernateLoggerWrapperFactory(ILoggingServiceProvider loggingServiceProvider, RendingConfiguration renderingOptions)
            : this(loggingServiceProvider, renderingOptions, TrueFilter) { }

        public NHibernateLoggerWrapperFactory(ILoggingServiceProvider loggingServiceProvider, RendingConfiguration renderingOptions, Func<string, LogEventLevel, bool> filter)
        {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _renderingOptions = renderingOptions ?? new RendingConfiguration();
            _filter = filter ?? TrueFilter;
        }

        public INHibernateLogger LoggerFor(string keyName)
        {
            return new NHibernateLoggerWrapper(_loggingServiceProvider.GetLogger(keyName, _filter, LogEventSendMode.Automatic, _renderingOptions));
        }

        public INHibernateLogger LoggerFor(Type type)
        {
            return new NHibernateLoggerWrapper(_loggingServiceProvider.GetLogger(type, _filter, LogEventSendMode.Automatic, _renderingOptions));
        }
    }
}