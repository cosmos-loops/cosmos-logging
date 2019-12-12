using Cosmos.IdUtils;

namespace Cosmos.Logging.Trace {
    /// <summary>
    /// System trace id generator
    /// </summary>
    public class SystemTraceIdGenerator : ILogTraceIdGenerator {
        private readonly TraceIdAccessor _accessor;
        private readonly FallbackTraceIdAccessor _fallback;

        /// <inheritdoc />
        public SystemTraceIdGenerator(TraceIdAccessor traceIdAccessor, FallbackTraceIdAccessor fallbackTraceIdAccessor) {
            _accessor = traceIdAccessor;
            _fallback = fallbackTraceIdAccessor;
        }


        /// <inheritdoc />
        public string Create() {
            return _accessor?.GetTraceId() ?? _fallback.GetTraceId();
        }
    }
}