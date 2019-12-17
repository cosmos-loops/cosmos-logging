using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.AliyunSls.Configurations;
using Cosmos.Logging.Sinks.AliyunSls.Internals;
using EnumsNET;

namespace Cosmos.Logging {
    /// <summary>
    /// Aliyun SLS sink configuration
    /// </summary>
    public class AliyunSlsSinkConfiguration : SinkConfiguration {
        /// <inheritdoc />
        public AliyunSlsSinkConfiguration() : base(Constants.SinkKey) { }

        #region Aliyun SLS Config in configuration file

        /*
         * It'll merged into AliyunSlsSinkOptions
         */

        /// <summary>
        /// Gets or sets Aliyun SLS client
        /// </summary>
        public AliyunSlsNativeConfigWrapper Client { get; set; }

        /// <summary>
        /// Gets or sets a set of Aliyun SLS clients
        /// </summary>
        public Dictionary<string, AliyunSlsNativeConfig> Clients { get; set; }

        #endregion

        /// <inheritdoc />
        protected override void BeforeProcessing(ILoggingSinkOptions settings) {
            if (settings is AliyunSlsSinkOptions options) {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        /// <inheritdoc />
        protected override void PostProcessing(ILoggingSinkOptions settings) {
            if (settings is AliyunSlsSinkOptions options) {
                MergeAliyunSlsNativeConfig(options);

                RegisterAliyunSlsClients(options);
            }
        }

        private void MergeAliyunSlsNativeConfig(AliyunSlsSinkOptions options) {
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

        private static void PrepareForNativeClientInOptions(AliyunSlsSinkOptions options) {
            if (options.HasLegalNativeConfig(false))
                return;

            if (options.HasLegalNativeConfig(true))
                return;

            options.UseNativeConfig(Constants.DefaultClient, c => {
                c.LogStoreName = options.LogStoreName;
                c.EndPoint = options.EndPoint;
                c.ProjectName = options.ProjectName;
                c.AccessKeyId = options.AccessKeyId;
                c.AccessKey = options.AccessKey;
                c.IsGeneralClient = true;
            });
        }

        private static void RegisterAliyunSlsClients(AliyunSlsSinkOptions options) {
            if (!options.HasLegalNativeConfig(false))
                throw new InvalidOperationException("There is no legal Alibaba Cloud (Aliyun) SLS native config.");

            if (options.AliyunSlsNativeConfigs.Any())
                foreach (var kvp in options.AliyunSlsNativeConfigs)
                    AliyunSlsClientManager.SetSlsClient(kvp.Key, kvp.Value);
            else
                AliyunSlsClientManager.SetSlsClient(Constants.DefaultClient,
                    options.LogStoreName, options.EndPoint, options.ProjectName, options.AccessKeyId, options.AccessKey,
                    true);
        }
    }
}