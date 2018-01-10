using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public class NullLogger : ILogger {
        private readonly static NullLogger NullLoggerCache;

        static NullLogger() {
            NullLoggerCache = new NullLogger();
        }

        public static NullLogger Instance => NullLoggerCache;

        public string Name { get; }
        public LogEventLevel MinimumLevel { get; }
        public LogEventSendMode SendMode { get; }

        public bool IsEnabled(LogEventLevel level) => false;

        public void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode, AdditionalOptContext context = null) { }

        public void Write(LogEvent logEvent) { }

        public void SubmitLogger() { }

        public void Verbose(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Verbose(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Verbose(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Verbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Debug(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Debug(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Debug(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Debug(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Information(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Information(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Information(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Information(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Warning(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Warning(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Warning(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Warning(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Error(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Error(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Error(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Error(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Fatal(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Fatal(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Fatal(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void Fatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }
    }
}