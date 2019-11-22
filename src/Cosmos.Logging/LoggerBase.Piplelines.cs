using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Core.Piplelines;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public abstract partial class LoggerBase {

        #region Automaticlly 

        private readonly AsyncQueue<LogEvent> _automaticAsyncQueue = new AsyncQueue<LogEvent>(100);

        private void AutomaticalSubmitLoggerByPipleline() => LogPayloadEmitter.Emit(_logPayloadSender, AutomaticPayload.Export());

        private void ParseAndInsertLogEventIntoQueueAutomatically(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate,
            ILogCallerInfo callerInfo, LogEventContext context = null, params object[] messageTemplateParameters) {
            var task = CreateEnqueueTask();
            task.ContinueWith(t => DispatchForAutomatic());
            task.Start();

            Task CreateEnqueueTask() {
                var taskResult = new Task(async () => {
                    var writer = await _automaticAsyncQueue.AcquireWriteAsync(1, CancellationToken.None);
                    writer.Visit(
                        succeeded => {
                            _messageParameterProcessor.Process(messageTemplate, __as(messageTemplateParameters, context),
                                out var parsedTemplate, out var namedMessageProperties, out var positionalMessageProperties);

                            var logEvent = new LogEvent(StateNamespace, eventId, level, parsedTemplate, exception,
                                LogEventSendMode.Automatic, callerInfo, _upstreamRenderingOptions,
                                namedMessageProperties, positionalMessageProperties, context, 
                                messageProcessorShortcut:_messageParameterProcessor);

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

                object[] __as(object[] __paramObjs, LogEventContext __context) {
                    if (__paramObjs == null || !__paramObjs.Any()) return __context?.Parameters.ToArray();
                    return __paramObjs.GetType() != typeof(object[]) ? new object[] {__paramObjs} : __paramObjs;
                }
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
                                Dispatch(logEvent);
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

        #region Manually

        private readonly ConcurrentDictionary<long, List<ManuallyLogEventDescriptor>> _manuallyLogEventDescriptors =
            new ConcurrentDictionary<long, List<ManuallyLogEventDescriptor>>();

        private void ManuallySubmitLoggerByPipleline() => LogPayloadEmitter.Emit(_logPayloadSender, ManuallyPayload.Export());

        private void SubmitLogEventsManually(IDisposable disposableAction) {
            var currentManuallyTransId = CurrentManuallyTransId;
            using (disposableAction) {
                if (_manuallyLogEventDescriptors.TryGetValue(currentManuallyTransId, out var descriptors) && descriptors.Any()) {
                    Task.Factory.StartNew(() => {
                        foreach (var descriptor in descriptors) {
                            CreateAndDispatchLogEvent(descriptor.EventId, descriptor.Level, descriptor.Exception, descriptor.MessageTemplate,
                                LogEventSendMode.Manually, descriptor.CallerInfo, descriptor.Context, descriptor.MessageTemplateParameters);
                        }

                        ManuallySubmitLoggerByPipleline();
                    });
                }
            }

            void CreateAndDispatchLogEvent(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode,
                ILogCallerInfo callerInfo, LogEventContext context = null, params object[] messageTemplateParameters) {
                _messageParameterProcessor.Process(messageTemplate, __as(messageTemplateParameters, context),
                    out var parsedTemplate, out var namedMessageProperties, out var positionalMessageProperties);

                var logEvent = new LogEvent(StateNamespace, eventId, level, parsedTemplate, exception,
                    sendMode, callerInfo, _upstreamRenderingOptions, namedMessageProperties, positionalMessageProperties, context,
                    messageProcessorShortcut: _messageParameterProcessor);

                Dispatch(logEvent);

                object[] __as(object[] __paramObjs, LogEventContext __context) {
                    if (__paramObjs == null || !__paramObjs.Any()) return __context?.Parameters.ToArray();
                    return __paramObjs.GetType() != typeof(object[]) ? new object[] {__paramObjs} : __paramObjs;
                }
            }
        }

        private void ParseAndInsertLogEvenDescriptorManually(LogEventId eventId, LogEventLevel level, Exception exception, string messageTemplate,
            ILogCallerInfo callerInfo, LogEventContext context = null, params object[] messageTemplateParameters) {
            _manuallyLogEventDescriptors[CurrentManuallyTransId]
                .Add(new ManuallyLogEventDescriptor(eventId, level, exception, messageTemplate, callerInfo, context, messageTemplateParameters));
        }

        #endregion

    }
}