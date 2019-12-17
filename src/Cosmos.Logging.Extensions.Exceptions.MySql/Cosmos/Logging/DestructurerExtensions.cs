using Cosmos.Logging.Extensions.Exceptions.Configurations;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for destructurer
    /// </summary>
    public static class DestructurerExtensions {
        /// <summary>
        /// Use MySql
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static ExceptionOptions UseMySql(this ExceptionOptions options) {
            options.UseDestucturer<MySqlExceptionDestructurer>();
            return options;
        }
    }
}