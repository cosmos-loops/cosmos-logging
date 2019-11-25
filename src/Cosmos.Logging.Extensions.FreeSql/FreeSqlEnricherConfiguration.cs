using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.FreeSql.Core;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class FreeSqlEnricherConfiguration : SinkConfiguration {

        public FreeSqlEnricherConfiguration() : base(Constants.SinkKey) { }

        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is FreeSqlEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}