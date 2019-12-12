using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Payloads {
    public interface ILogPayloadClient {
        Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default);
    }
}