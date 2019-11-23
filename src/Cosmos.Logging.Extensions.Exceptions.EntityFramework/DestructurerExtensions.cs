using Cosmos.Logging.Extensions.Exceptions.Configurations;
using Cosmos.Logging.Extensions.Exceptions.Destructurers;

// ReSharper disable once CheckNamespace
namespace Cosmos.Logging
{
    public static class DestructurerExtensions
    {
        public static ExceptionOptions UseEntityFramework(this ExceptionOptions options)
        {
            options.UseDestucturer<EfDbUpdateExceptionDestructurer>();
            return options;
        }
    }
}