using System;
using AspectCore.Extensions.Reflection;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ReflectionExtensions
    {
        public static bool IsDefined<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return type.GetReflector().IsDefined<TAttribute>();
        }

        public static bool IsNotDefined<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return !type.GetReflector().IsDefined<TAttribute>();
        }
    }
}