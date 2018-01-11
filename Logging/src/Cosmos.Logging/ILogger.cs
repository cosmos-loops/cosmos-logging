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
        void Verbose(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Verbose(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Verbose(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Verbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Debug(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Debug(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Debug(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Debug(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Information(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Information(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Information(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Information(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Warning(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Warning(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Warning(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Warning(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Error(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Error(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Error(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Error(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Fatal(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Fatal(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
        void Fatal(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize);
        void Fatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize);
    }
}