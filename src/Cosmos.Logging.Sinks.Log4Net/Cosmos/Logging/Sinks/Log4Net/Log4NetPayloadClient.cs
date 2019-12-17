using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Asynchronous;
using Cosmos.Logging.Core.Enrichers;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;

namespace Cosmos.Logging.Sinks.Log4Net {
    /// <summary>
    /// Log4Net payload client
    /// </summary>
    public class Log4NetPayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;
        private readonly Log4NetSinkConfiguration _sinkConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="Log4NetPayloadClient"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sinkConfiguration"></param>
        /// <param name="formatProvider"></param>
        public Log4NetPayloadClient(string name, Log4NetSinkConfiguration sinkConfiguration, IFormatProvider formatProvider = null) {
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
                var logger = log4net.LogManager.GetLogger(payload.SourceType);

                foreach (var logEvent in legalityEvents) {
                    LogEventEnricherManager.Enricher(logEvent);
                    var stringBuilder = new StringBuilder();
                    using (var output = new StringWriter(stringBuilder, _formatProvider)) {
                        logEvent.RenderMessage(output, _sinkConfiguration.Rendering, _formatProvider);
                    }

                    if (logEvent.ExtraProperties.Count > 0) {
                        stringBuilder.AppendLine("Extra properties:");
                        foreach (var extra in logEvent.ExtraProperties) {
                            var property = extra.Value;
                            if (property != null) {
                                stringBuilder.AppendLine($"    {property}");
                            }
                        }
                    }

                    switch (logEvent.Level) {
                        case LogEventLevel.Verbose:
                        case LogEventLevel.Debug:
                            logger.Debug(stringBuilder.ToString(), logEvent.Exception);
                            break;
                        case LogEventLevel.Information:
                            logger.Info(stringBuilder.ToString(), logEvent.Exception);
                            break;
                        case LogEventLevel.Warning:
                            logger.Warn(stringBuilder.ToString(), logEvent.Exception);
                            break;
                        case LogEventLevel.Error:
                            logger.Error(stringBuilder.ToString(), logEvent.Exception);
                            break;
                        case LogEventLevel.Fatal:
                            logger.Fatal(stringBuilder.ToString(), logEvent.Exception);
                            break;
                        default:
                            logger.Info(stringBuilder.ToString(), logEvent.Exception);
                            break;
                    }
                }
            }

            return Tasks.CompletedTask();
        }
    }
}