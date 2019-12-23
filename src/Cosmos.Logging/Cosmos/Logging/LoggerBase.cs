using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Cosmos.Disposables;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Core.ObjectResolving;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters.Internals;
using Cosmos.Logging.Future;
using Cosmos.Logging.Simple;

namespace Cosmos.Logging {
    /// <summary>
    /// Logger base
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract partial class LoggerBase : ILogger, IDisposable {
        private readonly ILogPayloadSender _logPayloadSender;
        private readonly MessageParameterProcessor _messageParameterProcessor;
        private readonly Func<string, LogEventLevel, bool> _filter;
        private static readonly Func<string, LogEventLevel, bool> TrueFilter = (s, l) => true;
        private readonly RenderingConfiguration _upstreamRenderingOptions;
        private long CurrentManuallyTransId { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="LoggerBase"/>
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="minimumLevel"></param>
        /// <param name="loggerStateNamespace"></param>
        /// <param name="filter"></param>
        /// <param name="sendMode"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="logPayloadSender"></param>
        protected LoggerBase(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            LogEventSendMode sendMode,
            RenderingConfiguration renderingOptions,
            ILogPayloadSender logPayloadSender) {
            StateNamespace = loggerStateNamespace;
            TargetType = sourceType ?? typeof(object);
            MinimumLevel = minimumLevel;
            SendMode = sendMode;
            _filter = filter ?? TrueFilter;
            _logPayloadSender = logPayloadSender ?? throw new ArgumentNullException(nameof(logPayloadSender));
            _messageParameterProcessor = MessageParameterProcessorCache.Get();
            _upstreamRenderingOptions = renderingOptions ?? new RenderingConfiguration();

            AutomaticPayload = new LogPayload(sourceType, loggerStateNamespace, Enumerable.Empty<LogEvent>());
            ManuallyPayload = new LogPayload(sourceType, loggerStateNamespace, Enumerable.Empty<LogEvent>());
            CurrentManuallyTransId = DateTime.Now.Ticks;
            _manuallyLogEventDescriptors.TryAdd(CurrentManuallyTransId, new List<ManuallyLogEventDescriptor>());
        }

        /// <summary>
        /// State namespace
        /// </summary>
        public string StateNamespace { get; }

        /// <summary>
        /// Target type
        /// </summary>
        public Type TargetType { get; }

        /// <summary>
        /// Minimum log event level
        /// </summary>
        public LogEventLevel MinimumLevel { get; }

        /// <summary>
        /// Send mode
        /// </summary>
        public LogEventSendMode SendMode { get; }

        private readonly ILogPayload AutomaticPayload;
        private readonly ILogPayload ManuallyPayload;

        /// <summary>
        /// Is enabled
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnabled(LogEventLevel level) {
            return _filter(StateNamespace, level) && PreliminaryEventPercolator.Percolate(level, this);
        }

        /// <summary>
        /// Is manually send mode
        /// </summary>
        /// <param name="modeInEvent"></param>
        /// <returns></returns>
        protected virtual bool IsManuallySendMode(LogEventSendMode modeInEvent) =>
            modeInEvent != LogEventSendMode.Automatic &&
            (SendMode == LogEventSendMode.Customize && modeInEvent == LogEventSendMode.Manually || SendMode == LogEventSendMode.Manually);

        /// <summary>
        /// Is manually send mode
        /// </summary>
        /// <param name="logEvent"></param>
        /// <returns></returns>
        protected bool IsManuallySendMode(LogEvent logEvent) => IsManuallySendMode(logEvent?.SendMode ?? LogEventSendMode.Customize);

        /// <summary>
        /// To expose log event level filter for implementation of LoggerBase
        /// </summary>
        protected Func<string, LogEventLevel, bool> ExposeFilter() => _filter;

        /// <summary>
        /// To expose log payload sender for implementation of LoggerBase
        /// </summary>
        protected ILogPayloadSender ExposeLogPayloadSender() => _logPayloadSender;

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="sendMode"></param>
        /// <param name="callerInfo"></param>
        /// <param name="context"></param>
        /// <param name="messageTemplateParameters"></param>
        public void Write(LogTrack? logTrack, LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode, ILogCallerInfo callerInfo,
            LogEventContext context = null, params object[] messageTemplateParameters) {
            if (!IsEnabled(level)) return;
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            var cleanMessageTemplateParameters = ArgsHelper.CleanUp(messageTemplateParameters);
            var logEventId = TouchLogEventId(logTrack, StateNamespace);
            if (IsManuallySendMode(sendMode)) {
                ParseAndInsertLogEvenDescriptorManually(logEventId, level, exception, messageTemplate, callerInfo, context, cleanMessageTemplateParameters);
            } else {
                ParseAndInsertLogEventIntoQueueAutomatically(logEventId, level, exception, messageTemplate, callerInfo, context, cleanMessageTemplateParameters);
            }
        }

        /// <inheritdoc />
        public void Write(LogEvent logEvent) {
            if (logEvent == null || !IsEnabled(logEvent.Level)) return;
            Dispatch(logEvent);
        }

        /// <inheritdoc />
        public void Write(FutureLogEventDescriptor descriptor) {
            if (descriptor == null) throw new ArgumentNullException(nameof(descriptor));
            if (!IsEnabled(descriptor.Level)) return;
            if (string.IsNullOrWhiteSpace(descriptor.MessageTemplate)) return;
            Write(
                descriptor.GetLogTrack(),
                descriptor.Level,
                descriptor.Exception,
                descriptor.MessageTemplate,
                LogEventSendMode.Automatic,
                descriptor.CallerInfo,
                descriptor.Context,
                descriptor.Context.Parameters);
        }

        /// <summary>
        /// Dispatch
        /// </summary>
        /// <param name="logEvent"></param>
        protected virtual void Dispatch(LogEvent logEvent) {
            if (IsManuallySendMode(logEvent)) {
                ManuallyPayload.Add(logEvent);
            } else {
                AutomaticPayload.Add(logEvent);
                AutomaticSubmitLoggerByPipeline();
            }
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state) {
            if (state == null) throw new ArgumentNullException(nameof(state));
            return LoggingScope.Push(StateNamespace, state);
        }

        /// <inheritdoc />
        public void SubmitLogger() {
            SubmitLogEventsManually(new DisposableAction(() => {
                CurrentManuallyTransId = DateTime.Now.Ticks;
                _manuallyLogEventDescriptors.Clear();
                _manuallyLogEventDescriptors.TryAdd(CurrentManuallyTransId, new List<ManuallyLogEventDescriptor>());
            }));
        }

        private static LogEventId TouchLogEventId(LogTrack? optionalTrack, string name) {
            return optionalTrack.HasValue
                ? LogEventIdFactory.Create(optionalTrack.Value)
                : LogEventIdFactory.Create(name: name);
        }

        private static LogEventContext TouchLogEventContext(Action<LogEventContext> additionalOptContextAct) {
            var context = new LogEventContext();
            additionalOptContextAct?.Invoke(context);
            return context;
        }

        /// <inheritdoc />
        public abstract IFutureLogger ToFuture([CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0);

        /// <inheritdoc />
        public abstract ISimpleLogger ToSimple();

        #region Dispose

        private bool disposed;

        /// <inheritdoc />
        public void Dispose() {
            Dispose(true);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (disposed) return;

            if (disposing) {
                _automaticAsyncQueue.Dispose();
            }

            disposed = true;
        }

        #endregion

    }
}