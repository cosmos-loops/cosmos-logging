namespace Cosmos.Logging.Trace {
    /// <summary>
    /// Interface for Cosmos Logging trace id generator
    /// </summary>
    public interface ILogTraceIdGenerator {
        /// <summary>
        /// Create trace id
        /// </summary>
        /// <returns></returns>
        string Create();
    }
}