using System;

namespace Cosmos.Logging.Sinks.TencentCloudCls.Configurations
{
    public class TencentCloudClsNativeConfig
    {
        public string RequestUri { get; set; }

        public string SecretId { get; set; }

        public string SecretKey { get; set; }

        public string TopicId { get; set; }

        public int RequestTimeout { get; set; } = 5;

        public virtual bool IsGeneralClient { get; set; }

        internal void SetMySelf(TencentCloudClsNativeConfig config)
        {
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