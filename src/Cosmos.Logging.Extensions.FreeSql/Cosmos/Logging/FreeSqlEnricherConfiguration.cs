using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.FreeSql.Core;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// FreeSql enricher configuration
    /// </summary>
    public class FreeSqlEnricherConfiguration : SinkConfiguration {

        /// <inheritdoc />
        public FreeSqlEnricherConfiguration() : base(Constants.SinkKey) { }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is FreeSqlEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}