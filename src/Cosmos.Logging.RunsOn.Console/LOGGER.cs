using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
using Cosmos.Logging.RunsOn.Console;
using Cosmos.Logging.RunsOn.Console.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    // ReSharper disable once InconsistentNaming
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public static class LOGGER {
        // ReSharper disable once InconsistentNaming
        internal static bool _initialized = false;

        public static ILogServiceCollection Initialize(string settingPath, FileTypes type) {
            if (string.IsNullOrWhiteSpace(settingPath)) throw new ArgumentNullException(nameof(settingPath));
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());
            ConfigLoadingContext.Load(builder, settingPath, type);
            return Initialize(builder);
        }

        public static ILogServiceCollection Initialize(IConfigurationBuilder builder = null) {
            if (_initialized) throw new InvalidOperationException("You have initialized Cosmos.Logging.");
            IServiceCollection services = new ServiceCollection();
            services.TryAdd(ServiceDescriptor.Singleton<ILoggingServiceProvider, ConsoleLoggingServiceProvider>());
            return SoloDependencyContainer.Initialize(services, builder);
        }

        public static ILogServiceCollection Initialize(IConfigurationRoot root) {
            if (_initialized) throw new InvalidOperationException("You have initialized Cosmos.Logging.");
            IServiceCollection services = new ServiceCollection();
            services.TryAdd(ServiceDescriptor.Singleton<ILoggingServiceProvider, ConsoleLoggingServiceProvider>());
            return SoloDependencyContainer.Initialize(services, root);
        }

        public static IServiceProvider GetScopedServiceResolver() => SoloDependencyContainer.GetScopedServiceResolver();

        private static ILoggingServiceProvider TouchProvider() => SoloDependencyContainer.GetServiceResolver().GetService<ILoggingServiceProvider>();

        public static ILogger GetLogger(string categoryName,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(categoryName, mode, renderingOptions);
        }

        public static ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(categoryName, filter, mode, renderingOptions);
        }

        public static ILogger GetLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(categoryName, minLevel, mode, renderingOptions);
        }

        public static ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(categoryName, minLevel, filter, mode, renderingOptions);
        }

        public static ILogger GetLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, mode, renderingOptions);
        }

        public static ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, filter, mode, renderingOptions);
        }

        public static ILogger GetLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, minLevel, mode, renderingOptions);
        }

        public static ILogger GetLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, minLevel, filter, mode, renderingOptions);
        }

        public static ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(mode, renderingOptions);
        }

        public static ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(filter, mode, renderingOptions);
        }

        public static ILogger GetLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(minLevel, mode, renderingOptions);
        }

        public static ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(minLevel, filter, mode, renderingOptions);
        }

        public static IFutureLogger GetFutureLogger(string categoryName,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, minLevel, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, minLevel, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, minLevel, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, minLevel, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(minLevel, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(minLevel, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }
    }
}