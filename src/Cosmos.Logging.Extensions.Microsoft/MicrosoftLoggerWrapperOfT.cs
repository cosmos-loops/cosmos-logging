namespace Cosmos.Logging.Extensions.Microsoft {
    public class MicrosoftLoggerWrapper<T> : MicrosoftLoggerWrapper {
        public MicrosoftLoggerWrapper(ILoggingServiceProvider loggerServiceProvider) : base(loggerServiceProvider?.GetLogger<T>()) { }
    }
}