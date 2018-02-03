using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Payloads {
    public static class LogPayloadEmitter {
        public static void Emit(ILogPayloadSender logPayloadSender, ILogPayload payload) {
            if (logPayloadSender == null || payload == null) return;
            Task.Factory.StartNew(async () => await logPayloadSender.SendAsync(payload));
        }
    }
}