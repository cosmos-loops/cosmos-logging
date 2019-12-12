namespace Cosmos.Logging.Core.Payloads {
    public interface ILogPayloadClientProvider {
        ILogPayloadClient GetClient();
    }
}