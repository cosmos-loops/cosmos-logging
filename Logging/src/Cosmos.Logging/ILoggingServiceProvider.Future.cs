using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging {
    public partial interface ILoggingServiceProvider {
        IFutureLogger GetFutureLogger(string categoryName,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger(Type type,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger(Type type, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger<T>(
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger<T>(Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            MessageTemplateRenderingOptions renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);
    }
}