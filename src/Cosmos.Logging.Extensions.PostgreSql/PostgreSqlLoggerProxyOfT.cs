namespace Cosmos.Logging.Extensions.PostgreSql {
    public class PostgreSqlLoggerProxy<T> : PostgreSqlLoggerProxy {
        public PostgreSqlLoggerProxy(ILoggingServiceProvider loggerServiceProvider) : base(loggerServiceProvider?.GetLogger<T>()) { }
    }
}