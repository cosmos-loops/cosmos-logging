using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core.Sinks;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.SampleLogSink {
    public class SampleLogPayloadClient : ILogEventSink, ILogPayloadClient {
        public SampleLogPayloadClient(string name, LogEventLevel? level) {
            Name = name;
            Level = level;
        }

        public string Name { get; set; }
        public LogEventLevel? Level { get; set; }

        public Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default(CancellationToken)) {
            if (payload != null) {
                var legalityEvents = LogEventSinkFilter.Filter(payload, Level).ToList();
                var ix = 0;
                var count = legalityEvents.Count;
                foreach (var logEvent in legalityEvents) {
                    Console.WriteLine($"[{Name}{PadLeftByZero()(ix++)(count)('0')}][{GetLevelName()(Level)}] {logEvent.MessageTemplate}");
                }
            }

            return Task.CompletedTask;
        }

        private static Func<int, Func<int, Func<char, string>>> PadLeftByZero() => i => count => c => i.ToString().PadLeft(count, c);

        private static Func<LogEventLevel?, string> GetLevelName() => l => EnumsNET.Enums.GetName(l ?? LogEventLevel.Off);
    }
}