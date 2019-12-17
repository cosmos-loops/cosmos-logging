namespace Cosmos.Logging.Extensions.PostgreSql {
    /// <summary>
    /// Proxy for PostgreSql Logger
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PostgreSqlLoggerProxy<T> : PostgreSqlLoggerProxy {
        /// <inheritdoc />
        public PostgreSqlLoggerProxy(ILoggingServiceProvider loggerServiceProvider) : base(loggerServiceProvider?.GetLogger<T>()) { }
    }
}