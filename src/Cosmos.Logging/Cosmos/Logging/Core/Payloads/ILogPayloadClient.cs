using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Payloads {
    /// <summary>
    /// Interface for log payload client
    /// </summary>
    public interface ILogPayloadClient {
        /// <summary>
        /// Write async
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default);
    }
}