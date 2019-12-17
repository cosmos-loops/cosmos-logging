using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.NHibernate.Core;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// NHibernate enricher configuration
    /// </summary>
    public class NhEnricherConfiguration : SinkConfiguration {

        /// <inheritdoc />
        public NhEnricherConfiguration() : base(Constants.SinkKey) { }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is NhEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}