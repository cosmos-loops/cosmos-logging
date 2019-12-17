using Cosmos.Logging.Extensions.Exceptions.Configurations;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for destructurer
    /// </summary>
    public static class DestructurerExtensions {
        /// <summary>
        /// Use Postgres
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static ExceptionOptions UsePostgreSql(this ExceptionOptions options) {
            options.UseDestucturer<NpgsqlExceptionDestructurer>();
            options.UseDestucturer<PostgresExceptionDestructurer>();
            return options;
        }
    }
}