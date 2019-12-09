using CorrelationId;
using Cosmos.Logging.Trace;

namespace Cosmos.Logging.Extensions.CorrelationId {
    public class CorrelationIdGenerator : ILogTraceIdGenerator {
        private readonly ICorrelationContextAccessor _accessor;

        /// <inheritdoc />
        public CorrelationIdGenerator(ICorrelationContextAccessor correlationContextAccessor) {
            _accessor = correlationContextAccessor;
        }

        public string Create() {
            return _accessor.CorrelationContext.CorrelationId;
        }
    }
}