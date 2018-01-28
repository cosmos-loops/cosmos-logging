using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using EnumsNET;

namespace Cosmos.Logging.Sinks.NLog {
    public class NLogSinkConfiguration : SinkConfiguration {
        public NLogSinkConfiguration() : base(Internals.Constants.SinkKey) { }

        protected override void BeforeProcessLogLevel(ILoggingSinkOptions settings) {
            if (settings is NLogSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}