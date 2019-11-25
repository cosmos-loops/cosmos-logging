using System;

namespace Cosmos.Logging.Extensions.PostgreSql.Core
{
    internal static class PostgresOptionsHelper
    {
        public static bool GetFinalParameterEnable(PostgresEnricherOptions options, PostgresEnricherConfiguration configuration)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            if (options.IsParameterLoggingEnable.HasValue)
                return options.IsParameterLoggingEnable.Value;

            if (configuration.IsParameterLoggingEnable.HasValue)
                return configuration.IsParameterLoggingEnable.Value;
            
            return false;
        }
    }
}