using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.RunsOn.Console.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cosmos.Logging.RunsOn.Console {
    public class ConsoleLoggingServiceProvider : ILoggingServiceProvider {
        private readonly IServiceProvider _provider;
        private readonly IEnumerable<ILogPayloadClientProvider> _logPayloadClientProviders;
        private readonly ILoggingOptions _loggingOptions;
        private readonly LoggingConfiguration _loggingConfiguration;
        private const string DEFAULT_LOGGER_NAME_PREFIX = "logger:CosmosLoops:roConsole";

        public ConsoleLoggingServiceProvider(IServiceProvider provider, IOptions<LoggingOptions> settings, LoggingConfiguration loggingConfiguration) {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _logPayloadClientProviders = _provider.GetServices<ILogPayloadClientProvider>() ?? Enumerable.Empty<ILogPayloadClientProvider>();
            _loggingOptions = settings?.Value ?? LoggingOptions.Defaults;
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        protected virtual LogEventLevel MinimumLevel => _loggingOptions.GetMinimumLevel();

        protected virtual string DefaultLoggerName => $"{DEFAULT_LOGGER_NAME_PREFIX}_{DateTime.Now:yyyyMMdd}";

        private ILogger GetLoggerCore(Type sourceType, string name, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            return new ConsoleLogger(sourceType, level, name, mode, _loggingConfiguration, new LogPayloadSender(_logPayloadClientProviders));
        }

        public ILogger GetLogger(LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(object), DefaultLoggerName, MinimumLevel, mode);
        }

        public ILogger GetLogger(string name, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(object), name, MinimumLevel, mode);
        }

        public ILogger GetLogger(LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(object), DefaultLoggerName, minLevel, mode);
        }

        public ILogger GetLogger(string name, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(object), name, minLevel, mode);
        }

        public ILogger GetLogger(Type type, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, TypeNameHelper.GetTypeDisplayName(type), MinimumLevel, mode);
        }

        public ILogger GetLogger(Type type, string name, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, name, MinimumLevel, mode);
        }

        public ILogger GetLogger(Type type, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, TypeNameHelper.GetTypeDisplayName(type), minLevel, mode);
        }

        public ILogger GetLogger(Type type, string name, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, name, level, mode);
        }

        public ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), TypeNameHelper.GetTypeDisplayName(typeof(T)), MinimumLevel, mode);
        }

        public ILogger GetLogger<T>(string name, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), name, MinimumLevel, mode);
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), TypeNameHelper.GetTypeDisplayName(typeof(T)), minLevel, mode);
        }

        public ILogger GetLogger<T>(string name, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), name, minLevel, mode);
        }
    }
}