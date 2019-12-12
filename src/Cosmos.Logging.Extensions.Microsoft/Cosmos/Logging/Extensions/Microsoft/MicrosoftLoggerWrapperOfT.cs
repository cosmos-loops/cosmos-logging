namespace Cosmos.Logging.Extensions.Microsoft {
    /// <inheritdoc />
    public class MicrosoftLoggerWrapper<T> : MicrosoftLoggerWrapper {
        /// <inheritdoc />
        public MicrosoftLoggerWrapper(ILoggingServiceProvider loggerServiceProvider) : base(loggerServiceProvider?.GetLogger<T>()) { }
    }
}