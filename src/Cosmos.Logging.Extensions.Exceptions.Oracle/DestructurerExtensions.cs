using Cosmos.Logging.Extensions.Exceptions.Configurations;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public static class DestructurerExtensions
    {
        public static ExceptionOptions UseOracle(this ExceptionOptions options)
        {
            options.UseDestucturer<OracleExceptionDestructurer>();
            options.UseDestucturer<OracleLpExceptionDestructurer>();
            options.UseDestucturer<OracleTypeExceptionDestructurer>();
            return options;
        }
    }
}