using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cosmos.Logging.Core.Payloads;
using Cosmos.Logging.Events;
using Cosmos.Logging.Filters;
using Cosmos.Logging.Sinks.File.Filters;
using Cosmos.Logging.Sinks.File.OutputTemplates;

namespace Cosmos.Logging.Sinks.File {
    public class LocalFileLogPayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;
        private readonly FileSinkLogConfiguration _sinkConfiguration;

        public LocalFileLogPayloadClient(string name, FileSinkLogConfiguration sinkConfiguration, IFormatProvider formatProvider = null) {
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
                    var strategyWrappers = NavigationFilterProcessor.GetValues(logEvent.StateNamespace);

                    if (strategyWrappers == null || !strategyWrappers.Any()) {
                        continue;
                    }

                    //渲染Message
                    var targetMessageBuilder = new StringBuilder();
                    using (var output = new StringWriter(targetMessageBuilder, _formatProvider)) {
                        logEvent.RenderMessage(output, _sinkConfiguration.Rendering, _formatProvider);
                    }

                    foreach (var strategy in strategyWrappers.Select(x => x.SavingStrategy)) {
                        var targetFilePath = strategy.CheckAndGetFilePath(logEvent);
                        if (string.IsNullOrWhiteSpace(targetFilePath)) continue;

                        //判断是否需要渲染 extra properties
                        //检查token

                        //渲染OutputTemplate
                        var stringBuilder = new StringBuilder();
                        using (var output = new StringWriter(stringBuilder, _formatProvider)) {
                            OutputTemplateRenderer.Render(strategy.FormattingStrategy.OutputTemplate, output, logEvent, targetMessageBuilder);
                        }                   

                        //写文件


                        if (logEvent.ExtraProperties.Count > 0) {
                            stringBuilder.AppendLine("Extra properties:");
                            foreach (var extra in logEvent.ExtraProperties) {
                                var property = extra.Value;
                                if (property != null) {
                                    stringBuilder.AppendLine($"    {property}");
                                }
                            }
                        }

                        Console.WriteLine($"[{payload.Name}][{PadLeftByZero()(ix++)(count)('0')}][{GetLevelName()(logEvent.Level)}] {stringBuilder}");
                    }
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