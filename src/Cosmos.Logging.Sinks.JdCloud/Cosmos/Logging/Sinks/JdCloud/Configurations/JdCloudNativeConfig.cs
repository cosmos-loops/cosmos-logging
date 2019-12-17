using System;

namespace Cosmos.Logging.Sinks.JdCloud.Configurations {
    /// <summary>
    /// JdCloud native config
    /// </summary>
    public class JdCloudNativeConfig {
        /// <summary>
        /// Gets or sets log stream name
        /// </summary>
        public string LogStreamName { get; set; }

        /// <summary>
        /// Gets or sets access key
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets secret key
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets security
        /// </summary>
        public bool Security { get; set; }

        /// <summary>
        /// Gets or sets retry times, default is 3
        /// </summary>
        public int RetryTimes { get; set; } = 3;

        /// <summary>
        /// Gets or sets request timeout, default is 5
        /// </summary>
        public int RequestTimeout { get; set; } = 5;

        /// <summary>
        /// Gets or sets is general client or not
        /// </summary>
        public virtual bool IsGeneralClient { get; set; }

        internal void SetMySelf(JdCloudNativeConfig config) {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            LogStreamName = config.LogStreamName;
            SecretKey = config.SecretKey;
            AccessKey = config.AccessKey;
            Security = config.Security;
            RetryTimes = config.RetryTimes;
            RequestTimeout = config.RequestTimeout;
            IsGeneralClient = config.IsGeneralClient;
        }
    }
}