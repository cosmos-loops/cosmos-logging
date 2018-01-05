using System.Threading.Tasks;
using Cosmos.Logging.Collectors;

namespace Cosmos.Logging.Core {
    public static class LogPayloadEmitter {
        public static void Emit(ILogPayloadSender logPayloadSender, ILogPayload payload) {
            if (logPayloadSender == null || payload == null) return;
            Task.Factory.StartNew(async () => await logPayloadSender.SendAsync(payload));
        }
    }
}