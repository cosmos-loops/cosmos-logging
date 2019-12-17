using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Payloads {
    /// <summary>
    /// Log payload emitter
    /// </summary>
    public static class LogPayloadEmitter {
        /// <summary>
        /// Emit
        /// </summary>
        /// <param name="logPayloadSender"></param>
        /// <param name="payload"></param>
        public static void Emit(ILogPayloadSender logPayloadSender, ILogPayload payload) {
            if (logPayloadSender is null || payload is null) return;
            Task.Factory.StartNew(async () => await logPayloadSender.SendAsync(payload));
        }
    }
}