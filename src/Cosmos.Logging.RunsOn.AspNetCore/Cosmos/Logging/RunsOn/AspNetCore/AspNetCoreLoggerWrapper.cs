using Cosmos.Logging.Extensions.Microsoft;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    /// <summary>
    /// ASP.NET Core Logging wrapper
    /// </summary>
    public class AspNetCoreLoggerWrapper : MicrosoftLoggerWrapper {
        /// <inheritdoc />
        public AspNetCoreLoggerWrapper(ILoggingServiceProvider loggerServiceProvider, string categoryName) : base(loggerServiceProvider, categoryName) { }

        /// <inheritdoc />
        public AspNetCoreLoggerWrapper(ILogger logger) : base(logger) { }

        internal ILogger ExposeLogger() => _logger;
    }
}