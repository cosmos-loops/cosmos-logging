using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.Log4Net.Internals;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// LogNet sink configuration
    /// </summary>
    public class Log4NetSinkConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public Log4NetSinkConfiguration() : base(Constants.SinkKey) { }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is Log4NetSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}