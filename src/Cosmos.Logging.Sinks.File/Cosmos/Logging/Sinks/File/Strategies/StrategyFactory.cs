using System;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.OutputTemplates;

namespace Cosmos.Logging.Sinks.File.Strategies {
    /// <summary>
    /// Strategy factory
    /// </summary>
    public static class StrategyFactory {
        private static readonly IOutputTemplateParser _outputTemplateParser;

        static StrategyFactory() {
            _outputTemplateParser = new OutputTemplateCache(new OutputTemplateParser());
        }

        /// <summary>
        /// Create a instance of <see cref="SavingStrategy"/>.
        /// </summary>
        /// <param name="basePath"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SavingStrategy Create(string basePath, OutputOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));

            var saving = new SavingStrategy(options.Path, options.Rolling, options.FlushToDiskInterval, basePath, options.PathType) {
                FormattingStrategy = GetFormattingStrategy(options)
            };

            return saving;
        }

        private static FormattingStrategy GetFormattingStrategy(OutputOptions options) {
            var originalOutputTemplate = GetRealOutputTemplate(options.Template);

            var outputTemplate = _outputTemplateParser.Parse(originalOutputTemplate);

            return new FormattingStrategy(outputTemplate);
        }

        private static string GetRealOutputTemplate(string outputTemplate) {
            return string.IsNullOrWhiteSpace(outputTemplate)
                ? Core.Constants.DefaultOutputTemplate
                : outputTemplate;
        }
    }
}