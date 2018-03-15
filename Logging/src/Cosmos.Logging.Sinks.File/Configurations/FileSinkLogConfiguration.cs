using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Core;
using Cosmos.Logging.Sinks.File.Filters;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class FileSinkLogConfiguration : SinkConfiguration {
        public FileSinkLogConfiguration() : base(Constants.SinkKey) { }

        public OutputConfiguration OutputRules { get; set; } = new OutputConfiguration();

        public string BasePath { get; set; }

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