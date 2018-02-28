using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.File.Configurations;
using Cosmos.Logging.Sinks.File.Core;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class FileSinkLogConfiguration : SinkConfiguration {
        public FileSinkLogConfiguration() : base(Constants.SinkKey) { }

        public OutputConfiguration OutputRules { get; set; } = new OutputConfiguration();

        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is FileSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}