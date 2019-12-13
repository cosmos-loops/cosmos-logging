using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;

namespace Cosmos.Logging {
    /// <summary>
    /// Logger
    /// </summary>
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    // ReSharper disable once InconsistentNaming
    public static class LOGGER {
        private static ILoggingServiceProvider TouchProvider() => StaticServiceResolver.Instance;

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        public static ILogger GetLogger(string categoryName,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(categoryName, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        public static ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(categoryName, filter, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        public static ILogger GetLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(categoryName, minLevel, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        public static ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(categoryName, minLevel, filter, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        public static ILogger GetLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        public static ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, filter, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        public static ILogger GetLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, minLevel, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        public static ILogger GetLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger(type, minLevel, filter, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(filter, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ILogger GetLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(minLevel, mode, renderingOptions);
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null) {
            var provider = TouchProvider();
            return provider == null ? NullLogger.Instance : provider.GetLogger<T>(minLevel, filter, mode, renderingOptions);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(string categoryName,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, minLevel, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(categoryName, minLevel, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, minLevel, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger(type, minLevel, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0) {
            return GetLogger<T>(minLevel, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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