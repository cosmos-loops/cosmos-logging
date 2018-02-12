using Cosmos.Logging.Extensions.Microsoft;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    public class AspNetCoreLoggerWrapper : MicrosoftLoggerWrapper {
        public AspNetCoreLoggerWrapper(ILoggingServiceProvider loggerServiceProvider, string categoryName) : base(loggerServiceProvider, categoryName) { }

        public AspNetCoreLoggerWrapper(ILogger logger) : base(logger) { }

        internal ILogger ExposeLogger() => _logger;
    }
}