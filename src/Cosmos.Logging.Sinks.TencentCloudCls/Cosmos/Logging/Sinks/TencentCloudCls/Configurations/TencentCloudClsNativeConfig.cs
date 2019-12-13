using System;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Configurations {
    /// <summary>
    /// Tencent Cloud CLS native config
    /// </summary>
    public class TencentCloudClsNativeConfig {
        /// <summary>
        /// Gets or sets request Uri
        /// </summary>
        public string RequestUri { get; set; }

        /// <summary>
        /// Gets or sets secret id
        /// </summary>
        public string SecretId { get; set; }

        /// <summary>
        /// Gets or sets secret key
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Gets or sets topic id
        /// </summary>
        public string TopicId { get; set; }

        /// <summary>
        /// Gets or sets request timeout, default is 5
        /// </summary>
        public int RequestTimeout { get; set; } = 5;

        /// <summary>
        /// Is general client or not
        /// </summary>
        public virtual bool IsGeneralClient { get; set; }

        internal void SetMySelf(TencentCloudClsNativeConfig config) {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            RequestUri = config.RequestUri;
            SecretId = config.SecretId;
            SecretKey = config.SecretKey;
            TopicId = config.TopicId;
            RequestTimeout = config.RequestTimeout;
            IsGeneralClient = config.IsGeneralClient;
        }
    }
}