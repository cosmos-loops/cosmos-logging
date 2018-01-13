using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Collectors;
using Cosmos.Logging.Core.Sinks;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetPayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;

        public Log4NetPayloadClient(string name, LogEventLevel? level, IFormatProvider formatProvider = null) {
            Name = name;
            Level = level;
            _formatProvider = formatProvider;
        }

        public string Name { get; set; }
        public LogEventLevel? Level { get; set; }

        public Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default(CancellationToken)) {
            if (payload != null) {
                var legalityEvents = LogEventSinkFilter.Filter(payload, Level).ToList();
                var logger = log4net.LogManager.GetLogger(payload.SourceType);

                foreach (var logEvent in legalityEvents) {
                    var stringBuilder = new StringBuilder();
                    using (var output = new StringWriter(stringBuilder, _formatProvider)) {
                        logEvent.RenderMessage(output, _formatProvider);
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

            return Task.CompletedTask;
        }
    }
}