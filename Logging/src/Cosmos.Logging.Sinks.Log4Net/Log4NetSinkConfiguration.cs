using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.Log4Net;
using Cosmos.Logging.Sinks.Log4Net.Internals;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class Log4NetSinkConfiguration : SinkConfiguration {
        public Log4NetSinkConfiguration() : base(Constants.SinkKey) { }

        protected override void BeforeProcessLogLevel(ILoggingSinkOptions settings) {
            if (settings is Log4NetSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }
    }
}