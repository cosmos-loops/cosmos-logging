using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.SqlSugar;
using Cosmos.Logging.Sinks.SqlSugar.Core;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class SqlSguarConfiguration : SinkConfiguration {

        public SqlSguarConfiguration() : base(Constants.SinkKey) { }

        protected override void BeforeProcessLogLevel(ILoggingSinkOptions settings) {
            if (settings is SqlSugarOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}