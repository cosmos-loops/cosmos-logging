using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.Console.Internals;
using EnumsNET;

namespace Cosmos.Logging.Sinks.Console
{
    public class ConsoleSinkConfiguration : SinkConfiguration 
    {
        public ConsoleSinkConfiguration() : base(Constants.SinkKey) { }
        
        public bool? ColorEnabled { get; set; }

        internal bool RealColourfulConsoleEnabled { get; set; } = true;
        
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