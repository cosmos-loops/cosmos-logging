using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.SqlSugar.Core;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// SqlSugar enricher configuration
    /// </summary>
    public class SqlSguarEnricherConfiguration : SinkConfiguration {

        /// <inheritdoc />
        public SqlSguarEnricherConfiguration() : base(Constants.SinkKey) { }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is SqlSugarEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}