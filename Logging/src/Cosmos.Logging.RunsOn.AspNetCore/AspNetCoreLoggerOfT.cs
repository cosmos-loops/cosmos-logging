using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.RunsOn.AspNetCore.Core;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    public class AspNetCoreLoggerOfT<T> : Microsoft.Extensions.Logging.ILogger<T> {
        private readonly ILogger _logger;

        public AspNetCoreLoggerOfT(ILoggingServiceProvider provider) {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            _logger = provider.GetLogger<T>();
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