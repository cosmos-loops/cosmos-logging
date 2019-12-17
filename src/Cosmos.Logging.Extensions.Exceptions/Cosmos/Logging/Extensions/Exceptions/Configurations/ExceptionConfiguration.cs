using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.Exceptions.Core;
using EnumsNET;

namespace Cosmos.Logging.Extensions.Exceptions.Configurations {
    /// <summary>
    /// Exception configuration
    /// </summary>
    public class ExceptionConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public ExceptionConfiguration() : base(Constants.SinkKey) { }

        /// <summary>
        /// Gets or sets root name
        /// </summary>
        public string RootName { get; set; }

        /// <summary>
        /// Gets or sets destructure depth
        /// </summary>
        public int? DestructureDepth { get; set; }

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is ExceptionOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        /// <inheritdoc />
        protected override void PostProcessing(ILoggingSinkOptions settings) {
            if (settings is ExceptionOptions options) {
                RegisterDestructuringOptions(options, this);
                RegisterExceptionDestructuringProcessor();
            }
        }

        private static void RegisterDestructuringOptions(ExceptionOptions options, ExceptionConfiguration configuration) {
            var final = FinalDestructuringOptions.Create(options, configuration);
            FinalDestructuringOptions.Current = final;
        }

        private static void RegisterExceptionDestructuringProcessor() {
            var processor = new ExceptionDestructuringProcessor();
            ExceptionDestructuringContainer.SetInstance(processor);
        }
    }
}