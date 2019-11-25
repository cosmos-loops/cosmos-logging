using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.EntityFrameworkCore.Core;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class EfCoreEnricherConfiguration : SinkConfiguration {

        public EfCoreEnricherConfiguration() : base(Constants.SinkKey) { }

        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is EfCoreEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}