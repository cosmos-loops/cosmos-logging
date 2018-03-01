using System;
using Cosmos.Logging.Sinks.File.Configurations;

namespace Cosmos.Logging.Sinks.File.Strategies {
    public static class StrategyFactory {
        public static SavingStrategy Create(string basePath, OutputOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));

            var saving = new SavingStrategy(options.Path, options.Rolling, basePath, options.PathType) {
                FormattingStrategy = GetFormattingStrategy(options)
            };

            //解析 output template

            //创建 format strategy

            return saving;
        }

        private static FormattingStrategy GetFormattingStrategy(OutputOptions options) {
            var originalOutputTemplate = GetRealOutputTemplate(options.Template);

            return new FormattingStrategy();
        }

        private static string GetRealOutputTemplate(string outputTemplate) {
            return string.IsNullOrWhiteSpace(outputTemplate)
                ? Core.Constants.DefaultOutputTemplate
                : outputTemplate;
        }
    }
}