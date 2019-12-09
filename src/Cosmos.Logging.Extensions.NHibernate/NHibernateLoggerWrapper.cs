using System;
using Cosmos.Logging.Extensions.NHibernate.Core;
using NHibernate;

namespace Cosmos.Logging.Extensions.NHibernate {
    public class NHibernateLoggerWrapper : INHibernateLogger {
        private readonly ILogger _logger;

        public NHibernateLoggerWrapper(ILogger logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Write log
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="state"></param>
        /// <param name="exception"></param>
        public void Log(NHibernateLogLevel logLevel, NHibernateLogValues state, Exception exception) {
            _logger.Log(LogLevelSwitcher.Switch(logLevel), exception, state.ToString());
        }

        /// <summary>
        /// Checks if the given <paramref name="logLevel"/> is enabled.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(NHibernateLogLevel logLevel) => _logger.IsEnabled(LogLevelSwitcher.Switch(logLevel));
    }
}