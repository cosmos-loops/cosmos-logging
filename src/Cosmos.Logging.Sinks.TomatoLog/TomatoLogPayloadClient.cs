using System;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Core.Enrichers;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;
using Cosmos.Logging.Sinks.TomatoLog.Core;

namespace Cosmos.Logging.Sinks.TomatoLog
{
    public class TomatoLogPayloadClient : ILogEventSink, ILogPayloadClient
    {
        private readonly IFormatProvider _formatProvider;
        private readonly TomatoLogSinkConfiguration _sinkConfiguration;

        public TomatoLogPayloadClient(string name, TomatoLogSinkConfiguration sinkConfiguration, IFormatProvider formatProvider = null)
        {
            _sinkConfiguration = sinkConfiguration ?? throw new ArgumentNullException(nameof(sinkConfiguration));
            Name = name;
            Level = _sinkConfiguration.GetDefaultMinimumLevel();
            _formatProvider = formatProvider;
        }

        public string Name { get; set; }
        public LogEventLevel? Level { get; set; }

        public async Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default)
        {
            if (payload != null)
            {
                var legalityEvents = LogEventSinkFilter.Filter(payload, _sinkConfiguration).ToList();
                var logger = TomatoClientManager.Get();

                if (logger == null)
                    return;

                foreach (var logEvent in legalityEvents)
                {
                    LogEventEnricherManager.Enricher(logEvent);
                    var stringBuilder = new StringBuilder();
                    using (var output = new StringWriter(stringBuilder, _formatProvider))
                    {
                        logEvent.RenderMessage(output, _sinkConfiguration.Rendering, _formatProvider);
                    }

                    var content = logEvent.ContextData?.ToString();

                    dynamic dynamicObj = null;

                    if (logEvent.ExtraProperties.Count > 0)
                    {
                        dynamicObj = new ExpandoObject();
                        foreach (var extra in logEvent.ExtraProperties)
                        {
                            var property = extra.Value;
                            if (property != null)
                                dynamicObj[property.Name] = property.Value.ToString();
                        }
                    }

                    await logger.WriteLogAsync(
                        logEvent.EventId.GetIntegerEventId(),
                        LogLevelSwitcher.Switch(logEvent.Level),
                        stringBuilder.ToString(),
                        content,
                        dynamicObj);
                }
            }
        }

    }
}