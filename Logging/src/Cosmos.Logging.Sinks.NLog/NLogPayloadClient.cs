using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core.Sinks;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.NLog {
    public class NLogPayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;

        public NLogPayloadClient(string name, LogEventLevel? level, IFormatProvider formatProvider = null) {
            Name = name;
            Level = level;
            _formatProvider = formatProvider;
        }

        public string Name { get; set; }
        public LogEventLevel? Level { get; set; }

        public Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default(CancellationToken)) {
            if (payload != null) {
                var legalityEvents = LogEventSinkFilter.Filter(payload, Level).ToList();
                var logger = global::NLog.LogManager.GetLogger(payload.Name, payload.SourceType);

                foreach (var logEvent in legalityEvents) {
                    var exception = logEvent.Exception;
                    var level = LogLevelSwitcher.Switch(logEvent.Level);
                    var builder = new StringBuilder();
                    using (var output = new StringWriter(builder, _formatProvider)) {
                        logEvent.RenderMessage(output, _formatProvider);
                    }
                    
                    logger.Log(level, exception, builder.ToString());
                }
            }

            return Task.CompletedTask;
        }
    }
}