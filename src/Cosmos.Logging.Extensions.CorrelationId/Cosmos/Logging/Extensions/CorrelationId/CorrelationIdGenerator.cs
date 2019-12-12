using CorrelationId;
using Cosmos.Logging.Trace;

namespace Cosmos.Logging.Extensions.CorrelationId {
    /// <summary>
    /// Corrlation Id generator
    /// </summary>
    public class CorrelationIdGenerator : ILogTraceIdGenerator {
        private readonly ICorrelationContextAccessor _accessor;

        /// <inheritdoc />
        public CorrelationIdGenerator(ICorrelationContextAccessor correlationContextAccessor) {
            _accessor = correlationContextAccessor;
        }

        /// <inheritdoc />
        public string Create() {
            return _accessor.CorrelationContext.CorrelationId;
        }
    }
}