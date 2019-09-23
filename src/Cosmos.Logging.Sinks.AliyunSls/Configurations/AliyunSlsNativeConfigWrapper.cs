namespace Cosmos.Logging.Sinks.AliyunSls.Configurations
{
    public class AliyunSlsNativeConfigWrapper : AliyunSlsNativeConfig
    {
        public string Key { get; set; }

        public override bool IsGeneralClient { get; set; } = true;
    }
}