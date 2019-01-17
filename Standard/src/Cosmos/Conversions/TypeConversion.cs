using System;
using System.Reflection;
using Cosmos.Judgements;

namespace Cosmos.Conversions
{
    /// <summary>
    /// Type conversion Utilities
    /// </summary>
    public static class TypeConversion
    {
        /// <summary>
        /// Convert nullable type to underlying type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNonNullableType(Type type)
        {
            return Nullable.GetUnderlyingType(type);
        }

        /// <summary>
        /// Convert nullable typeinfo to underlying typeinfo
        /// </summary>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static TypeInfo ToNonNullableTypeInfo(TypeInfo typeinfo)
        {
            return Nullable.GetUnderlyingType(typeinfo.AsType()).GetTypeInfo();
        }

        public static Type ToSafeNonNullableType(Type type)
        {
            return TypeJudgement.IsNullableType(type) ? ToNonNullableType(type) : type;
        }

        public static TypeInfo ToSafeNonNullableTypeInfo(TypeInfo typeInfo)
        {
            return TypeJudgement.IsNullableType(typeInfo) ? ToNonNullableTypeInfo(typeInfo) : typeInfo;
        }
    }
}