using System;

namespace Cosmos.Validations.Parameters.Internals
{
    internal static class ParameterTypeSimpleChecker
    {
        public static bool Is(this Type parameterType, Type targetType) => parameterType == targetType;

        public static bool IsNot(this Type parameterType, Type targetType) => parameterType != targetType;

        public static bool Is<T>(this Type parameterType) => parameterType == typeof(T);

        public static bool IsNot<T>(this Type parameterType) => parameterType != typeof(T);
    }
}