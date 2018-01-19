using System;
using System.Linq;
using System.Linq.Expressions;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.ObjectResolving;
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

        public void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode,
            AdditionalOptContext context = null, params object[] messageTemplateParameters) {
            var logEventContext = new LogEventContext {AdditionalOptContext = context, MessageTemplateParameters = messageTemplateParameters};
            Write(level, exception, messageTemplate, sendMode, logEventContext);
        }

        private void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode, LogEventContext context) {
            if (!IsEnabled(level)) return;
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            if (context == null) return;

            var template = GetTemplate(messageTemplate);
            var paramObjs = GetParamObjects(context.MessageTemplateParameters);

            //todo Get MessageTemplateProperty, and add into context;

            var logEvent = new LogEvent(DateTimeOffset.Now, level, template, exception, sendMode, context);

            Dispatch(logEvent);

            object[] GetParamObjects(object[] __paramObjs) {
                if (__paramObjs != null && __paramObjs.GetType() != typeof(object[]))
                    return new object[] {__paramObjs};
                return __paramObjs;
            }

            MessageTemplate GetTemplate(string __messageTemplate) {
                var __parser = new MessageTemplateParser();
                return __parser.Parse(__messageTemplate);
            }
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

        public virtual void LogVerbose(string messageTemplate) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogVerbose<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Verbose, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogVerbose(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogVerbose<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Verbose, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogVerbose<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogVerbose<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogVerbose<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogVerbose(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Verbose, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogDebug(string messageTemplate) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogDebug<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Debug, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogDebug(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogDebug<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogDebug<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }


        public virtual void LogDebug(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogDebug<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Debug, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogDebug<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogDebug<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogDebug<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogDebug(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Debug, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogInformation(string messageTemplate) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogInformation<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Information, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogInformation(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogInformation<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogInformation<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogInformation<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Information, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogInformation<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogInformation<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogInformation<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogInformation(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Information, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogWarning(string messageTemplate) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogWarning<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Warning, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogWarning(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogWarning<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogWarning<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogWarning<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Warning, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogWarning<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogWarning<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogWarning<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogWarning(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Warning, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogError(string messageTemplate) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogError<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Error, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogError(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogError<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogError<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogError(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogError<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Error, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogError<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogError<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogError<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogError(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Error, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogFatal(string messageTemplate) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogFatal<T>(string messageTemplate, T paramObject) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Fatal, null, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogFatal(string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogFatal<T>(string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogFatal<T1, T2>(string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, null, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize);
        }

        public virtual void LogFatal<T>(Exception exception, string messageTemplate, T paramObject) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject);
        }

        public virtual void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize, null, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate, params object[] paramObjects) {
            Write(LogEventLevel.Fatal, exception, messageTemplate, LogEventSendMode.Customize, null, paramObjects);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx);
        }

        public virtual void LogFatal<T>(Exception exception, string messageTemplate, T paramObject, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject);
        }

        public virtual void LogFatal<T1, T2>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2);
        }

        public virtual void LogFatal<T1, T2, T3>(Exception exception, string messageTemplate, T1 paramObject1, T2 paramObject2, T3 paramObject3,
            Action<AdditionalOptContext> optCtxAct) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx, paramObject1, paramObject2, paramObject3);
        }

        public virtual void LogFatal(Exception exception, string messageTemplate, Action<AdditionalOptContext> optCtxAct, params object[] paramObjects) {
            var optCtx = TouchAdditionalOptContext(optCtxAct);
            Write(LogEventLevel.Fatal, exception, messageTemplate, optCtx.SendMode, optCtx, paramObjects);
        }

        private static AdditionalOptContext TouchAdditionalOptContext(Action<AdditionalOptContext> additionalOptContextAct) {
            var context = new AdditionalOptContext();
            additionalOptContextAct?.Invoke(context);
            return context;
        }
    }
}