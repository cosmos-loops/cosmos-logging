using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public interface ILoggingServiceProvider {
        ILogger GetLogger(Type type, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger(Type type, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize);
        ILogger GetLogger<T>(LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize);

    }
}