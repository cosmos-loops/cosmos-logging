using System;

namespace Cosmos.Logging.Sinks.AliyunSls.Configurations {
    /// <summary>
    /// Aliyun SLS native config
    /// </summary>
    public class AliyunSlsNativeConfig {
        /// <summary>
        /// Gets or sets log store name
        /// </summary>
        public string LogStoreName { get; set; }

        /// <summary>
        /// Gets or sets end point
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Gets or sets project name
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets AccessKeyId
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// Gets or sets AccessKey
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Gets or sets timeout value
        /// </summary>
        public int Timeout { get; set; } = 1000;

        #region Proxy

        /// <summary>
        /// Use proxy or not
        /// </summary>
        public bool UseProxy { get; set; }

        /// <summary>
        /// Proxy host
        /// </summary>
        public string ProxyHost { get; set; }

        /// <summary>
        /// Proxy port
        /// </summary>
        public int? ProxyPort { get; set; }

        /// <summary>
        /// Proxy user name
        /// </summary>
        public string ProxyUserName { get; set; }

        /// <summary>
        /// Proxy password
        /// </summary>
        public string ProxyPassword { get; set; }

        /// <summary>
        /// Proxy domain
        /// </summary>
        public string ProxyDomain { get; set; }

        /// <summary>
        /// Proxy user enabled
        /// </summary>
        public bool ProxyUserEnabled
            => !string.IsNullOrWhiteSpace(ProxyHost) &&
               !string.IsNullOrWhiteSpace(ProxyUserName) &&
               !string.IsNullOrWhiteSpace(ProxyPassword);

        #endregion

        /// <summary>
        /// Is general client or not
        /// </summary>
        public virtual bool IsGeneralClient { get; set; }

        internal void SetMySelf(AliyunSlsNativeConfig config) {
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