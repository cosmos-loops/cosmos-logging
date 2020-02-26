namespace Cosmos.Logging.Extensions.MicrosoftSupported {
    /// <inheritdoc />
    public class MicrosoftLoggerAdapter<T> : MicrosoftLoggerAdapter {
        /// <inheritdoc />
        public MicrosoftLoggerAdapter(ILoggingServiceProvider loggerServiceProvider) : base(loggerServiceProvider?.GetLogger<T>()) { }
    }
}