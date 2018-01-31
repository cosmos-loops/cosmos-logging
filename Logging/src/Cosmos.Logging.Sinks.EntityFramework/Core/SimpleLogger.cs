using System;

namespace Cosmos.Logging.Sinks.EntityFramework.Core {
    internal class SimpleLogger {
        private readonly ILogger _logger;
        private readonly Func<string, object> _simgleLoggingAct;

        public SimpleLogger(ILogger logger, Func<string, object> simgleLoggingAct = null) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _simgleLoggingAct = simgleLoggingAct;
        }

        public void WriteLog(string sqlText) {
            var userInfo = _simgleLoggingAct?.Invoke(sqlText) ?? string.Empty;

            var loggingObj = new {
                OrmName = Constants.SinkKey,
                Sql = sqlText,
                UserInfo = userInfo
            };
            _logger.LogDebug(TemplateStandards.OrmTemplateStandard.SimpleSqlLog, loggingObj);
        }
    }
}