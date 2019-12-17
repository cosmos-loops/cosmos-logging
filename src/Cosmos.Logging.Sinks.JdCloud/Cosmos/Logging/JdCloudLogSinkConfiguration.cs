using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.JdCloud.Configurations;
using Cosmos.Logging.Sinks.JdCloud.Internals;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// JdCloud log sink configuration
    /// </summary>
    public class JdCloudLogSinkConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public JdCloudLogSinkConfiguration() : base(Constants.SinkKey) { }

        #region JD Cloud Log Service Config in configuration file

        /*
         * It'll merged into JdCloudSinkOptions
         */

        /// <summary>
        /// Gets or sets JdCloud client
        /// </summary>
        public JdCloudNativeConfigWrapper Client { get; set; }

        /// <summary>
        /// Gets or sets a set of JdCloud clients
        /// </summary>
        public Dictionary<string, JdCloudNativeConfig> Clients { get; set; }

        #endregion

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is JdCloudLogSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        /// <inheritdoc />
        protected override void PostProcessing(ILoggingSinkOptions settings) {
            if (settings is JdCloudLogSinkOptions options) {
                MergeJdCloudNativeConfig(options);

                RegisterJdCloudLogClients(options);
            }
        }

        private void MergeJdCloudNativeConfig(JdCloudLogSinkOptions options) {
            PrepareForNativeClientInOptions(options);

            if (Clients != null) {
                foreach (var kvp in Clients.Where(o => !string.IsNullOrWhiteSpace(o.Key) && o.Value.IsValid())) {
                    options.UseNativeConfig(kvp.Key, c => c.SetMySelf(kvp.Value));
                }
            }
            else if (Client != null) {
                options.UseNativeConfig(Client.Key, c => c.SetMySelf(Client));
            }
        }

        private static void PrepareForNativeClientInOptions(JdCloudLogSinkOptions options) {
            if (options.HasLegalNativeConfig(false))
                return;

            if (options.HasLegalNativeConfig(true))
                return;

            options.UseNativeConfig(Constants.DefaultClient, c => {
                c.LogStreamName = options.LogStreamName;
                c.SecretKey = options.SecretKey;
                c.AccessKey = options.AccessKey;
                c.RetryTimes = options.RetryTimes;
                c.RequestTimeout = options.RequestTimeout;
                c.Security = options.Security;
                c.IsGeneralClient = true;
            });
        }

        private static void RegisterJdCloudLogClients(JdCloudLogSinkOptions options) {
            if (!options.HasLegalNativeConfig(false))
                throw new InvalidOperationException("There is no legal JD Cloud Log Service native config.");

            if (options.JdCloudLogNativeConfigs.Any())
                foreach (var kvp in options.JdCloudLogNativeConfigs)
                    JdCloudLogClientManager.SetLogClient(kvp.Key, kvp.Value);
            else
                JdCloudLogClientManager.SetLogClient(Constants.DefaultClient,
                    options.LogStreamName, options.AccessKey, options.SecretKey, options.Security, options.RequestTimeout,
                    true);
        }
    }
}