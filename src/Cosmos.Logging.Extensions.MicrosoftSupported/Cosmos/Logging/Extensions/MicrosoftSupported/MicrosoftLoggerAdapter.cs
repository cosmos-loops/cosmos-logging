using System;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.MicrosoftSupported.Core;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Extensions.MicrosoftSupported {
    /// <summary>
    /// Microsoft Logger Wrapper
    /// </summary>
    public class MicrosoftLoggerAdapter : global::Microsoft.Extensions.Logging.ILogger {
        /// <summary>
        /// Logger
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected readonly ILogger _logger;

        /// <summary>
        /// Create a new instance of <see cref="MicrosoftLoggerAdapter"/>
        /// </summary>
        /// <param name="loggerServiceProvider"></param>
        /// <param name="categoryName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MicrosoftLoggerAdapter(ILoggingServiceProvider loggerServiceProvider, string categoryName) {
            if (loggerServiceProvider == null) throw new ArgumentNullException(nameof(loggerServiceProvider));
            _logger = loggerServiceProvider.GetLogger(categoryName);
        }

        /// <summary>
        /// Create a new instance of <see cref="MicrosoftLoggerAdapter"/>
        /// </summary>
        /// <param name="logger"></param>
        public MicrosoftLoggerAdapter(ILogger logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));
            var messageTemplate = formatter(state, exception);
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            _logger.Write(eventId.ToTrackInfo(), LogLevelSwitcher.Switch(logLevel), exception, messageTemplate,
                LogEventSendMode.Customize, NullLogCallerInfo.Instance);
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel) {
            return _logger.IsEnabled(LogLevelSwitcher.Switch(logLevel));
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state) {
            return _logger.BeginScope(state);
        }

        internal ILogger ExposeLogger() => _logger;
    }
}