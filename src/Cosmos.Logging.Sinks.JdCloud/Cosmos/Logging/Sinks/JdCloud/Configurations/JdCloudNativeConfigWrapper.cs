namespace Cosmos.Logging.Sinks.JdCloud.Configurations {
    /// <summary>
    /// Wrapper for JdCloud native config
    /// </summary>
    public class JdCloudNativeConfigWrapper : JdCloudNativeConfig {
        /// <summary>
        /// Gets or sets key
        /// </summary>
        public string Key { get; set; }

        /// <inheritdoc />
        public override bool IsGeneralClient { get; set; } = true;
    }
}