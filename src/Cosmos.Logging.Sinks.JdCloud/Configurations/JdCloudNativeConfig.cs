using System;

namespace Cosmos.Logging.Sinks.JdCloud.Configurations
{
    public class JdCloudNativeConfig
    {
        public string LogStreamName { get; set; }
        
        public string AccessKey { get; set; }

        public string SecretKey { get; set; }

        public bool Security { get; set; }

        public int RetryTimes { get; set; } = 3;

        public int RequestTimeout { get; set; } = 5;
        public virtual bool IsGeneralClient { get; set; }

        internal void SetMySelf(JdCloudNativeConfig config)
        {
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