using Cosmos.Logging.Extensions.Microsoft;

namespace Cosmos.Logging.Extensions.EntityFrameworkCore {
    public class EfCoreLoggerWrapper : MicrosoftLoggerWrapper {
        public EfCoreLoggerWrapper(ILogger logger) : base(logger) { }
    }
}