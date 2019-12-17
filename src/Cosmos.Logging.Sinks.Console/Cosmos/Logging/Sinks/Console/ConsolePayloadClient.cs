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
using Cosmos.Logging.Sinks.Console.Internals;
using EnumsNET;

namespace Cosmos.Logging.Sinks.Console {
    /// <summary>
    /// Console Payload client
    /// </summary>
    public class ConsolePayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;
        private readonly ConsoleSinkConfiguration _sinkConfiguration;
        private readonly MessageConsumer _messageConsumer;

        private static (ConsoleColor?, ConsoleColor?) _defaultConsoleColour = ((ConsoleColor?) null, (ConsoleColor?) null);

        /// <summary>
        /// Create a new instance of <see cref="ConsolePayloadClient"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sinkConfiguration"></param>
        /// <param name="formatProvider"></param>
        public ConsolePayloadClient(string name, ConsoleSinkConfiguration sinkConfiguration, IFormatProvider formatProvider = null) {
            _sinkConfiguration = sinkConfiguration ?? throw new ArgumentNullException(nameof(sinkConfiguration));
            Name = name;
            Level = _sinkConfiguration.GetDefaultMinimumLevel();
            _formatProvider = formatProvider;

            _messageConsumer = new MessageConsumer(ConsoleFactory.CreateConsole());
        }

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public LogEventLevel? Level { get; set; }

        /// <inheritdoc />
        public Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default) {
            if (payload != null) {
                var legalityEvents = LogEventSinkFilter.Filter(payload, _sinkConfiguration).ToList();

                foreach (var logEvent in legalityEvents) {
                    LogEventEnricherManager.Enricher(logEvent);

                    var stringBuilder = new StringBuilder();

                    stringBuilder.AppendLine($"[{logEvent.Level.GetName()}] {logEvent.Timestamp.Date:yyyy-MM-dd HH:mm:ss.ffff}");

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

                    _messageConsumer.EnqueueMessage(CreateMessageWrapper(logEvent.Level, stringBuilder));
                }
            }

            return Tasks.CompletedTask();

            MessageWrapper CreateMessageWrapper(LogEventLevel level, StringBuilder builder) {
                var (background, foreground) = _sinkConfiguration.RealColourfulConsoleEnabled
                    ? ConsoleColourHelper.GetColour(level)
                    : _defaultConsoleColour;

                return new MessageWrapper(builder.ToString(), background, foreground);
            }
        }
    }
}