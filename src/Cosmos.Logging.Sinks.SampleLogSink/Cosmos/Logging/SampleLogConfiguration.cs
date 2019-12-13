using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.SampleLogSink.Internals;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// Sample log configuration
    /// </summary>
    public class SampleLogConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public SampleLogConfiguration() : base(Constants.SinkKey) { }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is SampleOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}