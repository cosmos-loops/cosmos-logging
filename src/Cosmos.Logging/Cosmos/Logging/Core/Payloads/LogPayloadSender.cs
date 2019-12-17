using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Payloads {
    /// <summary>
    /// Log payload sender
    /// </summary>
    public sealed class LogPayloadSender : ILogPayloadSender {

        private readonly IEnumerable<ILogPayloadClientProvider> _logPayloadClientProviders;

        /// <summary>
        /// Create a new instance of <see cref="LogPayloadSender"/>
        /// </summary>
        /// <param name="logPayloadClientProviders"></param>
        public LogPayloadSender(IEnumerable<ILogPayloadClientProvider> logPayloadClientProviders) {
            _logPayloadClientProviders = logPayloadClientProviders ?? throw new ArgumentNullException(nameof(logPayloadClientProviders));
        }

        /// <summary>
        /// Send async
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task SendAsync(ILogPayload payload, CancellationToken cancellationToken = default) {
            foreach (var provider in _logPayloadClientProviders) {
                await provider.GetClient().WriteAsync(payload, cancellationToken);
            }
        }
    }
}