using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Extensions.MicrosoftSupported.Core;
using Cosmos.Logging.Future;
using Cosmos.Logging.Simple;
using Microsoft.Extensions.DependencyInjection;

namespace Cosmos.Logging.Extensions.MicrosoftSupported {
    /// <summary>
    /// Microsoft Logging Service Provider
    /// </summary>
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public class MicrosoftLoggingServiceProvider : ILoggingServiceProvider {
        /// <summary>
        /// Service provider
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected readonly IServiceProvider _provider;
        
        /// <summary>
        /// Log payload client providers
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected readonly IEnumerable<ILogPayloadClientProvider> _logPayloadClientProviders;
        
        /// <summary>
        /// Logging configuration
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected readonly LoggingConfiguration _loggingConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="MicrosoftLoggingServiceProvider"/>.
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="loggingConfiguration"></param>
        public MicrosoftLoggingServiceProvider(IServiceProvider provider, LoggingConfiguration loggingConfiguration) {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
            _logPayloadClientProviders = _provider.GetServices<ILogPayloadClientProvider>() ?? Enumerable.Empty<ILogPayloadClientProvider>();
            _loggingConfiguration = loggingConfiguration ?? throw new ArgumentNullException(nameof(loggingConfiguration));
        }

        /// <summary>
        /// Get logger core
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="categoryName"></param>
        /// <param name="level"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        protected virtual ILogger GetLoggerCore(Type sourceType, string categoryName, LogEventLevel? level, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize, RenderingConfiguration renderingOptions = null) {
            var loggerStateNamespace = sourceType == null ? categoryName : TypeNameHelper.GetTypeDisplayName(sourceType);
            var minLevel = level ?? _loggingConfiguration.GetMinimumLevel(loggerStateNamespace);
            return new LoggerProxy(sourceType ?? typeof(object), minLevel, loggerStateNamespace, filter, mode,
                _loggingConfiguration.Rendering.ToCalc(renderingOptions), new LogPayloadSender(_logPayloadClientProviders));
        }

        /// <inheritdoc />
        public ILogger GetLogger(string categoryName,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(null, categoryName, null, null, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(null, categoryName, null, filter, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(null, categoryName, minLevel, null, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(null, categoryName, minLevel, filter, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(type, null, null, null, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(type, null, null, filter, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(type, null, minLevel, null, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(type, null, minLevel, filter, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger<T>(
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(typeof(T), null, null, null, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(typeof(T), null, null, filter, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(typeof(T), null, minLevel, null, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            return GetLoggerCore(typeof(T), null, minLevel, filter, mode, renderingOptions);
        }

        /// <inheritdoc />
        public ISimpleLogger GetSimpleLogger(string categoryName) {
            return GetLogger(categoryName, LogEventSendMode.Automatic).ToSimple();
        }

        /// <inheritdoc />
        public ISimpleLogger GetSimpleLogger<T>() {
            return GetLogger<T>(LogEventSendMode.Automatic).ToSimple();
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger(string categoryName,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger(Type type,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger(Type type, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger<T>(
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger<T>(Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <inheritdoc />
        public IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }
    }
}