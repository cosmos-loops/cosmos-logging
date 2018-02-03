using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.Sinks.MicrosoftExtensions.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.Sinks.MicrosoftExtensions {
    public class MicrosoftLoggingServiceProvider : ILoggingServiceProvider {
        private readonly IServiceProvider _provider;
        private readonly IEnumerable<ILogPayloadClientProvider> _logPayloadClientProviders;
        private readonly LoggingConfiguration _loggingConfiguration;

        public MicrosoftLoggingServiceProvider(IServiceProvider provider, LoggingConfiguration loggingConfiguration) {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _logPayloadClientProviders = _provider.GetServices<ILogPayloadClientProvider>() ?? Enumerable.Empty<ILogPayloadClientProvider>();
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        private ILogger GetLoggerCore(Type sourceType, string categoryName, LogEventLevel? level, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null) {
            var loggerStateNamespace = sourceType == null ? categoryName : TypeNameHelper.GetTypeDisplayName(sourceType);
            var minLevel = level ?? _loggingConfiguration.GetMinimumLevel(loggerStateNamespace);
            return new CosmosLoggerProxy(sourceType ?? typeof(object), minLevel, loggerStateNamespace, filter, mode,
                _loggingConfiguration.RenderingOptions.ToCalc(renderingOptions), new LogPayloadSender(_logPayloadClientProviders));
        }

        public ILogger GetLogger(string categoryName,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(null, categoryName, null, null, mode, renderingOptions);
        }

        public ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(null, categoryName, null, filter, mode, renderingOptions);
        }

        public ILogger GetLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(null, categoryName, minLevel, null, mode, renderingOptions);
        }

        public ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(null, categoryName, minLevel, filter, mode, renderingOptions);
        }

        public ILogger GetLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(type, null, null, null, mode, renderingOptions);
        }

        public ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(type, null, null, filter, mode, renderingOptions);
        }

        public ILogger GetLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(type, null, minLevel, null, mode, renderingOptions);
        }

        public ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(type, null, minLevel, filter, mode, renderingOptions);
        }

        public ILogger GetLogger<T>(
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(typeof(T), null, null, null, mode, renderingOptions);
        }

        public ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(typeof(T), null, null, filter, mode, renderingOptions);
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(typeof(T), null, minLevel, null, mode, renderingOptions);
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            return GetLoggerCore(typeof(T), null, minLevel, filter, mode, renderingOptions);
        }
    }
}