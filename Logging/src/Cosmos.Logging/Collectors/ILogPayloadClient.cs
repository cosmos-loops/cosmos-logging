using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Collectors {
    public interface ILogPayloadClient {
        Task WriteAsync(ILogPayload payload, CancellationToken cancellationToken = default(CancellationToken));
    }
}