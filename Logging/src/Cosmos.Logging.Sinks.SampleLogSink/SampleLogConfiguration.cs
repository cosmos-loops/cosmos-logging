using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.SampleLogSink.Internals;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class SampleLogConfiguration : SinkConfiguration {
        public SampleLogConfiguration() : base(Constants.SinkKey) { }

        protected override void BeforeProcessLogLevel(ILoggingSinkOptions settings) {
            if (settings is SampleOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}