using Cosmos.Logging.Extensions.Microsoft;

namespace Cosmos.Logging.Extensions.EntityFrameworkCore {
    /// <summary>
    /// Microsoft EntityFrameworkCore Logger wrapper
    /// </summary>
    public class EfCoreLoggerWrapper : MicrosoftLoggerWrapper {
        /// <inheritdoc />
        public EfCoreLoggerWrapper(ILogger logger) : base(logger) { }
    }
}