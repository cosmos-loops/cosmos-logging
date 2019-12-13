namespace Cosmos.Logging.RunsOn.AspNetCore {
    /// <summary>
    /// ASP.NET Core Logger Wrapper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AspNetCoreLoggerWrapper<T> : AspNetCoreLoggerWrapper, Microsoft.Extensions.Logging.ILogger<T> {

        /// <inheritdoc />
        public AspNetCoreLoggerWrapper(ILoggingServiceProvider provider) : base(provider?.GetLogger<T>()) { }

    }
}