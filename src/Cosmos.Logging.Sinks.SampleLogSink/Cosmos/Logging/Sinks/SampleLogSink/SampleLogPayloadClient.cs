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

namespace Cosmos.Logging.Sinks.SampleLogSink {
    /// <summary>
    /// Sample log payload client
    /// </summary>
    public class SampleLogPayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;
        private readonly SampleLogConfiguration _sinkConfiguration;

        /// <summary>
        /// Create a new instance of <see cref="SampleLogPayloadClient"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sinkConfiguration"></param>
        /// <param name="formatProvider"></param>
        public SampleLogPayloadClient(string name, SampleLogConfiguration sinkConfiguration, IFormatProvider formatProvider = null) {
            _sinkConfiguration = sinkConfiguration ?? throw new ArgumentNullException(nameof(sinkConfiguration));
            Name = name;
            Level = sinkConfiguration.GetDefaultMinimumLevel();
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
                var ix = 0;
                var count = legalityEvents.Count.ToString().Length;

                foreach (var logEvent in legalityEvents) {

                    LogEventEnricherManager.Enricher(logEvent);

                    var stringBuilder = new StringBuilder();
                    using (var output = new StringWriter(stringBuilder, _formatProvider)) {
                        logEvent.RenderMessage(output, _sinkConfiguration.Rendering, _formatProvider);
                    }

                    if (logEvent.ExtraProperties.Count > 0) {
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine("Extra properties:");
                        foreach (var extra in logEvent.ExtraProperties) {
                            var property = extra.Value;
                            if (property != null) {
                                stringBuilder.AppendLine($"    {property}");
                            }
                        }
                    }

//                    foreach (var token in logEvent.MessageTemplate.Tokens) {
//                        Console.WriteLine($"token={token}, type={token.TokenRenderType}, rawString={token.RawText}, tokenString={token.ToText()}");
//                    }

                    Console.WriteLine($@"
[{PadLeftByZero()(ix++)(count)('0')}] -- [{payload.Name}] -- [{GetLevelName()(logEvent.Level)}] 
{stringBuilder}");
                }
            }

            return Tasks.CompletedTask();
        }

        private static Func<int, Func<int, Func<char, string>>> PadLeftByZero() => i => count => c => i.ToString().PadLeft(count, c);

        private static Func<LogEventLevel?, string> GetLevelName() => l => EnumsNET.Enums.GetName(l ?? LogEventLevel.Off);
    }
}