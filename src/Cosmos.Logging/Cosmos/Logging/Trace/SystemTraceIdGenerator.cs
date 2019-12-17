using Cosmos.IdUtils;

namespace Cosmos.Logging.Trace {
    /// <summary>
    /// System trace id generator
    /// </summary>
    public class SystemTraceIdGenerator : ILogTraceIdGenerator {
        private readonly TraceIdAccessor _accessor;
        private readonly FallbackTraceIdAccessor _fallback;

        /// <summary>
        /// Create a new instance of <see cref="SystemTraceIdGenerator"/>.
        /// </summary>
        /// <param name="traceIdAccessor"></param>
        /// <param name="fallbackTraceIdAccessor"></param>
        public SystemTraceIdGenerator(TraceIdAccessor traceIdAccessor, FallbackTraceIdAccessor fallbackTraceIdAccessor) {
            _accessor = traceIdAccessor;
            _fallback = fallbackTraceIdAccessor;
        }


        /// <inheritdoc />
        public string Create() {
            return _accessor?.GetTraceId() ?? _fallback.GetTraceId();
        }

        // ReSharper disable once InconsistentNaming
        private static readonly SystemTraceIdGenerator _fallbackTraceIdGenerator = new SystemTraceIdGenerator(null, new FallbackTraceIdAccessor());

        /// <summary>
        /// Fallback log trace id generator
        /// </summary>
        internal static ILogTraceIdGenerator Fallback => _fallbackTraceIdGenerator;
    }
}