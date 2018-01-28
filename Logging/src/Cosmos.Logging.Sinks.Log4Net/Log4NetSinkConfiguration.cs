using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using EnumsNET;

namespace Cosmos.Logging.Sinks.Log4Net {
    public class Log4NetSinkConfiguration : SinkConfiguration {
        public Log4NetSinkConfiguration() : base(Internals.Constants.SinkKey) { }

        protected override void BeforeProcessLogLevel(ILoggingSinkOptions settings) {
            if (settings is Log4NetSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}