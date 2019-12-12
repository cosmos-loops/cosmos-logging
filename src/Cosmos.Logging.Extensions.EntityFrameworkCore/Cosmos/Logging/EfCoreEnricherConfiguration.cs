using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.EntityFrameworkCore.Core;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// Cosmos Logging EntityFrameworkCore Enricher configuration
    /// </summary>
    public class EfCoreEnricherConfiguration : SinkConfiguration {

        /// <inheritdoc />
        public EfCoreEnricherConfiguration() : base(Constants.SinkKey) { }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is EfCoreEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}