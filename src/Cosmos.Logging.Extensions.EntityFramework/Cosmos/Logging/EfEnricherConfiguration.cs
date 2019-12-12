using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.EntityFramework.Core;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// Cosmos Logging EntityFramework Enricher coniguration
    /// </summary>
    public class EfEnricherConfiguration : SinkConfiguration {

        /// <inheritdoc />
        public EfEnricherConfiguration() : base(Constants.SinkKey) { }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is EfEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}