using Cosmos.Logging.Trace;
using Microsoft.AspNetCore.Http;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    /// <summary>
    /// ASP.NET Core Trace id generator
    /// </summary>
    public class AspNetCoreTraceIdGenerator : ILogTraceIdGenerator {
        private readonly IHttpContextAccessor _accessor;

        /// <summary>
        /// Create a new instance of <see cref="AspNetCoreTraceIdGenerator"/>
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public AspNetCoreTraceIdGenerator(IHttpContextAccessor httpContextAccessor) {
            _accessor = httpContextAccessor;
        }

        /// <inheritdoc />
        public string Create() {
            return _accessor?.HttpContext.TraceIdentifier ?? string.Empty;
        }
    }
}