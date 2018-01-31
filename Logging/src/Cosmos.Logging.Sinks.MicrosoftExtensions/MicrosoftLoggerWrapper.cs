using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.MicrosoftExtensions.Core;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Sinks.MicrosoftExtensions {
    public class MicrosoftLoggerWrapper : Microsoft.Extensions.Logging.ILogger {
        protected readonly ILogger _logger;

        public MicrosoftLoggerWrapper(ILoggingServiceProvider loggerServiceProvider, string categoryName) {
            if (loggerServiceProvider == null) throw new ArgumentNullException(nameof(loggerServiceProvider));
            _logger = loggerServiceProvider.GetLogger(categoryName);
        }

        public MicrosoftLoggerWrapper(ILogger logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));
            var messageTemplate = formatter(state, exception);
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            _logger.Write(LogLevelSwitcher.Switch(logLevel), exception, messageTemplate, LogEventSendMode.Customize);
        }

        public bool IsEnabled(LogLevel logLevel) {
            return _logger.IsEnabled(LogLevelSwitcher.Switch(logLevel));
        }

        public IDisposable BeginScope<TState>(TState state) {
            return _logger.BeginScope(state);
        }

        internal ILogger ExposeLogger() => _logger;
    }
}