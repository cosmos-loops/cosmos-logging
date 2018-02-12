using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Future {
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    // ReSharper disable once InconsistentNaming
    public static class FUTURE {
        public static IFutureLogger GetFutureLogger(string categoryName, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(categoryName, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(string categoryName, Func<string, LogEventLevel, bool> filter, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(categoryName, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(categoryName, minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel,
            Func<string, LogEventLevel, bool> filter, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(categoryName, minLevel, filter, LogEventSendMode.Automatic, renderingOptions)
                .ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(type, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, Func<string, LogEventLevel, bool> filter, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(type, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(type, minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger(type, minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger<T>(LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(Func<string, LogEventLevel, bool> filter, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger<T>(filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger<T>(minLevel, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter, RendingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticServiceResolver.Instance.GetLogger<T>(minLevel, filter, LogEventSendMode.Automatic, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }
    }
}