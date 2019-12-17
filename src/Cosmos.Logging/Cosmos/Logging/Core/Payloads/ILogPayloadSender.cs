using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Payloads {
    /// <summary>
    /// Interface for log payload sender
    /// </summary>
    public interface ILogPayloadSender {
        /// <summary>
        /// Send async
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SendAsync(ILogPayload payload, CancellationToken cancellationToken = default(CancellationToken));
    }
}