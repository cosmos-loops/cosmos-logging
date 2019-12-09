using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Future {
    /// <summary>
    /// Future Cosmos Logging Entry
    /// </summary>
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    // ReSharper disable once InconsistentNaming
    public static class FUTURE {
        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(string categoryName, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(categoryName, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(string categoryName, Func<string, LogEventLevel, bool> filter, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(categoryName, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(categoryName, minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel,
            Func<string, LogEventLevel, bool> filter, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(categoryName, minLevel, filter, LogEventSendMode.Automatic, renderingOptions)
                                        .ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(Type type, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(type, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(Type type, Func<string, LogEventLevel, bool> filter, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(type, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(type, minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(type, minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger<T>(RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger<T>(LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger<T>(Func<string, LogEventLevel, bool> filter, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger<T>(filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger<T>(minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter, RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger<T>(minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }
    }
}