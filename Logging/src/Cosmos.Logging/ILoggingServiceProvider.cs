using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public interface ILoggingServiceProvider {
        ILogger GetLogger(string categoryName, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger(string categoryName, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger(Type type, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger(Type type, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger<T>(LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter, LogEventSendMode mode = LogEventSendMode.Customize);
    }
}