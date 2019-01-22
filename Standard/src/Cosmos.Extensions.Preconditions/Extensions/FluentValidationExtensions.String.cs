using FluentValidation;

namespace Cosmos.Extensions
{
    public static partial class FluentValidationExtensions
    {
        public static void RaiseExceptionIfEmpty<T>(this IRuleBuilder<T, string> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.NotEmpty().RaiseInternal(error);
        }
    }
}