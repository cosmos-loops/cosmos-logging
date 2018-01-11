namespace Cosmos.Logging.Collectors {
    public interface ILogPayloadClientProvider {
        ILogPayloadClient GetClient();
    }
}