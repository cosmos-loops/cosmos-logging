using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Collectors {
    public interface ILogPayloadSender {
        Task SendAsync(ILogPayload payload, CancellationToken cancellationToken = default(CancellationToken));
    }
}