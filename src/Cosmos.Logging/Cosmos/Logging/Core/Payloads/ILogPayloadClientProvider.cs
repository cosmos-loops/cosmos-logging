namespace Cosmos.Logging.Core.Payloads {
    /// <summary>
    /// Interface for payload client provider
    /// </summary>
    public interface ILogPayloadClientProvider {
        /// <summary>
        /// Get client
        /// </summary>
        /// <returns></returns>
        ILogPayloadClient GetClient();
    }
}