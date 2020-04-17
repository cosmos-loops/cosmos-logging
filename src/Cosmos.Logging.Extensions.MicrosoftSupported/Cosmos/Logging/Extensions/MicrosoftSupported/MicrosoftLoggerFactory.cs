using System;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Extensions.MicrosoftSupported {
    /// <summary>
    /// Microsoft Logger factory
    /// </summary>
    public class MicrosoftLoggerFactory : ILoggerFactory {

        private readonly ILoggingServiceProvider _loggingServiceProvider;

        /// <summary>
        /// Create a new instance of <see cref="MicrosoftLoggerFactory"/>
        /// </summary>
        /// <param name="loggingServiceProvider"></param>
        public MicrosoftLoggerFactory(ILoggingServiceProvider loggingServiceProvider) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
        }

        /// <inheritdoc />
        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName) {
            return new MicrosoftLoggerAdapter(_loggingServiceProvider, categoryName);
        }

        /// <inheritdoc />
        public void AddProvider(ILoggerProvider provider) { }

        /// <inheritdoc />
        public void Dispose() { }
    }
}