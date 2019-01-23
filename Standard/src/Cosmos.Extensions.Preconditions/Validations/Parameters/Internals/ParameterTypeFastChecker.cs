using AspectCore.DynamicProxy.Parameters;
using Cosmos.Conversions;

namespace Cosmos.Validations.Parameters.Internals
{
    internal static class ParameterTypeFastChecker
    {
        public static ParameterTypeValidation IsIntType(this Parameter parameter)
        {
            var parameterType = TypeConversion.ToSafeNonNullableType(parameter.Type);
            return new ParameterTypeValidation(parameterType == TypeClass.IntClass, parameterType);
        }

        public static ParameterTypeValidation IsLongType(this Parameter parameter)
        {
            var parameterType = TypeConversion.ToSafeNonNullableType(parameter.Type);
            return new ParameterTypeValidation(parameterType == TypeClass.LongClass, parameterType);
        }

        public static ParameterTypeValidation IsFloatType(this Parameter parameter)
        {
            var parameterType = TypeConversion.ToSafeNonNullableType(parameter.Type);
            return new ParameterTypeValidation(parameterType == TypeClass.FloatClass, parameterType);
        }

        public static ParameterTypeValidation IsDoubleType(this Parameter parameter)
        {
            var parameterType = TypeConversion.ToSafeNonNullableType(parameter.Type);
            return new ParameterTypeValidation(parameterType == TypeClass.DoubleClass, parameterType);
        }

        public static ParameterTypeValidation IsDecimalType(this Parameter parameter)
        {
            var parameterType = TypeConversion.ToSafeNonNullableType(parameter.Type);
            return new ParameterTypeValidation(parameterType == TypeClass.DecimalClass, parameterType);
        }

        public static ParameterTypeValidation IsDateTimeType(this Parameter parameter)
        {
            var parameterType = TypeConversion.ToSafeNonNullableType(parameter.Type);
            return new ParameterTypeValidation(parameterType == TypeClass.DateTimeClass, parameterType);
        }

        public static ParameterTypeValidation IsTimeSpanType(this Parameter parameter)
        {
            var parameterType = TypeConversion.ToSafeNonNullableType(parameter.Type);
            return new ParameterTypeValidation(parameterType == TypeClass.TimeSpanClass, parameterType);
        }


    }
}