using System;
using System.Linq;
using Cosmos.Logging.Sinks.AliyunSls.Configurations;

namespace Cosmos.Logging.Sinks.AliyunSls.Internals {
    internal static class AliyunSlsNativeConfigExtensions {
        public static bool HasLegalNativeConfig(this AliyunSlsSinkOptions options, bool onlyCheckCollConfig) {
            if (options == null)
                return false;

            if (options.AliyunSlsNativeConfigs.Any())
                return options.AliyunSlsNativeConfigs.All(o => !string.IsNullOrWhiteSpace(o.Key) && o.Value.IsValid());

            if (onlyCheckCollConfig)
                return false;

            return !string.IsNullOrWhiteSpace(options.LogStoreName) &&
                   !string.IsNullOrWhiteSpace(options.EndPoint) &&
                   !string.IsNullOrWhiteSpace(options.ProjectName) &&
                   !string.IsNullOrWhiteSpace(options.AccessKeyId) &&
                   !string.IsNullOrWhiteSpace(options.AccessKey);
        }

        public static bool IsValid(this AliyunSlsNativeConfig config) {
            if (config == null) {
                return false;
            }

            try {
                config.Check();
            }
            catch {
                return false;
            }

            return true;
        }

        public static bool IsValid(this AliyunSlsNativeConfigWrapper config) {
            if (config == null) {
                return false;
            }

            try {
                config.Check();
            }
            catch {
                return false;
            }

            return true;
        }

        public static void Check(this AliyunSlsNativeConfig config) {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (string.IsNullOrWhiteSpace(config.LogStoreName))
                throw new ArgumentNullException(nameof(config.LogStoreName));

            if (string.IsNullOrWhiteSpace(config.EndPoint))
                throw new ArgumentNullException(nameof(config.EndPoint));

            if (string.IsNullOrWhiteSpace(config.ProjectName))
                throw new ArgumentNullException(nameof(config.ProjectName));

            if (string.IsNullOrWhiteSpace(config.AccessKeyId))
                throw new ArgumentNullException(nameof(config.AccessKeyId));

            if (string.IsNullOrWhiteSpace(config.AccessKey))
                throw new ArgumentNullException(nameof(config.AccessKey));
        }

        public static void Check(this AliyunSlsNativeConfigWrapper config) {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            if (string.IsNullOrWhiteSpace(config.Key))
                throw new ArgumentNullException(nameof(config.Key));

            ((AliyunSlsNativeConfig) config).Check();
        }
    }
}