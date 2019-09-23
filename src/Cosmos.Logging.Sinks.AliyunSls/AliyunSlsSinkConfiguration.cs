using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Core.Extensions;
using Cosmos.Logging.Sinks.AliyunSls.Configurations;
using Cosmos.Logging.Sinks.AliyunSls.Internals;
using EnumsNET;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public class AliyunSlsSinkConfiguration : SinkConfiguration
    {
        public AliyunSlsSinkConfiguration() : base(Constants.SinkKey) { }

        #region Aliyun SLS Config in configuration file

        /*
         * It'll merged into AliyunSlsSinkOptions
         */

        public AliyunSlsNativeConfigWrapper Client { get; set; }

        public Dictionary<string, AliyunSlsNativeConfig> Clients { get; set; }

        #endregion

        protected override void BeforeProcessing(ILoggingSinkOptions settings)
        {
            if (settings is AliyunSlsSinkOptions options)
            {
                Aliases.MergeAndOverWrite(options.InternalAliases, k => k, v => v.GetName());
                LogLevel.MergeAndOverWrite(options.InternalNavigatorLogEventLevels, k => k, v => v.GetName());

                MergeAliyunSlsNativeConfig(options);
            }
        }

        private void MergeAliyunSlsNativeConfig(AliyunSlsSinkOptions options)
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

        private static void PrepareForNativeClientInOptions(AliyunSlsSinkOptions options)
        {
            if (options.HasLegalNativeConfig(false))
                return;
            
            if(options.HasLegalNativeConfig(true))
                return;
            
            options.UseNativeConfig(Constants.DefaultClient, c =>
            {
                c.LogStoreName = options.LogStoreName;
                c.EndPoint = options.EndPoint;
                c.ProjectName = options.ProjectName;
                c.AccessKeyId = options.AccessKeyId;
                c.AccessKey = options.AccessKey;
                c.IsGeneralClient = true;
            });


        }
    }
}