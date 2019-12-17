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
using Cosmos.Logging.Sinks.NLog.Internals;

namespace Cosmos.Logging.Sinks.NLog {
    /// <summary>
    /// NLog payload client
    /// </summary>
    public class NLogPayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;
        private readonly NLogSinkConfiguration _sinkConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="NLogPayloadClient"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sinkConfiguration"></param>
        /// <param name="formatProvider"></param>
        public NLogPayloadClient(string name, NLogSinkConfiguration sinkConfiguration, IFormatProvider formatProvider = null) {
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
                var logger = global::NLog.LogManager.GetLogger(payload.Name, payload.SourceType);

                foreach (var logEvent in legalityEvents) {
                    LogEventEnricherManager.Enricher(logEvent);
                    var exception = logEvent.Exception;
                    var level = LogLevelSwitcher.Switch(logEvent.Level);
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

                    logger.Log(level, exception, stringBuilder.ToString());
                }
            }

            return Tasks.CompletedTask();
        }
    }
}