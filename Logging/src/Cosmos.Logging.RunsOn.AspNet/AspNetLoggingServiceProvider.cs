using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.RunsOn.AspNet {
    public class AspNetLoggingServiceProvider : ILoggingServiceProvider {

        public AspNetLoggingServiceProvider() { }

        public ILogger GetLogger(string categoryName, LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
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