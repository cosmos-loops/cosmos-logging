using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.JdCloud.Configurations;
using Cosmos.Logging.Sinks.JdCloud.Internals;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public class JdCloudLogSinkConfiguration : SinkConfiguration
    {
        public JdCloudLogSinkConfiguration() : base(Constants.SinkKey) { }

        #region JD Cloud Log Service Config in configuration file

        /*
         * It'll merged into JdCloudSinkOptions
         */

        public JdCloudNativeConfigWrapper Client { get; set; }

        public Dictionary<string, JdCloudNativeConfig> Clients { get; set; }

        #endregion

        protected override void BeforeProcessing(ILoggingSinkOptions settings)
        {
            if (settings is JdCloudLogSinkOptions options)
            {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());
            }
        }

        protected override void PostProcessing(ILoggingSinkOptions settings)
        {
            if (settings is JdCloudLogSinkOptions options)
            {
                MergeJdCloudNativeConfig(options);
            }
        }

        private void MergeJdCloudNativeConfig(JdCloudLogSinkOptions options)
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

        private static void PrepareForNativeClientInOptions(JdCloudLogSinkOptions options)
        {
            if (options.HasLegalNativeConfig(false))
                return;

            if (options.HasLegalNativeConfig(true))
                return;

            options.UseNativeConfig(Constants.DefaultClient, c =>
            {
                c.LogStreamName = options.LogStreamName;
                c.SecretKey = options.SecretKey;
                c.AccessKey = options.AccessKey;
                c.RetryTimes = options.RetryTimes;
                c.RequestTimeout = options.RequestTimeout;
                c.Security = options.Security;
                c.IsGeneralClient = true;
            });
        }
    }
}