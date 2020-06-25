using Cosmos.Logging.Exceptions.Configurations;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for destructurer
    /// </summary>
    public static class DestructurerExtensions {
        /// <summary>
        /// Use MSSQL
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static ExceptionOptions UseSqlServer(this ExceptionOptions options) {
            options.UseDestucturer<SqlExceptionDestructurer>();
            return options;
        }
    }
}