using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public partial interface ILoggingServiceProvider {
        ILogger GetLogger(string categoryName,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger(Type type, LogEventLevel minLevel,Func<string, LogEventLevel, bool> filter, 
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);

        ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RendingConfiguration renderingOptions = null);
    }
}