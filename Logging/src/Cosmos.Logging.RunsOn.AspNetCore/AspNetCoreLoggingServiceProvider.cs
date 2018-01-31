using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    public class AspNetCoreLoggingServiceProvider : ILoggingServiceProvider {
        private readonly IServiceProvider _provider;
        private readonly IEnumerable<ILogPayloadClientProvider> _logPayloadClientProviders;
        private readonly LoggingConfiguration _loggingConfiguration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetCoreLoggingServiceProvider(IServiceProvider provider, LoggingConfiguration loggingConfiguration,
            IHttpContextAccessor httpContextAccessor) {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _logPayloadClientProviders = _provider.GetServices<ILogPayloadClientProvider>() ?? Enumerable.Empty<ILogPayloadClientProvider>();
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
            _httpContextAccessor = httpContextAccessor;
        }

        private ILogger GetLoggerCore(Type sourceType, string categoryName, LogEventLevel? level, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            var loggerStateNamespace = sourceType == null ? categoryName : TypeNameHelper.GetTypeDisplayName(sourceType);
            var minLevel = level ?? _loggingConfiguration.GetMinimumLevel(loggerStateNamespace);
            return new AspNetCoreLogger(sourceType ?? typeof(object), minLevel, loggerStateNamespace, filter,
                mode, new LogPayloadSender(_logPayloadClientProviders), _httpContextAccessor);
        }

        public ILogger GetLogger(string categoryName, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(null, categoryName, null, null, mode);
        }

        public ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(null, categoryName, null, filter, mode);
        }

        public ILogger GetLogger(string categoryName, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(null, categoryName, minLevel, null, mode);
        }

        public ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(null, categoryName, minLevel, filter, mode);
        }

        public ILogger GetLogger(Type type, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, null, null, null, mode);
        }

        public ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, null, null, filter, mode);
        }

        public ILogger GetLogger(Type type, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, null, minLevel, null, mode);
        }

        public ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(type, null, minLevel, filter, mode);
        }

        public ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), null, null, null, mode);
        }

        public ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), null, null, filter, mode);
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), null, minLevel, null, mode);
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize) {
            return GetLoggerCore(typeof(T), null, minLevel, filter, mode);
        }
    }
}