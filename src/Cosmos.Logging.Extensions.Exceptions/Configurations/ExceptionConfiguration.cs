using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Extensions.Exceptions.Core;
using EnumsNET;

namespace Cosmos.Logging.Extensions.Exceptions.Configurations {
    public class ExceptionConfiguration : SinkConfiguration {
        public ExceptionConfiguration() : base(Constants.SinkKey) { }

        public string RootName { get; set; }

        public int? DestructureDepth { get; set; }

        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is ExceptionOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

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