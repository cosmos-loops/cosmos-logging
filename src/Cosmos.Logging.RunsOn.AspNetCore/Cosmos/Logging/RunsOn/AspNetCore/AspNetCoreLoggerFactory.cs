using System;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    /// <summary>
    /// ASP.NET Core Logger factory
    /// </summary>
    public class AspNetCoreLoggerFactory : ILoggerFactory {

        private readonly ILoggingServiceProvider _loggingServiceProvider;

        /// <summary>
        /// Create a new instance of <see cref="AspNetCoreLoggerFactory"/>
        /// </summary>
        /// <param name="loggingServiceProvider"></param>
        public AspNetCoreLoggerFactory(ILoggingServiceProvider loggingServiceProvider) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
        }

        /// <inheritdoc />
        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName) {
            return new AspNetCoreLoggerWrapper(_loggingServiceProvider, categoryName);
        }

        /// <inheritdoc />
        public void AddProvider(ILoggerProvider provider) { }

        /// <inheritdoc />
        public void Dispose() { }
    }
}