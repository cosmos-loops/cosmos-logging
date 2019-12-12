using Cosmos.Logging.Extensions.Exceptions.Configurations;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for destructurer
    /// </summary>
    public static class DestructurerExtensions {
        /// <summary>
        /// Use MySqlConnector
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static ExceptionOptions UseMySqlConnector(this ExceptionOptions options) {
            options.UseDestucturer<MySqlConnectorExceptionDestructurer>();
            return options;
        }
    }
}