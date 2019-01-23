using FluentValidation;

namespace Cosmos.Extensions
{
    public static partial class FluentValidationExtensions
    {
        private static void RaiseInternal<T, Tproperty>(this IRuleBuilderOptions<T, Tproperty> options, (long, string, string) error)
        {
            options
                .WithErrorCode($"{error.Item1}")
                .WithName(error.Item2)
                .WithMessage(error.Item3);
        }
    }
}