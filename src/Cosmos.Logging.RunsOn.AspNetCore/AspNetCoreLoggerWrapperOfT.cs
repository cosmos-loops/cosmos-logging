namespace Cosmos.Logging.RunsOn.AspNetCore {
    public class AspNetCoreLoggerWrapper<T> : AspNetCoreLoggerWrapper, Microsoft.Extensions.Logging.ILogger<T> {

        public AspNetCoreLoggerWrapper(ILoggingServiceProvider provider) : base(provider?.GetLogger<T>()) { }

    }
}