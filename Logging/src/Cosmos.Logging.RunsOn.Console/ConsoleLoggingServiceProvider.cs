using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.Console {
    public class ConsoleLoggingServiceProvider : ILoggingServiceProvider {
        private readonly IServiceProvider _provider;
        private readonly IEnumerable<ILogPayloadClientProvider> _logPayloadClientProviders;
        private readonly LoggingConfiguration _loggingConfiguration;

        public ConsoleLoggingServiceProvider(IServiceProvider provider, LoggingConfiguration loggingConfiguration) {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _logPayloadClientProviders = _provider.GetServices<ILogPayloadClientProvider>() ?? Enumerable.Empty<ILogPayloadClientProvider>();
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        private ILogger GetLoggerCore(Type sourceType, LogEventLevel? level, LogEventSendMode mode = LogEventSendMode.Customize) {
            var loggerStateNamespace = TypeNameHelper.GetTypeDisplayName(sourceType);
            var minLevel = level ?? _loggingConfiguration.GetMinimumLevel(loggerStateNamespace);
            return new ConsoleLogger(sourceType, minLevel, loggerStateNamespace, mode, new LogPayloadSender(_logPayloadClientProviders));
        }

        public ILogger GetLogger(Type type, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, null, mode);
        }

        public ILogger GetLogger(Type type, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, minLevel, mode);
        }

        public ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), null, mode);
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), minLevel, mode);
        }
    }
}