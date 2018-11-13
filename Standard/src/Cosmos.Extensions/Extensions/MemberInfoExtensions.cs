using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cosmos.Extensions
{
    public static class MemberInfoExtensions
    {
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
        /// Get attribute from memberinfo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this MemberInfo info) where T : Attribute
            => info.GetCustomAttributes<T>().FirstOrDefault();

        /// <summary>
        /// Get attributes from memberinfo
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="info">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回null</returns>
        public static T GetAttribute<T>(this MemberInfo info, bool inherit) where T : Attribute
            => info.GetCustomAttributes<T>(inherit).FirstOrDefault();

        /// <summary>
        /// Get Attributes from memberinfo
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo info)
            where TAttribute : Attribute
            => info.GetCustomAttributes(typeof(TAttribute)).OfType<TAttribute>();

        /// <summary>
        /// Get attributes from memberinfo
        /// </summary>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="info">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回 null</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo info, bool inherit)
            where TAttribute : Attribute
            => info.GetCustomAttributes(typeof(TAttribute), inherit).OfType<TAttribute>();
    }
}