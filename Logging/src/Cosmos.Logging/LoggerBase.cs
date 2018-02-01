using System;
using System.Linq;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters.Internals;

namespace Cosmos.Logging {
    public abstract partial class LoggerBase : ILogger {
        private readonly ILogPayloadSender _logPayloadSender;
        private readonly MessageParameterProcessor _messageParameterProcessor;
        private readonly Func<string, LogEventLevel, bool> _filter;
        private static readonly Func<string, LogEventLevel, bool> TrueFilter = (s, l) => true;

        protected LoggerBase(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode,
            ILogPayloadSender logPayloadSender) {
            StateNamespace = loggerStateNamespace;
            TargetType = sourceType ?? typeof(object);
            MinimumLevel = minimumLevel;
            SendMode = sendMode;
            _filter = filter ?? TrueFilter;
            _logPayloadSender = logPayloadSender ?? throw new ArgumentNullException(nameof(logPayloadSender));
            _messageParameterProcessor = MessageParameterProcessorCache.Get();

            AutomaticPayload = new LogPayload(sourceType, loggerStateNamespace, Enumerable.Empty<LogEvent>());
            ManuallyPayload = new LogPayload(sourceType, loggerStateNamespace, Enumerable.Empty<LogEvent>());
        }

        public string StateNamespace { get; }
        public Type TargetType { get; }
        public LogEventLevel MinimumLevel { get; }
        public LogEventSendMode SendMode { get; }

        private readonly ILogPayload AutomaticPayload;
        private readonly ILogPayload ManuallyPayload;

        public bool IsEnabled(LogEventLevel level) {
            return _filter(StateNamespace, level) && PreliminaryEventPercolator.Percolate(level, this);
        }

        protected virtual bool IsManuallySendMode(LogEvent logEvent) {
            return
                SendMode == LogEventSendMode.Customize && logEvent.SendMode == LogEventSendMode.Manually ||
                SendMode == LogEventSendMode.Manually;
        }

        public void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode,
            AdditionalOptContext context = null, params object[] messageTemplateParameters) {
            if (!IsEnabled(level)) return;
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            var task = InsertLogEventIntoAsyncQueue(level, exception, messageTemplate, sendMode, context, messageTemplateParameters);
            task.ContinueWith(t => DispatchFromAsyncQueue());
            task.Start();
        }

        public void Write(LogEvent logEvent) {
            if (logEvent == null || !IsEnabled(logEvent.Level)) return;
            InsertLogEventIntoAsyncQueue(logEvent);
        }

        protected virtual void Dispatch(LogEvent logEvent) {
            if (IsManuallySendMode(logEvent)) {
                ManuallyPayload.Add(logEvent);
            } else {
                AutomaticPayload.Add(logEvent);
                AutomaticlySubmitLoggerByPipleline();
            }
        }

        public IDisposable BeginScope<TState>(TState state) {
            if (state == null) throw new ArgumentNullException(nameof(state));
            return LoggingScope.Push(StateNamespace, state);
        }

        public void SubmitLogger() {
            LaunchSubmitCommand();
        }

        private static AdditionalOptContext TouchAdditionalOptContext(Action<AdditionalOptContext> additionalOptContextAct) {
            var context = new AdditionalOptContext();
            additionalOptContextAct?.Invoke(context);
            return context;
        }
    }
}