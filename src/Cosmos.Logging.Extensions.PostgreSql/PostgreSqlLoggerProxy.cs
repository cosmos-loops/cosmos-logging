using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.PostgreSql.Core;
using Npgsql.Logging;

namespace Cosmos.Logging.Extensions.PostgreSql
{
    public class PostgreSqlLoggerProxy : NpgsqlLogger
    {
        // ReSharper disable once InconsistentNaming
        protected readonly ILogger _logger;
        private readonly LogEventLevel _minimumLevel;

        public PostgreSqlLoggerProxy(ILoggingServiceProvider loggingServiceProvider, string categoryName)
        {
            if (loggingServiceProvider == null) throw new ArgumentNullException(nameof(loggingServiceProvider));
            _logger = loggingServiceProvider.GetLogger(categoryName);
            _minimumLevel = _logger.MinimumLevel;
        }

        public PostgreSqlLoggerProxy(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _minimumLevel = _logger.MinimumLevel;
        }

        public override bool IsEnabled(NpgsqlLogLevel level)
        {
            return _minimumLevel != LogEventLevel.Off &&
                   _logger.IsEnabled(LogLevelSwitcher.Switch(level));
        }

        public override void Log(NpgsqlLogLevel level, int connectorId, string msg, Exception exception = null)
        {
            _logger.Log(LogLevelSwitcher.Switch(level), exception, msg, ctx => ctx.AddData("ConnectorId", connectorId));
        }
    }
}