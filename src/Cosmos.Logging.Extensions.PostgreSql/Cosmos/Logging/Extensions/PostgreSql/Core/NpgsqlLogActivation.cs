using System;
using Microsoft.Extensions.Options;
using Npgsql.Logging;

namespace Cosmos.Logging.Extensions.PostgreSql.Core {
    /// <summary>
    /// Npgsql log activation
    /// </summary>
    public class NpgsqlLogActivation {
        private readonly ILoggingServiceProvider _loggingServiceProvider;
        private readonly PostgresEnricherOptions _options;

        /// <inheritdoc />
        public NpgsqlLogActivation(ILoggingServiceProvider loggingServiceProvider, IOptions<PostgresEnricherOptions> settings) {
            _loggingServiceProvider = loggingServiceProvider ?? throw new ArgumentNullException(nameof(loggingServiceProvider));
            _options = settings?.Value ?? throw new ArgumentNullException(nameof(settings));
        }

        internal void Invoke() {
            NpgsqlLogManager.Provider = new PostgreSqlLoggerProxyProvider(_loggingServiceProvider);
            NpgsqlLogManager.IsParameterLoggingEnabled = _options.FinalParameterLoggingEnable;
        }
    }
}