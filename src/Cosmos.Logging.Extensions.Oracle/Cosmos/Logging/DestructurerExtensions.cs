using Cosmos.Logging.Exceptions.Configurations;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for destructurer
    /// </summary>
    public static class DestructurerExtensions {
        /// <summary>
        /// Use Oracle
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static ExceptionOptions UseOracle(this ExceptionOptions options) {
            options.UseDestucturer<OracleExceptionDestructurer>();
            options.UseDestucturer<OracleLpExceptionDestructurer>();
            options.UseDestucturer<OracleTypeExceptionDestructurer>();
            return options;
        }
    }
}