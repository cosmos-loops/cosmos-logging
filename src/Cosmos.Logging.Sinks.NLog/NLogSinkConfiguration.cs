using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.NLog.Internals;
using EnumsNET;
using NLog;
using NLog.Config;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging {
    public class NLogSinkConfiguration : SinkConfiguration {
        public NLogSinkConfiguration() : base(Constants.SinkKey) { }

        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is NLogSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        protected override void PostProcessing(ILoggingSinkOptions settings) {
            if (settings is NLogSinkOptions options) {
                if (options.OriginConfiguration != null) {
                    LogManager.Configuration = options.OriginConfiguration;
                } else if (!string.IsNullOrWhiteSpace(options.OriginConfigFilePath)) {
                    LogManager.Configuration = new XmlLoggingConfiguration(options.OriginConfigFilePath);
                } else if (!string.IsNullOrWhiteSpace(ConfigFile)) {
                    LogManager.Configuration = new XmlLoggingConfiguration(ConfigFile);
                } else {
                    LogManager.Configuration = new DefaultNLogConfiguration();
                }

                if (options.MinimumLevel.HasValue) {
                    LogManager.GlobalThreshold = LogLevelSwitcher.Switch(options.MinimumLevel.Value);
                }
            } else if (!string.IsNullOrWhiteSpace(ConfigFile)) {
                LogManager.Configuration = new XmlLoggingConfiguration(ConfigFile);
            } else {
                LogManager.Configuration = new DefaultNLogConfiguration();
            }
        }

        /// <summary>
        /// NLog's origin config file path
        /// </summary>
        public string ConfigFile { get; set; }
    }
}