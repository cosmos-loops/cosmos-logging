using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Asynchronous;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Enrichers;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;
using Cosmos.Logging.Sinks.Exceptionless.Internals;
using Exceptionless;
using Exceptionless.Logging;

namespace Cosmos.Logging.Sinks.Exceptionless {
    /// <summary>
    /// Exceptionless payload client
    /// </summary>
    public class ExceptionlessPayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;
        private readonly ExceptionlessSinkConfiguration _sinkConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="ExceptionlessPayloadClient"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sinkConfiguration"></param>
        /// <param name="formatProvider"></param>
        public ExceptionlessPayloadClient(string name, ExceptionlessSinkConfiguration sinkConfiguration, IFormatProvider formatProvider = null) {
            _sinkConfiguration = sinkConfiguration ?? throw new ArgumentNullException(nameof(sinkConfiguration));
            Name = name;
            Level = _sinkConfiguration.GetDefaultMinimumLevel();
            _formatProvider = formatProvider;
        }

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public LogEventLevel? Level { get; set; }

        /// <inheritdoc />
        public Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default) {
            if (payload != null) {
                var legalityEvents = LogEventSinkFilter.Filter(payload, _sinkConfiguration).ToList();
                var source = payload.SourceType.FullName;
                using (var logger = ExceptionlessClient.Default) {
                    foreach (var logEvent in legalityEvents) {
                        LogEventEnricherManager.Enricher(logEvent);
                        var exception = logEvent.Exception;
                        var level = LogLevelSwitcher.Switch(logEvent.Level);
                        var stringBuilder = new StringBuilder();
                        using (var output = new StringWriter(stringBuilder, _formatProvider)) {
                            logEvent.RenderMessage(output, _sinkConfiguration.Rendering, _formatProvider);
                        }

                        var builder = logger.CreateLog(source, stringBuilder.ToString(), level);
                        builder.Target.Date = logEvent.Timestamp;

                        if (level == LogLevel.Fatal) {
                            builder.MarkAsCritical();
                        }

                        if (exception != null) {
                            builder.SetException(exception);
                        }

                        var legalityOpts = logEvent.GetAdditionalOperations(typeof(ExceptionlessPayloadClient), AdditionalOperationTypes.ForLogSink);
                        foreach (var opt in legalityOpts) {
                            if (opt.GetOpt() is Func<EventBuilder, EventBuilder> eventBuilderFunc) {
                                eventBuilderFunc.Invoke(builder);
                            }
                        }

                        foreach (var extra in logEvent.ExtraProperties) {
                            var property = extra.Value;
                            if (property != null) {
                                builder.SetProperty(property.Name, property.Value);
                            }
                        }

                        builder.PluginContextData.MergeContextData(logEvent.ContextData);

                        builder.Submit();
                    }
                }
            }

            return Tasks.CompletedTask();
        }
    }
}