using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
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

        public ILogger GetLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
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

       public IFutureLogger GetFutureLogger(string categoryName,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger(Type type,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger(Type type, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger<T>(
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger<T>(Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }
    }
}