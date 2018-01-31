using Cosmos.Logging.Sinks.MicrosoftExtensions;

namespace Cosmos.Logging.Sinks.EntityFrameworkCore {
    public class EfCoreLoggerWrapper : MicrosoftLoggerWrapper {
        public EfCoreLoggerWrapper(ILogger logger) : base(logger) { }
    }
}