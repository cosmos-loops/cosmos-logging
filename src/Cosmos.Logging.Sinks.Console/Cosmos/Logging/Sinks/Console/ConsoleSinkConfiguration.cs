using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.Console.Internals;
using EnumsNET;

namespace Cosmos.Logging.Sinks.Console {
    /// <summary>
    /// Console sink configuration
    /// </summary>
    public class ConsoleSinkConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public ConsoleSinkConfiguration() : base(Constants.SinkKey) { }

        /// <summary>
        /// Colour enabled
        /// </summary>
        public bool? ColorEnabled { get; set; }

        internal bool RealColourfulConsoleEnabled { get; set; } = true;

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is ConsoleSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
                RealColourfulConsoleEnabled = options.InternalColorEnabled.HasValue
                    ? options.InternalColorEnabled.Value
                    : ColorEnabled.HasValue
                        ? ColorEnabled.Value
                        : true;
            }
        }
    }
}