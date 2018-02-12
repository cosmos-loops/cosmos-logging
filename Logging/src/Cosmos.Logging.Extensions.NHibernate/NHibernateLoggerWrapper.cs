using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.NHibernate.Core;

namespace Cosmos.Logging.Extensions.NHibernate {
    public class NHibernateLoggerWrapper : global::NHibernate.IInternalLogger {
        private readonly ILogger _logger;

        public NHibernateLoggerWrapper(ILogger logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private static string ConvertToString(object message) {
            if (message == null) return string.Empty;
            if (message is string message0) return message0;
            return message.ToString();
        }

        public void Error(object message) {
            _logger.LogError(new LogEventId(EventIdKeys.Error), ConvertToString(message));
        }

        public void Error(object message, Exception exception) {
            _logger.LogError(new LogEventId(EventIdKeys.Error), exception, ConvertToString(message));
        }

        public void ErrorFormat(string format, params object[] args) {
            _logger.LogError(new LogEventId(EventIdKeys.Error), format, args);
        }

        public void Fatal(object message) {
            _logger.LogFatal(new LogEventId(EventIdKeys.Error), ConvertToString(message));
        }

        public void Fatal(object message, Exception exception) {
            _logger.LogFatal(new LogEventId(EventIdKeys.Error), exception, ConvertToString(message));
        }

        public void Debug(object message) {
            _logger.LogDebug(new LogEventId(EventIdKeys.Debug), ConvertToString(message));
        }

        public void Debug(object message, Exception exception) {
            _logger.LogDebug(new LogEventId(EventIdKeys.Debug), exception, ConvertToString(message));
        }

        public void DebugFormat(string format, params object[] args) {
            _logger.LogDebug(new LogEventId(EventIdKeys.Debug), format, args);
        }

        public void Info(object message) {
            _logger.LogInformation(new LogEventId(EventIdKeys.Info), ConvertToString(message));
        }

        public void Info(object message, Exception exception) {
            _logger.LogInformation(new LogEventId(EventIdKeys.Info), exception, ConvertToString(message));
        }

        public void InfoFormat(string format, params object[] args) {
            _logger.LogInformation(new LogEventId(EventIdKeys.Info), format, args);
        }

        public void Warn(object message) {
            _logger.LogWarning(new LogEventId(EventIdKeys.Warn), ConvertToString(message));
        }

        public void Warn(object message, Exception exception) {
            _logger.LogWarning(new LogEventId(EventIdKeys.Warn), exception, ConvertToString(message));
        }

        public void WarnFormat(string format, params object[] args) {
            _logger.LogWarning(new LogEventId(EventIdKeys.Warn), format, args);
        }

        public bool IsErrorEnabled => _logger.IsEnabled(LogEventLevel.Error);
        public bool IsFatalEnabled => _logger.IsEnabled(LogEventLevel.Fatal);
        public bool IsDebugEnabled => _logger.IsEnabled(LogEventLevel.Debug);
        public bool IsInfoEnabled => _logger.IsEnabled(LogEventLevel.Information);
        public bool IsWarnEnabled => _logger.IsEnabled(LogEventLevel.Warning);
    }
}