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
using Cosmos.Logging.Sinks.File.Core.Astronauts;
using Cosmos.Logging.Sinks.File.Filters;
using Cosmos.Logging.Sinks.File.OutputTemplates;

namespace Cosmos.Logging.Sinks.File {
    /// <summary>
    /// Local file log payload client
    /// </summary>
    public class LocalFileLogPayloadClient : ILogEventSink, ILogPayloadClient {
        private readonly IFormatProvider _formatProvider;
        private readonly FileSinkLogConfiguration _sinkConfiguration;
        private readonly FileAstronautCache _fileAstronautCache;

        /// <summary>
        /// Create a new instance of <see cref="LocalFileLogPayloadClient"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fileAstronautCache"></param>
        /// <param name="sinkConfiguration"></param>
        /// <param name="formatProvider"></param>
        public LocalFileLogPayloadClient(string name, FileAstronautCache fileAstronautCache,
            FileSinkLogConfiguration sinkConfiguration, IFormatProvider formatProvider = null) {
            _fileAstronautCache = fileAstronautCache ?? throw new ArgumentNullException(nameof(fileAstronautCache));
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
        public Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default(CancellationToken)) {
            if (payload != null) {
                var legalityEvents = LogEventSinkFilter.Filter(payload, _sinkConfiguration).ToList();

                foreach (var logEvent in legalityEvents) {

                    LogEventEnricherManager.Enricher(logEvent);

                    var strategyWrappers = NavigationFilterProcessor.GetValues(logEvent.StateNamespace);

                    if (strategyWrappers == null || !strategyWrappers.Any()) {
                        continue;
                    }

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
                        if (_fileAstronautCache.TryGetFileAstronaut(strategy, targetFilePath, out var astronaut)) {
                            using (FileAstronautRemover.UsingRegister(targetFilePath, astronaut)) {
                                astronaut.Save(stringBuilder);
                            }
                        }
                    }
                }
            }

            return Tasks.CompletedTask();
        }
    }
}