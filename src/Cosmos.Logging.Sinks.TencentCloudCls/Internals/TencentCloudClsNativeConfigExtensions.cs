using System;
using System.Linq;
using Cosmos.Logging.Sinks.TencentCloudCls.Configurations;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Internals
{
    internal static class TencentCloudClsNativeConfigExtensions
    {
        public static bool HasLegalNativeConfig(this TencentCloudClsSinkOptions options, bool onlyCheckCollConfig)
        {
            if (options == null)
                return false;

            if (options.TencentCloudClsNativeConfigs.Any())
                return options.TencentCloudClsNativeConfigs.All(o => !string.IsNullOrWhiteSpace(o.Key) && o.Value.IsValid());

            if (onlyCheckCollConfig)
                return false;

            return !string.IsNullOrWhiteSpace(options.RequestUri) &&
                   !string.IsNullOrWhiteSpace(options.SecretId) &&
                   !string.IsNullOrWhiteSpace(options.SecretKey) &&
                   !string.IsNullOrWhiteSpace(options.TopicId);
        }

        public static bool IsValid(this TencentCloudClsNativeConfig config)
        {
            if (config == null)
            {
                return false;
            }

            try
            {
                config.Check();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool IsValid(this TencentCloudClsNativeConfigWrapper config)
        {
            if (config == null)
            {
                return false;
            }

            try
            {
                config.Check();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static void Check(this TencentCloudClsNativeConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (string.IsNullOrWhiteSpace(config.RequestUri))
                throw new ArgumentNullException(nameof(config.RequestUri));

            if (string.IsNullOrWhiteSpace(config.SecretId))
                throw new ArgumentNullException(nameof(config.SecretId));

            if (string.IsNullOrWhiteSpace(config.SecretKey))
                throw new ArgumentNullException(nameof(config.SecretKey));

            if (string.IsNullOrWhiteSpace(config.TopicId))
                throw new ArgumentNullException(nameof(config.TopicId));
        }

        public static void Check(this TencentCloudClsNativeConfigWrapper config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (string.IsNullOrWhiteSpace(config.Key))
                throw new ArgumentNullException(nameof(config.Key));

            ((TencentCloudClsNativeConfig) config).Check();
        }
    }
}