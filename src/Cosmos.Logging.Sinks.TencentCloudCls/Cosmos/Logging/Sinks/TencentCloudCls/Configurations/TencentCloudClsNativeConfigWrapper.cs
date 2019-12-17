namespace Cosmos.Logging.Sinks.TencentCloudCls.Configurations {
    /// <summary>
    /// Wrapper of Tencent Cloud CLS native config
    /// </summary>
    public class TencentCloudClsNativeConfigWrapper : TencentCloudClsNativeConfig {
        /// <summary>
        /// Gets or sets key
        /// </summary>
        public string Key { get; set; }

        /// <inheritdoc />
        public override bool IsGeneralClient { get; set; } = true;
    }
}