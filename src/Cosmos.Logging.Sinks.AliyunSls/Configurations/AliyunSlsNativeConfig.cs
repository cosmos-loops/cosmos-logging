using System;

namespace Cosmos.Logging.Sinks.AliyunSls.Configurations
{
    public class AliyunSlsNativeConfig
    {
        public string LogStoreName { get; set; }

        public string EndPoint { get; set; }

        public string ProjectName { get; set; }

        public string AccessKeyId { get; set; }

        public string AccessKey { get; set; }

        public int Timeout { get; set; } = 1000;

        #region Proxy

        public bool UseProxy { get; set; }

        public string ProxyHost { get; set; }

        public int? ProxyPort { get; set; }

        public string ProxyUserName { get; set; }

        public string ProxyPassword { get; set; }

        public string ProxyDomain { get; set; } = null;

        public bool ProxyUserEnabled
            => !string.IsNullOrWhiteSpace(ProxyHost) &&
               !string.IsNullOrWhiteSpace(ProxyUserName) &&
               !string.IsNullOrWhiteSpace(ProxyPassword);

        #endregion

        public virtual bool IsGeneralClient { get; set; }

        internal void SetMySelf(AliyunSlsNativeConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            LogStoreName = config.LogStoreName;
            EndPoint = config.EndPoint;
            ProjectName = config.ProjectName;
            AccessKeyId = config.AccessKeyId;
            AccessKey = config.AccessKey;
            Timeout = config.Timeout;
            UseProxy = config.UseProxy;
            ProxyHost = config.ProxyHost;
            ProxyPort = config.ProxyPort;
            ProxyUserName = config.ProxyUserName;
            ProxyPassword = config.ProxyPassword;
            ProxyDomain = config.ProxyDomain;
            IsGeneralClient = config.IsGeneralClient;
        }
    }
}