using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.PostgreSql.Core;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    /// <summary>
    /// PostgreSql enricher configuration
    /// </summary>
    public class PostgresEnricherConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public PostgresEnricherConfiguration() : base(Constants.SinkKey) { }

        /// <summary>
        /// Is parameter logging enable?
        /// </summary>
        public bool? IsParameterLoggingEnable { get; set; }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is PostgresEnricherOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        /// <inheritdoc />
        protected override void PostProcessing(ILoggingSinkOptions settings) {
            if (settings is PostgresEnricherOptions options) {
                var finalParameterEnable = PostgresOptionsHelper.GetFinalParameterEnable(options, this);
                options.FinalParameterLoggingEnable = finalParameterEnable;
            }
        }
    }
}