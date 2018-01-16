using System;
using System.Linq;
using System.Linq.Expressions;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

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

            var parser = new MessageTemplateParser(messageTemplate);

            var template = parser.Parse();

            var logEventContext = new LogEventContext {AdditionalOptContext = context};

            var logEvent = new LogEvent(DateTimeOffset.Now, level, template, exception, sendMode, logEventContext);

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

        public virtual void LogVerbose(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, null, messageTemplate, mode);
        }

        public virtual void LogVerbose(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, mode);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogDebug(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, null, messageTemplate, mode);
        }

        public virtual void LogDebug(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogDebug(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, exception, messageTemplate, mode);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Debug, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogInformation(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, null, messageTemplate, mode);
        }

        public virtual void LogInformation(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogInformation(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, exception, messageTemplate, mode);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Information, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogWarning(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, null, messageTemplate, mode);
        }

        public virtual void LogWarning(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogWarning(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, exception, messageTemplate, mode);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Warning, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogError(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, null, messageTemplate, mode);
        }

        public virtual void LogError(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogError(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, exception, messageTemplate, mode);
        }

        public virtual void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Error, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogFatal(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, null, messageTemplate, mode);
        }

        public virtual void LogFatal(string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, null, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }

        public virtual void LogFatal(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, mode);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> additionalOptContextAct,
            LogEventSendMode mode = LogEventSendMode.Customize) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, mode, TouchAdditionalOptContext(additionalOptContextAct));
        }
    }
}