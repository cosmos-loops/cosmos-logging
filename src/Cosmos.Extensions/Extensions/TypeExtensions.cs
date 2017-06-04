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
        /// To judge the attribute exists or not
        /// </summary>
        /// <typeparam name="T">要检查的特性类型</typeparam>
        /// <param name="memberInfo">要检查的类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>是否存在</returns>
        public static bool AttributeExists<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
            => memberInfo.GetCustomAttributes(typeof(T), inherit).Any(m => (m as T) != null);

        /// <summary>
        /// To judge the attribute dosn't exist or not
        /// </summary>
        /// <typeparam name="T">要检查的特性类型</typeparam>
        /// <param name="memberInfo">要检查的类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>是否不存在</returns>
        public static bool AttributeNotExists<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
            => memberInfo.GetCustomAttributes(typeof(T), inherit).All(m => (m as T) == null);

        /// <summary>
        /// Get attributes from memberinfo
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="memberInfo">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回null</returns>
        public static T GetAttribute<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
            => memberInfo.GetCustomAttributes(typeof(T), inherit).SingleOrDefault() as T;

        /// <summary>
        /// Get attributes from memberinfo
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="memberInfo">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回 null</returns>
        public static T[] GetAttributes<T>(this MemberInfo memberInfo, bool inherit) where T : Attribute
            => memberInfo.GetCustomAttributes(typeof(T), inherit).Cast<T>().ToArray();

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
        /// To compute signature
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string ToComputeSignature(this MethodInfo method)
        {
            var sb = new StringBuilder();
            sb.Append(method.ReturnType.ToComputeSignature());
            sb.Append(" ");
            sb.Append(method.Name);
            if (method.IsGenericMethod)
            {
                sb.Append("[");
                var genericTypes = method.GetGenericArguments().ToTypeInfo().ToList();
                for (var i = 0; i < genericTypes.Count(); i++)
                {
                    sb.Append(genericTypes[i].ToComputeSignature());
                    if (i != genericTypes.Count() - 1)
                        sb.Append(", ");
                }
                sb.Append("]");
            }
            sb.Append("(");
            var parameters = method.GetParameters();
            for (var i = 0; i < parameters.Length; i++)
            {
                sb.Append(parameters[i].ParameterType.ToComputeSignature());
                if (i != parameters.Length - 1)
                    sb.Append(", ");
            }
            sb.Append(")");
            return sb.ToString();
        }

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
