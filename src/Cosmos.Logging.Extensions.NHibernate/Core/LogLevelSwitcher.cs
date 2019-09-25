using Cosmos.Logging.Events;
using NHibernate;

namespace Cosmos.Logging.Extensions.NHibernate.Core
{
    internal static class LogLevelSwitcher
    {
        public static NHibernateLogLevel Switch(LogEventLevel level)
        {
            switch (level)
            {
                case LogEventLevel.Verbose: return NHibernateLogLevel.Trace;
                case LogEventLevel.Debug: return NHibernateLogLevel.Debug;
                case LogEventLevel.Information: return NHibernateLogLevel.Info;
                case LogEventLevel.Warning: return NHibernateLogLevel.Warn;
                case LogEventLevel.Error: return NHibernateLogLevel.Error;
                case LogEventLevel.Fatal: return NHibernateLogLevel.Fatal;
                case LogEventLevel.Off: return NHibernateLogLevel.None;
                default: return NHibernateLogLevel.None;
            }
        }

        public static LogEventLevel Switch(NHibernateLogLevel level)
        {
            switch (level)
            {
                case NHibernateLogLevel.Trace: return LogEventLevel.Verbose;
                case NHibernateLogLevel.Debug: return LogEventLevel.Debug;
                case NHibernateLogLevel.Info: return LogEventLevel.Information;
                case NHibernateLogLevel.Warn: return LogEventLevel.Warning;
                case NHibernateLogLevel.Error: return LogEventLevel.Error;
                case NHibernateLogLevel.Fatal: return LogEventLevel.Fatal;
                case NHibernateLogLevel.None: return LogEventLevel.Off;
                default: return LogEventLevel.Off;
            }
        }
    }
}