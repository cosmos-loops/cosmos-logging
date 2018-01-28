using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using EnumsNET;

namespace Cosmos.Logging.Sinks.Exceptionless {
    public class ExceptionlessSinkConfiguration : SinkConfiguration {
        public ExceptionlessSinkConfiguration() : base(Internals.Constants.SinkKey) { }

        protected override void BeforeProcessLogLevel(ILoggingSinkOptions settings) {
            if (settings is ExceptionlessSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}