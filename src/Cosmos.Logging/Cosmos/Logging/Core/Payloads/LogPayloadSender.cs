using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos.Logging.Core.Payloads {
    public sealed class LogPayloadSender : ILogPayloadSender {

        private readonly IEnumerable<ILogPayloadClientProvider> _logPayloadClientProviders;

        public LogPayloadSender(IEnumerable<ILogPayloadClientProvider> logPayloadClientProviders) {
            _logPayloadClientProviders = logPayloadClientProviders ?? throw new ArgumentNullException(nameof(logPayloadClientProviders));
        }

        public async Task SendAsync(ILogPayload payload, CancellationToken cancellationToken = default) {
            foreach (var provider in _logPayloadClientProviders) {
                await provider.GetClient().WriteAsync(payload, cancellationToken);
            }
        }
    }
}