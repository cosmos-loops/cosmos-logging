using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Cosmos.Extensions
{
    /// <summary>
    /// Type extensions
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Get non-nullable inderlying <see cref="Type"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNonNullableType(this Type type)
            => Conversions.TypeConversion.ToNonNullableType(type);

        /// <summary>
        /// Get non-nullable inderlying <see cref="TypeInfo"/>
        /// </summary>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static TypeInfo ToNonNullableTypeInfo(this TypeInfo typeinfo)
            => Conversions.TypeConversion.ToNonNullableTypeInfo(typeinfo);

        /// <summary>
        /// Get object's <see cref="TypeInfo"/>
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static TypeInfo TypeInfo(this object @object)
            => @object.GetType().GetTypeInfo();

        /// <summary>
        /// Convert <see cref="Type"/> array to <see cref="TypeInfo"/> list
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<TypeInfo> ToTypeInfo(this Type[] types)
            => types.Select(type => type.GetTypeInfo());

        /// <summary>
        /// Get property value
        /// </summary>
        /// <param name="object">Any <see cref="object"/></param>
        /// <param name="propertyName">Property name in this object</param>
        /// <returns>Value of the specific property in this object</returns>
        public static object GetPropertyValue(this object @object, string propertyName)
            => @object.TypeInfo().GetProperty(propertyName).GetValue(@object, null);

        /// <summary>
        /// To compute signature
        /// </summary>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static string ToComputeSignature(this TypeInfo typeinfo)
        {
            var sb = new StringBuilder();
            if (typeinfo.IsGenericType)
            {
                sb.Append(typeinfo.GetGenericTypeDefinition().FullName)
                    .Append("[");

                var genericArgs = typeinfo.GetGenericArguments().ToTypeInfo().ToList();
                for (var i = 0; i < genericArgs.Count(); i++)
                {
                    sb.Append(genericArgs[i].ToComputeSignature());
                    if (i != genericArgs.Count() - 1)
                        sb.Append(", ");
                }
                sb.Append("]");
            }
            else
            {
                if (!string.IsNullOrEmpty(typeinfo.FullName))
                    sb.Append(typeinfo.FullName);
                else if (!string.IsNullOrEmpty(typeinfo.Name))
                    sb.Append(typeinfo.Name);
                else
                    sb.Append(typeinfo);
            }
            return sb.ToString();
        }

        /// <summary>
        /// To compute signature
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToComputeSignature(this Type type) => ToComputeSignature(type.TypeInfo());

        /// <summary>
        /// To judge the given type is assignable to the generic type or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
            => (FindGenericType(genericType, givenType) != null);

        /// <summary>
        /// To judge the given typeinfo is assignable to the generic typeinfo or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType(this TypeInfo givenType, TypeInfo genericType)
            => FindGenericTypeInfo(genericType, givenType) != null;

        /// <summary>
        /// Find typeinfo from the given type's parameters' type
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static TypeInfo FindGenericTypeInfo(this TypeInfo definition, TypeInfo typeinfo)
        {
            var objectTypeInfo = typeof(object).GetTypeInfo();
            while (typeinfo != null && typeinfo != objectTypeInfo)
            {
                if (typeinfo.IsGenericType && typeinfo.GetGenericTypeDefinition().GetTypeInfo() == definition)
                    return typeinfo;

                if (definition.IsInterface)
                {
                    foreach (var type in typeinfo.GetInterfaces())
                    {
                        var typeinfo2 = FindGenericTypeInfo(definition, type.GetTypeInfo());
                        if (typeinfo2 != null)
                            return typeinfo2;
                    }
                }
                typeinfo = typeinfo.BaseType.GetTypeInfo();
            }
            return null;
        }

        /// <summary>
        /// Find typeinfo from the given type's parameters' type
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type FindGenericType(this Type definition, Type type)
            => (FindGenericTypeInfo(definition.GetTypeInfo(), type.GetTypeInfo()))?.AsType();
    }
}
