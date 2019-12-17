using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Core;
using Cosmos.Logging.Sinks.File.Filters;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// File sink configuration
    /// </summary>
    public class FileSinkLogConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public FileSinkLogConfiguration() : base(Constants.SinkKey) { }

        /// <summary>
        /// Output rules
        /// </summary>
        public OutputConfiguration OutputRules { get; set; } = new OutputConfiguration();

        /// <summary>
        /// Base path
        /// </summary>
        public string BasePath { get; set; }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is FileSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());

                foreach (var rule in OutputRules) {
                    if (rule.Value != null && string.IsNullOrWhiteSpace(rule.Value.Template)) {
                        rule.Value.Template = options.RealDefaultOutputTemplate;
                    }
                }

                foreach (var rule in options.OutputOptionsInternal) {
                    NavigationFilterProcessor.SetOutputOption(rule.Key, rule.Value, BasePath);
                }
            }

            foreach (var rule in OutputRules) {
                NavigationFilterProcessor.SetOutputOption(rule.Key, rule.Value, BasePath);
            }
        }
    }
}