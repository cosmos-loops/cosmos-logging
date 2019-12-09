using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.PostgreSql.Core;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class PostgresEnricherConfiguration : SinkConfiguration {
        public PostgresEnricherConfiguration() : base(Constants.SinkKey) { }

        public bool? IsParameterLoggingEnable { get; set; }

        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is PostgresEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        protected override void PostProcessing(ILoggingSinkOptions settings) {
            if (settings is PostgresEnricherOptions options) {
                var finalParameterEnable = PostgresOptionsHelper.GetFinalParameterEnable(options, this);
                options.FinalParameterLoggingEnable = finalParameterEnable;
            }
        }
    }
}