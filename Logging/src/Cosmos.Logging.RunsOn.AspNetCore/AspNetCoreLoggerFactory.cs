using System;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    public class AspNetCoreLoggerFactory : ILoggerFactory {

        private readonly ILoggingServiceProvider _loggingServiceProvider;

        public AspNetCoreLoggerFactory(ILoggingServiceProvider loggingServiceProvider) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
        }

        public Microsoft.Extensions.Logging.ILogger CreateLogger(string categoryName) {
            return new AspNetCoreLoggerWrapper(_loggingServiceProvider, categoryName);
        }

        public void AddProvider(ILoggerProvider provider) { }

        public void Dispose() { }
    }
}