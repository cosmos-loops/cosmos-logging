using FluentValidation;

namespace Cosmos.Extensions
{
    public static partial class FluentValidationExtensions
    {
        public static void RaiseExceptionIfLessThanOrEqualToZero<T>(this IRuleBuilder<T, int> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.GreaterThan(0).RaiseInternal(error);
        }

        public static void RaiseExceptionIfLessThanOrEqualToZero<T>(this IRuleBuilder<T, long> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.GreaterThan(0).RaiseInternal(error);
        }

        public static void RaiseExceptionIfLessThanOrEqualToZero<T>(this IRuleBuilder<T, double> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.GreaterThan(0).RaiseInternal(error);
        }

        public static void RaiseExceptionIfLessThanOrEqualToZero<T>(this IRuleBuilder<T, string> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.Must((t, v) => !v.IsNumberic() || v.CastToDecimal() > 0).RaiseInternal(error);
        }

        public static void RaiseExceptionIfLessThanZero<T>(this IRuleBuilder<T, int> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.GreaterThanOrEqualTo(0).RaiseInternal(error);
        }

        public static void RaiseExceptionIfLessThanZero<T>(this IRuleBuilder<T, long> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.GreaterThanOrEqualTo(0).RaiseInternal(error);
        }

        public static void RaiseExceptionIfLessThanZero<T>(this IRuleBuilder<T, double> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.GreaterThanOrEqualTo(0).RaiseInternal(error);
        }

        public static void RaiseExceptionIfLessThanZero<T>(this IRuleBuilder<T, string> ruleBuilder, (long, string, string) error)
        {
            ruleBuilder.Must((t, v) => !v.IsNumberic() || v.CastToDecimal() >= 0).RaiseInternal(error);
        }
    }
}