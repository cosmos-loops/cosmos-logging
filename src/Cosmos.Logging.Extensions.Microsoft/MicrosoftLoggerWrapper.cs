using System;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.Microsoft.Core;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Extensions.Microsoft {
    public class MicrosoftLoggerWrapper : global::Microsoft.Extensions.Logging.ILogger {
        // ReSharper disable once InconsistentNaming
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
            _logger.Write(eventId.ToEventId(), LogLevelSwitcher.Switch(logLevel), exception, messageTemplate,
                LogEventSendMode.Customize, NullLogCallerInfo.Instance);
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