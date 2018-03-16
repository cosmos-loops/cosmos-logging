using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates.PresetTemplates;

namespace Cosmos.Logging.Extensions.EntityFramework.Core {
    internal class SimpleLogger {
        private readonly ILogger _logger;
        private readonly Func<string, object> _simgleLoggingAct;

        public SimpleLogger(ILogger logger, Func<string, object> simgleLoggingAct = null) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _simgleLoggingAct = simgleLoggingAct;
        }

        public void WriteLog(string sqlText, string suffixEventName, [CallerMemberName] string memberName = null) {
            var userInfo = _simgleLoggingAct?.Invoke(sqlText) ?? string.Empty;
            var eventId = new LogEventId($"{EventIdKeys.SqlExposure}_{suffixEventName}");
            var loggingObj = new {
                OrmName = Constants.SinkKey,
                Sql = sqlText,
                UserInfo = userInfo
            };
            _logger.LogDebug(eventId, OrmTemplateStandard.SimpleSqlLog, loggingObj, memberName);
        }
    }
}