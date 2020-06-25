using Cosmos.Logging.Extensions.MicrosoftSupported;

namespace Cosmos.Logging.Extensions.EntityFrameworkCore {
    /// <summary>
    /// Microsoft EntityFrameworkCore Logger wrapper
    /// </summary>
    public class EfCoreLoggerAdapter : MicrosoftLoggerAdapter {
        /// <inheritdoc />
        public EfCoreLoggerAdapter(ILogger logger) : base(logger) { }
    }
}