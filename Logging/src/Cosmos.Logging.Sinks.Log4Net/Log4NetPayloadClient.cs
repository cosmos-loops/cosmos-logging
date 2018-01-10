using System;
using System.Linq;
using System.Reflection;
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

                    var message = logEvent.RenderMessage(_formatProvider);
                    var exception = logEvent.Exception;

                    switch (logEvent.Level) {
                        case LogEventLevel.Verbose:
                        case LogEventLevel.Debug:
                            logger.Debug(message, exception);
                            break;
                        case LogEventLevel.Information:
                            logger.Info(message, exception);
                            break;
                        case LogEventLevel.Warning:
                            logger.Warn(message, exception);
                            break;
                        case LogEventLevel.Error:
                            logger.Error(message, exception);
                            break;
                        case LogEventLevel.Fatal:
                            logger.Fatal(message, exception);
                            break;
                        default:
                            logger.Info(message, exception);
                            break;
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}