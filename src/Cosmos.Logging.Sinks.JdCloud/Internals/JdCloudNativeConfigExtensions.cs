using System;
using System.Linq;
using Cosmos.Logging.Sinks.JdCloud.Configurations;

namespace Cosmos.Logging.Sinks.JdCloud.Internals
{
    internal static class JdCloudNativeConfigExtensions
    {
        public static bool HasLegalNativeConfig(this JdCloudLogSinkOptions options, bool onlyCheckCollConfig)
        {
            if (options == null)
                return false;

            if (options.JdCloudLogNativeConfigs.Any())
                return options.JdCloudLogNativeConfigs.All(o => !string.IsNullOrWhiteSpace(o.Key) && o.Value.IsValid());

            if (onlyCheckCollConfig)
                return false;

            return !string.IsNullOrWhiteSpace(options.LogStreamName) &&
                   !string.IsNullOrWhiteSpace(options.SecretKey) &&
                   !string.IsNullOrWhiteSpace(options.AccessKey);
        }

        public static bool IsValid(this JdCloudNativeConfig config)
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

        public static bool IsValid(this JdCloudNativeConfigWrapper config)
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

        public static void Check(this JdCloudNativeConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (string.IsNullOrWhiteSpace(config.LogStreamName))
                throw new ArgumentNullException(nameof(config.LogStreamName));

            if (string.IsNullOrWhiteSpace(config.AccessKey))
                throw new ArgumentNullException(nameof(config.AccessKey));

            if (string.IsNullOrWhiteSpace(config.SecretKey))
                throw new ArgumentNullException(nameof(config.SecretKey));
        }

        public static void Check(this JdCloudNativeConfigWrapper config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (string.IsNullOrWhiteSpace(config.Key))
                throw new ArgumentNullException(nameof(config.Key));

            ((JdCloudNativeConfig) config).Check();
        }
    }
}