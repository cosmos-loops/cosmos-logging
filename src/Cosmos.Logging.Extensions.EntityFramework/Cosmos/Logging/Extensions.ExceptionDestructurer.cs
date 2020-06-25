using Cosmos.Logging.Exceptions.Configurations;
using Cosmos.Logging.Extensions.EntityFramework.Exceptions.Destructurers;

namespace Cosmos.Logging {
    /// <summary>
    /// Extensions for destructurer
    /// </summary>
    public static class ExceptionDestructurerExtensions {
        /// <summary>
        /// Use EntityFramework
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static ExceptionOptions UseEntityFramework(this ExceptionOptions options) {
            options.UseDestucturer<EfDbUpdateExceptionDestructurer>();
            return options;
        }
    }
}