using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleLogPayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;
        private readonly SampleLogConfiguration _sinkConfiguration;

        public SampleLogPayloadClient(string name, SampleLogConfiguration sinkConfiguration, IFormatProvider formatProvider = null) {
            _sinkConfiguration = sinkConfiguration ?? throw new ArgumentNullException(nameof(sinkConfiguration));
            Name = name;
            Level = sinkConfiguration.GetDefaultMinimumLevel();
            _formatProvider = formatProvider;
        }

        public string Name { get; set; }
        public LogEventLevel? Level { get; set; }

        public Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default(CancellationToken)) {
            if (payload != null) {
                var legalityEvents = LogEventSinkFilter.Filter(payload, _sinkConfiguration).ToList();
                var ix = 0;
                var count = legalityEvents.Count;

                foreach (var logEvent in legalityEvents) {
                    var stringBuilder = new StringBuilder();
                    using (var output = new StringWriter(stringBuilder, _formatProvider)) {
                        logEvent.RenderMessage(output, _sinkConfiguration.RenderingOptions, _formatProvider);
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

//                    foreach (var token in logEvent.MessageTemplate.Tokens) {
//                        Console.WriteLine($"token={token}, type={token.TokenRenderType}, rawString={token.RawText}, tokenString={token.ToText()}");
//                    }

                    Console.WriteLine($"[{payload.Name}][{PadLeftByZero()(ix++)(count)('0')}][{GetLevelName()(logEvent.Level)}] {stringBuilder}");
                }
            }
#if NET451
            return Task.FromResult(true);
#else
            return Task.CompletedTask;
#endif
        }

        private static Func<int, Func<int, Func<char, string>>> PadLeftByZero() => i => count => c => i.ToString().PadLeft(count, c);

        private static Func<LogEventLevel?, string> GetLevelName() => l => EnumsNET.Enums.GetName(l ?? LogEventLevel.Off);
    }
}