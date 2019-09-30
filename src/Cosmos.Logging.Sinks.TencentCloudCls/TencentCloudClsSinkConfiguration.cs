using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.TencentCloudCls.Configurations;
using Cosmos.Logging.Sinks.TencentCloudCls.Internals;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public class TencentCloudClsSinkConfiguration : SinkConfiguration
    {
        public TencentCloudClsSinkConfiguration() : base(Constants.SinkKey) { }

        #region JD Cloud Log Service Config in configuration file

        /*
         * It'll merged into JdCloudSinkOptions
         */

        public TencentCloudClsNativeConfigWrapper Client { get; set; }

        public Dictionary<string, TencentCloudClsNativeConfig> Clients { get; set; }

        #endregion

        protected override void BeforeProcessing(ILoggingSinkOptions settings)
        {
            if (settings is TencentCloudClsSinkOptions options)
            {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        protected override void PostProcessing(ILoggingSinkOptions settings)
        {
            if (settings is TencentCloudClsSinkOptions options)
            {
                MergeTencentCloudClsNativeConfig(options);

                RegisterTencentCloudClsClients(options);
            }
        }

        private void MergeTencentCloudClsNativeConfig(TencentCloudClsSinkOptions options)
        {
            PrepareForNativeClientInOptions(options);

            if (Clients != null)
            {
                foreach (var kvp in Clients.Where(o => !string.IsNullOrWhiteSpace(o.Key) && o.Value.IsValid()))
                {
                    options.UseNativeConfig(kvp.Key, c => c.SetMySelf(kvp.Value));
                }
            }
            else if (Client != null)
            {
                options.UseNativeConfig(Client.Key, c => c.SetMySelf(Client));
            }
        }

        private static void PrepareForNativeClientInOptions(TencentCloudClsSinkOptions options)
        {
            if (options.HasLegalNativeConfig(false))
                return;

            if (options.HasLegalNativeConfig(true))
                return;

            options.UseNativeConfig(Constants.DefaultClient, c =>
            {
                c.RequestUri = options.RequestUri;
                c.SecretId = options.SecretId;
                c.SecretKey = options.SecretKey;
                c.TopicId = options.TopicId;
                c.RequestTimeout = options.RequestTimeout;
                c.IsGeneralClient = true;
            });
        }
        
        private static void RegisterTencentCloudClsClients(TencentCloudClsSinkOptions options)
        {
            if (!options.HasLegalNativeConfig(false))
                throw new InvalidOperationException("There is no legal JD Cloud Log Service native config.");

            if (options.TencentCloudClsNativeConfigs.Any())
                foreach (var kvp in options.TencentCloudClsNativeConfigs)
                    TencentCloudClsClientManager.SetClsClient(kvp.Key, kvp.Value);
            else
                TencentCloudClsClientManager.SetClsClient(Constants.DefaultClient,
                    options.RequestUri, options.SecretId, options.SecretKey, options.TopicId, options.RequestTimeout,
                    true);
        }
    }
}