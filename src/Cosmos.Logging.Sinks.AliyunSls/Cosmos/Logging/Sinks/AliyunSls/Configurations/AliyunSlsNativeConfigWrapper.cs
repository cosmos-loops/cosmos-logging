namespace Cosmos.Logging.Sinks.AliyunSls.Configurations {
    /// <summary>
    /// Wrapper of Aliyun SLS Native config
    /// </summary>
    public class AliyunSlsNativeConfigWrapper : AliyunSlsNativeConfig {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <inheritdoc />
        public override bool IsGeneralClient { get; set; } = true;
    }
}