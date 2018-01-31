using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.NHibernate {
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
            _logger.LogError(ConvertToString(message));
        }

        public void Error(object message, Exception exception) {
            _logger.LogError(exception, ConvertToString(message));
        }

        public void ErrorFormat(string format, params object[] args) {
            _logger.LogError(format, args);
        }

        public void Fatal(object message) {
            _logger.LogFatal(ConvertToString(message));
        }

        public void Fatal(object message, Exception exception) {
            _logger.LogFatal(exception, ConvertToString(message));
        }

        public void Debug(object message) {
            _logger.LogDebug(ConvertToString(message));
        }

        public void Debug(object message, Exception exception) {
            _logger.LogDebug(exception, ConvertToString(message));
        }

        public void DebugFormat(string format, params object[] args) {
            _logger.LogDebug(format, args);
        }

        public void Info(object message) {
            _logger.LogInformation(ConvertToString(message));
        }

        public void Info(object message, Exception exception) {
            _logger.LogInformation(exception, ConvertToString(message));
        }

        public void InfoFormat(string format, params object[] args) {
            _logger.LogInformation(format, args);
        }

        public void Warn(object message) {
            _logger.LogWarning(ConvertToString(message));
        }

        public void Warn(object message, Exception exception) {
            _logger.LogWarning(exception, ConvertToString(message));
        }

        public void WarnFormat(string format, params object[] args) {
            _logger.LogWarning(format, args);
        }

        public bool IsErrorEnabled => _logger.IsEnabled(LogEventLevel.Error);
        public bool IsFatalEnabled => _logger.IsEnabled(LogEventLevel.Fatal);
        public bool IsDebugEnabled => _logger.IsEnabled(LogEventLevel.Debug);
        public bool IsInfoEnabled => _logger.IsEnabled(LogEventLevel.Information);
        public bool IsWarnEnabled => _logger.IsEnabled(LogEventLevel.Warning);
    }
}