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

        public void LogVerbose(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogVerbose(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogVerbose(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogDebug(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogDebug(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogDebug(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogInformation(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogInformation(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogInformation(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogWarning(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogWarning(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogWarning(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogError(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogError(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogError(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogFatal(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogFatal(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogFatal(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) { }

        public void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct, LogEventSendMode mode = LogEventSendMode.Customize) { }
    }
}