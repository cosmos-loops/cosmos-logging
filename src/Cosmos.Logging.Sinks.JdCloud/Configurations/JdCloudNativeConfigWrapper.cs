namespace Cosmos.Logging.Sinks.JdCloud.Configurations
{
    public class JdCloudNativeConfigWrapper : JdCloudNativeConfig
    {
        public string Key { get; set; }

        public override bool IsGeneralClient { get; set; } = true;
    }
}