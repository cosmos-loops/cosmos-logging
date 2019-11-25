using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.SqlSugar.Core;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class SqlSguarEnricherConfiguration : SinkConfiguration {

        public SqlSguarEnricherConfiguration() : base(Constants.SinkKey) { }

        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is SqlSugarEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}