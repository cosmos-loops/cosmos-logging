using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Future {
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public static class FUTURE {
        public static IFutureLogger GetFutureLogger(string categoryName,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger(categoryName, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger(categoryName, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger(categoryName, minLevel, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger(categoryName, minLevel, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger(type, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger(type, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger(type, minLevel, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger(type, minLevel, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger<T>(mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger<T>(filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger<T>(minLevel, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }

        public static IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize, MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            return StaticInstanceOfLoggingServiceProvider.Instance.GetLogger<T>(minLevel, filter, mode, renderingOptions).ToFuture(memberName, filePath, lineNumber);
        }
    }
}