using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.PostgreSql.Core;
using Npgsql.Logging;

namespace Cosmos.Logging.Extensions.PostgreSql {
    /// <summary>
    /// Proxy for PostgreSql Logger
    /// </summary>
    public class PostgreSqlLoggerProxy : NpgsqlLogger {
        /// <summary>
        /// Internal logger
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected readonly ILogger _logger;
        private readonly LogEventLevel _minimumLevel;

        /// <inheritdoc />
        public PostgreSqlLoggerProxy(ILoggingServiceProvider loggingServiceProvider, string categoryName) {
            if (loggingServiceProvider is null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            _logger = loggingServiceProvider.GetLogger(categoryName);
            _minimumLevel = _logger.MinimumLevel;
        }

        /// <inheritdoc />
        public PostgreSqlLoggerProxy(ILogger logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _minimumLevel = _logger.MinimumLevel;
        }

        /// <inheritdoc />
        public override bool IsEnabled(NpgsqlLogLevel level) {
            return _minimumLevel != LogEventLevel.Off &&
                   _logger.IsEnabled(LogLevelSwitcher.Switch(level));
        }

        /// <inheritdoc />
        public override void Log(NpgsqlLogLevel level, int connectorId, string msg, Exception exception = null) {
            _logger.Log(LogLevelSwitcher.Switch(level), exception, msg, ctx => ctx.AddData("ConnectorId", connectorId));
        }
    }
}