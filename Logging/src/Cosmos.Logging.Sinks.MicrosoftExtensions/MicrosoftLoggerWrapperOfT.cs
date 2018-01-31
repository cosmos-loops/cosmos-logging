namespace Cosmos.Logging.Sinks.MicrosoftExtensions {
    public class MicrosoftLoggerWrapper<T> : MicrosoftLoggerWrapper {
        public MicrosoftLoggerWrapper(ILoggingServiceProvider loggerServiceProvider) : base(loggerServiceProvider?.GetLogger<T>()) { }
    }
}