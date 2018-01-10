using System;
using System.Linq;
using System.Linq.Expressions;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public abstract class LoggerBase : ILogger {
        private readonly ILogPayloadSender _logPayloadSender;

        protected LoggerBase(Type sourceType, LogEventLevel minimumLevel, string loggerName, LogEventSendMode sendMode, ILogPayloadSender logPayloadSender) {
            Name = loggerName;
            TargetType = sourceType ?? typeof(object);
            MinimumLevel = minimumLevel;
            SendMode = sendMode;
            _logPayloadSender = logPayloadSender ?? throw new ArgumentNullException(nameof(logPayloadSender));

            AutomaticPayload = new LogPayload(sourceType, loggerName, Enumerable.Empty<LogEvent>());
            ManuallyPayload = new LogPayload(sourceType, loggerName, Enumerable.Empty<LogEvent>());
        }

        public string Name { get; }
        public Type TargetType { get; }
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


        public void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode, AdditionalOptContext context = null) {
            if (!IsEnabled(level)) return;
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;

            var logEvent = new LogEvent(DateTimeOffset.Now, level, messageTemplate, exception, sendMode, context);

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
            } else {
                AutomaticPayload.Add(logEvent);
                LogPayloadEmitter.Emit(_logPayloadSender, AutomaticPayload.Export());
            }
        }

        public void SubmitLogger() {
            LogPayloadEmitter.Emit(_logPayloadSender, ManuallyPayload.Export());
        }

        private static AdditionalOptContext TouchAdditionalOptContext(Action<AdditionalOptContext> additionalOptContextAct) {
            var context = new AdditionalOptContext();
            additionalOptContextAct?.Invoke(context);
            return context;
        }

        public virtual void Verbose(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, null, messageTemplate, mode);
        }

        public virtual void Verbose(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Verbose(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, mode);
        }

        public virtual void Verbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Debug(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, null, messageTemplate, mode);
        }

        public virtual void Debug(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Debug(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, exception, messageTemplate, mode);
        }

        public virtual void Debug(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Information(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, null, messageTemplate, mode);
        }

        public virtual void Information(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Information(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, exception, messageTemplate, mode);
        }

        public virtual void Information(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Warning(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, null, messageTemplate, mode);
        }

        public virtual void Warning(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Warning(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, exception, messageTemplate, mode);
        }

        public virtual void Warning(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Error(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, null, messageTemplate, mode);
        }

        public virtual void Error(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Error(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, exception, messageTemplate, mode);
        }

        public virtual void Error(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Fatal(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, null, messageTemplate, mode);
        }

        public virtual void Fatal(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void Fatal(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, mode);
        }

        public virtual void Fatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }
    }
}