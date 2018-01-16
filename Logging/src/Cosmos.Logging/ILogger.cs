using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public interface ILogger {
        string Name { get; }
        LogEventLevel MinimumLevel { get; }
        LogEventSendMode SendMode { get; }
        bool IsEnabled(LogEventLevel level);
        void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode, AdditionalOptContext context = null);
        void Write(LogEvent logEvent);
        void SubmitLogger();
        void LogVerbose(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogVerbose(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogVerbose(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogDebug(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogDebug(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogDebug(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogInformation(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogInformation(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogInformation(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogWarning(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogWarning(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogWarning(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogError(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogError(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogError(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogFatal(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogFatal(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogFatal(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
    }
}