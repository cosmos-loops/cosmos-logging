using System;
using Npgsql.Logging;

namespace Cosmos.Logging.Extensions.PostgreSql {
    /// <summary>
    /// Proxy provider for PostgreSql Logger
    /// </summary>
    public class PostgreSqlLoggerProxyProvider : INpgsqlLoggingProvider {
        private readonly ILoggingServiceProvider _loggingServiceProvider;

        /// <inheritdoc />
        public PostgreSqlLoggerProxyProvider(ILoggingServiceProvider loggingServiceProvider) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
        }

        /// <inheritdoc />
        public NpgsqlLogger CreateLogger(string name) {
            return new PostgreSqlLoggerProxy(_loggingServiceProvider, name);
        }
    }
}