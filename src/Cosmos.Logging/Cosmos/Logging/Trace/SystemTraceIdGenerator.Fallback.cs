using Cosmos.IdUtils;

namespace Cosmos.Logging.Trace {
    /// <summary>
    /// Fallback trace id accessor
    /// </summary>
    public class FallbackTraceIdAccessor {
        private static readonly ITraceIdMaker DefaultMaker = new DefaultTraceIdMaker();
        private readonly string _id;

        /// <summary>
        /// Create a new <see cref="TraceIdAccessor"/> instance.
        /// </summary>
        public FallbackTraceIdAccessor() {
            _id = DefaultMaker.CreateId();
        }

        /// <summary>
        /// Get Trace Id
        /// </summary>
        /// <returns></returns>
        public string GetTraceId() => _id;
    }
}