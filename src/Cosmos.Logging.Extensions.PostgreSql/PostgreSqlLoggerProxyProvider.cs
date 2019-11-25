using System;
using Npgsql.Logging;

namespace Cosmos.Logging.Extensions.PostgreSql
{
    public class PostgreSqlLoggerProxyProvider : INpgsqlLoggingProvider
    {
        private readonly ILoggingServiceProvider _loggingServiceProvider;

        public PostgreSqlLoggerProxyProvider(ILoggingServiceProvider loggingServiceProvider)
        {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
        }

        public NpgsqlLogger CreateLogger(string name)
        {
            return new PostgreSqlLoggerProxy(_loggingServiceProvider, name);
        }
    }
}