using System;
using System.Linq;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public abstract class LoggerBase : ILogger {
        private readonly ILogPayloadSender _logPayloadSender;

        protected LoggerBase(LogEventLevel minimumLevel, string loggerName, LogEventSendMode sendMode, ILogPayloadSender logPayloadSender) {
            Name = loggerName;
            MinimumLevel = minimumLevel;
            SendMode = sendMode;
            _logPayloadSender = logPayloadSender ?? throw new ArgumentNullException(nameof(logPayloadSender));

            AutomaticPayload = new LogPayload(Enumerable.Empty<LogEvent>());
            ManuallyPayload = new LogPayload(Enumerable.Empty<LogEvent>());
        }

        public string Name { get; }
        public LogEventLevel MinimumLevel { get; }
        public LogEventSendMode SendMode { get; }

        private readonly ILogPayload AutomaticPayload;
        private readonly ILogPayload ManuallyPayload;

        public bool IsEnabled(LogEventLevel level) {
            if (MinimumLevel == LogEventLevel.Off)
                return true;

            if ((int) level >= (int) MinimumLevel)
                return true;

            return false;
        }

        protected virtual bool IsManuallySendMode(LogEvent logEvent) {
            return
                SendMode == LogEventSendMode.Customize && logEvent.SendMode == LogEventSendMode.Manually ||
                SendMode == LogEventSendMode.Manually;
        }


        public void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode) {
            if (!IsEnabled(level)) return;
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;

            var logEvent = new LogEvent(DateTimeOffset.Now, level, messageTemplate, exception, sendMode);

            Dispatch(logEvent);
        }

        public void Write(LogEvent logEvent) {
            if (logEvent == null) return;
            if (!IsEnabled(logEvent.Level)) return;
            Dispatch(logEvent);
        }

        protected virtual void Dispatch(LogEvent logEvent) {
            if (IsManuallySendMode(logEvent)) {
                ManuallyPayload.Add(logEvent);
            }
            else {
                AutomaticPayload.Add(logEvent);
                LogPayloadEmitter.Emit(_logPayloadSender, AutomaticPayload.Export());
            }
        }

        public void SubmitLogger() {
            LogPayloadEmitter.Emit(_logPayloadSender, ManuallyPayload.Export());
        }


        public void Verbose(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, null, messageTemplate, mode);
        }

        public void Verbose(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, null, messageTemplate, mode);
        }

        public void Debug(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, null, messageTemplate, mode);
        }

        public void Debug(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, exception, messageTemplate, mode);
        }

        public void Information(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, null, messageTemplate, mode);
        }

        public void Information(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, exception, messageTemplate, mode);
        }

        public void Warning(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, null, messageTemplate, mode);
        }

        public void Warning(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, exception, messageTemplate, mode);
        }

        public void Error(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, null, messageTemplate, mode);
        }

        public void Error(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, exception, messageTemplate, mode);
        }

        public void Fatal(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, null, messageTemplate, mode);
        }

        public void Fatal(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, mode);
        }
    }
}