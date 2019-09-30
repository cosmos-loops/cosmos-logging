namespace Cosmos.Logging.Sinks.TencentCloudCls.Configurations
{
    public class TencentCloudClsNativeConfigWrapper : TencentCloudClsNativeConfig
    {
        public string Key { get; set; }

        public override bool IsGeneralClient { get; set; } = true;
    }
}