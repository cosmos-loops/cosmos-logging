using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.Exceptionless.Internals;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// Exceptionless sink configuration
    /// </summary>
    public class ExceptionlessSinkConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public ExceptionlessSinkConfiguration() : base(Constants.SinkKey) { }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is ExceptionlessSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}