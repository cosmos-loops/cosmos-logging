using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Core.Piplelines;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters.Internals;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Simple {
    /// <summary>
    /// Simple logger base
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract class SimpleLoggerBase : ISimpleLogger, IDisposable {
        private readonly ILogPayloadSender _logPayloadSender;
        private readonly Func<string, LogEventLevel, bool> _filter;
        private static readonly Func<string, LogEventLevel, bool> TrueFilter = (s, l) => true;

        /// <summary>
        /// Create a new instance of <see cref="SimpleLoggerBase"/>.
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="minimumLevel"></param>
        /// <param name="loggerStateNamespace"></param>
        /// <param name="filter"></param>
        /// <param name="logPayloadSender"></param>
        protected SimpleLoggerBase(
            Type sourceType,
            LogEventLevel minimumLevel,
            string loggerStateNamespace,
            Func<string, LogEventLevel, bool> filter,
            ILogPayloadSender logPayloadSender) {
            StateNamespace = loggerStateNamespace;
            TargetType = sourceType ?? typeof(object);
            MinimumLevel = minimumLevel;
            _filter = filter ?? TrueFilter;
            _logPayloadSender = logPayloadSender ?? throw new ArgumentNullException(nameof(logPayloadSender));

            _automaticPayload = new LogPayload(sourceType, loggerStateNamespace, Enumerable.Empty<LogEvent>());
            CurrentManuallyTransId = DateTime.Now.Ticks;
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

        private long CurrentManuallyTransId { get; set; }

        /// <summary>
        /// Is enabled
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public bool IsEnabled(LogEventLevel level) {
            return _filter(StateNamespace, level) && PreliminaryEventPercolator.Percolate(level, this);
        }


        /// <summary>
        /// Write
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="level"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="messageTemplateParameters"></param>
        public void Write(LogTrack? logTrack, LogEventLevel level, Exception exception, string messageTemplate, params object[] messageTemplateParameters) {
            if (!IsEnabled(level)) return;
            if (string.IsNullOrWhiteSpace(messageTemplate)) return;
            var suchActionEventId = TouchLogEventId(logTrack, StateNamespace);
            var cleanMessageTemplateParameters = ArgsHelper.CleanUp(messageTemplateParameters);
            ParseAndInsertLogEventIntoQueueAutomatically(suchActionEventId, level, exception, messageTemplate, cleanMessageTemplateParameters);
        }

        private static LogEventId TouchLogEventId(LogTrack? track, string name) {
            return track.HasValue
                ? LogEventIdFactory.Create(track.Value)
                : LogEventIdFactory.Create(name: name);
        }

        #region Write

        /// <inheritdoc />
        public void LogVerbose(string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Verbose, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogVerbose(Exception exception, string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Verbose, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogDebug(string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Debug, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogDebug(Exception exception, string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Debug, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogInformation(string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Information, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogInformation(Exception exception, string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Information, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogWarning(string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Warning, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogWarning(Exception exception, string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Warning, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogError(string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Error, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogError(Exception exception, string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Error, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogFatal(string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Fatal, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogFatal(Exception exception, string messageTemplate, params object[] args)
            => Write(null, LogEventLevel.Fatal, exception, messageTemplate, args);

        #endregion

        #region Write with EventId

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Verbose, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Verbose, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogDebug(LogTrack logTrack, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Debug, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogDebug(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Debug, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogInformation(LogTrack logTrack, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Information, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogInformation(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Information, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogWarning(LogTrack logTrack, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Warning, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogWarning(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Warning, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogError(LogTrack logTrack, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Error, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogError(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Error, exception, messageTemplate, args);

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Fatal, null, messageTemplate, args);

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args)
            => Write(logTrack, LogEventLevel.Fatal, exception, messageTemplate, args);

        #endregion

        #region Pipelines

        private readonly ILogPayload _automaticPayload;

        /// <summary>
        /// SimpleLogger uses autocommit queue directly
        /// </summary>
        private readonly AsyncQueue<LogEvent> _automaticAsyncQueue = new AsyncQueue<LogEvent>(100);

        /// <summary>
        /// SimpleLogger does not use custom upstream rendering options.
        /// Use the default value directly here.
        /// </summary>
        private static readonly RenderingConfiguration _upstreamRenderingOptions = new RenderingConfiguration();

        /// <summary>
        /// SimpleLogger ignores all NamedMessageProperty(s)
        /// </summary>
        private static readonly Dictionary<(string name, PropertyResolvingMode mode), MessageProperty> _namedMessageProperties =
            new Dictionary<(string name, PropertyResolvingMode mode), MessageProperty>();

        /// <summary>
        /// SimpleLogger ignores all PositionalMessageProperty(s)
        /// </summary>
        private static readonly Dictionary<(int position, PropertyResolvingMode mode), MessageProperty> _positionalMessageProperties =
            new Dictionary<(int position, PropertyResolvingMode mode), MessageProperty>();

        /// <summary>
        /// SimpleLogger does not use custom log event context.
        /// Use the default value directly here.
        /// </summary>
        private static readonly LogEventContext _logEventContext = new LogEventContext();

        private void AutomaticSubmitLoggerByPipeline() => LogPayloadEmitter.Emit(_logPayloadSender, _automaticPayload.Export());

        private void ParseAndInsertLogEventIntoQueueAutomatically(
            LogEventId eventId,
            LogEventLevel level,
            Exception exception,
            string messageTemplate,
            params object[] messageTemplateParameters) {

            var task = CreateEnqueueTask();
            task.ContinueWith(t => DispatchForAutomatic());
            task.Start();

            Task CreateEnqueueTask() {
                var taskResult = new Task(async () => {
                    var writer = await _automaticAsyncQueue.AcquireWriteAsync(1, CancellationToken.None);
                    writer.Visit(
                        succeeded => {

                            var parsedTemplate = ConvertToMessageTemplate(messageTemplate, messageTemplateParameters);

                            var logEvent = new LogEvent(StateNamespace, eventId, level, parsedTemplate, exception, LogEventSendMode.Automatic,
                                NullLogCallerInfo.Instance, _upstreamRenderingOptions, _namedMessageProperties, _positionalMessageProperties, _logEventContext,
                                fromSimpleLogger: true);

                            if (succeeded.ItemCount >= 1) {
                                _automaticAsyncQueue.ReleaseWrite(logEvent);
                            } else {
                                _automaticAsyncQueue.ReleaseWrite();
                            }

                            return logEvent;
                        },
                        cancelled => {
                            InternalLogger.WriteLine("When insert log event(0) into async queue, task has been cancelled.");
                            return null;
                        },
                        faulted => {
                            InternalLogger.WriteLine(
                                $@"Thrown an exception when insert log event(0) into async queue:{Environment.NewLine}{faulted.Exception.ToUnwrappedString()}",
                                faulted.Exception);
                            return null;
                        });
                });

                return taskResult;
            }

        }

        private void DispatchForAutomatic(int desiredItems = 1) {
            var readerTask = new Task(async () => {
                bool more = true;
                while (more) {
                    var result = await _automaticAsyncQueue.AcquireReadAsync(desiredItems, CancellationToken.None);
                    result.Visit(
                        succeeded => {
                            LogEvent logEvent = null;
                            if (succeeded is AcquireReadSucceeded<LogEvent> acquireReader) {
                                logEvent = acquireReader.Items[0];
                                //dispatching
                                _automaticPayload.Add(logEvent);
                                AutomaticSubmitLoggerByPipeline();
                            }

                            if (succeeded.ItemCount < 1) {
                                more = false;
                            }

                            _automaticAsyncQueue.ReleaseRead(succeeded.ItemCount);

                            return logEvent;
                        },
                        cancelled => {
                            InternalLogger.WriteLine("Dispatching task has been cancelled.");
                            return null;
                        },
                        faulted => {
                            InternalLogger.WriteLine(
                                $@"Thrown an exception when dispatch log event from async queue:{Environment.NewLine}{faulted.Exception.ToUnwrappedString()}",
                                faulted.Exception);
                            return null;
                        });
                }
            });

            readerTask.Start();
        }

        #endregion

        #region Message safety format

        private static MessageTemplate ConvertToMessageTemplate(string messageTemplate, params object[] messageTemplateParameters) {
            string message = null;

            try {
                message = messageTemplateParameters == null
                    ? messageTemplate
                    : string.Format(messageTemplate, messageTemplateParameters);
            } catch (Exception ex) {
                //If there is a token placeholder for Cosmos.Logging, an exception will be thrown in String.Format
                message = messageTemplate;
                InternalLogger.WriteLine($@"
There was something wrong when format the raw message template in SimpleLogger.
Raw message template: '{messageTemplate}'.
Exception message: {ex.Message}.
");
            }

            //SimpleLogger does not parse the message and directly treats it as a NullTextToken as a whole.
            var parsedTemplate = new MessageTemplate(new[] {new NullTextToken(message, 0, 0)});

            return parsedTemplate;
        }

        #endregion

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