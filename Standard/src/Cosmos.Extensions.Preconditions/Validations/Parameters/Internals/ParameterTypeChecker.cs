using System;
using AspectCore.DynamicProxy.Parameters;

namespace Cosmos.Validations.Parameters.Internals
{
    internal static class ParameterTypeChecker
    {
        public static ParameterTypeValidation Is(this Parameter parameter, Type targetType)
        {
            var parameterType = parameter.Type;
            return new ParameterTypeValidation(parameterType == targetType, parameterType);
        }

        public static ParameterTypeValidation IsNot(this Parameter parameter, Type targetType)
        {
            var parameterType = parameter.Type;
            return new ParameterTypeValidation(parameterType != targetType, parameterType);
        }

        public static ParameterTypeValidation Is<T>(this Parameter parameter)
        {
            return parameter.Is(typeof(T));
        }

        public static ParameterTypeValidation IsNot<T>(this Parameter parameter)
        {
            return parameter.IsNot(typeof(T));
        }

        public static ParameterTypeValidation Or(this ParameterTypeValidation result, Type targetType)
        {
            return result ? result : new ParameterTypeValidation(result.ParameterType == targetType, result.ParameterType);
        }

        public static ParameterTypeValidation Or<T>(this ParameterTypeValidation result)
        {
            return result.Or(typeof(T));
        }

        public static ParameterTypeValidation OrNot(this ParameterTypeValidation result, Type targetType)
        {
            return result ? result : new ParameterTypeValidation(result.ParameterType != targetType, result.ParameterType);
        }

        public static ParameterTypeValidation OrNot<T>(this ParameterTypeValidation result)
        {
            return result.OrNot(typeof(T));
        }
    }
}