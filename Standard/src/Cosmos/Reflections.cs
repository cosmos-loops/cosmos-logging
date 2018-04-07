using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;

namespace Cosmos {
    public static class Reflections {
        /// <summary>
        /// Get description
        /// 获取描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetDescription<T>() {
            return GetDescription(Types.Of<T>());
        }

        /// <summary>
        /// Get description
        /// 获取描述
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDescription(Type type) {
            return GetDescription(type.GetTypeInfo());
        }

        /// <summary>
        /// Get description
        /// 获取描述
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetDescription(TypeInfo type) {
            var attribute = GetAttribute<DescriptionAttribute>(type);
            return attribute == null ? type.Name : attribute.Description;
        }

        /// <summary>
        /// Get description
        /// 获取描述
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="memberName">成员名称</param>
        public static string GetDescription<T>(string memberName) {
            return GetDescription(Types.Of<T>(), memberName);
        }

        /// <summary>
        /// Get description
        /// 获取描述
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="memberName">成员名称</param>
        public static string GetDescription(Type type, string memberName) {
            return GetDescription(type.GetTypeInfo(), memberName);
        }

        /// <summary>
        /// Get description
        /// 获取描述
        /// </summary>
        /// <param name="typeinfo">类型</param>
        /// <param name="memberName">成员名称</param>
        public static string GetDescription(TypeInfo typeinfo, string memberName) {
            if (typeinfo == null) {
                return string.Empty;
            }

            return !string.IsNullOrWhiteSpace(memberName)
                ? string.Empty
                : GetDescription(typeinfo, typeinfo.GetField(memberName));
        }

        /// <summary>
        /// Get description
        /// 获取描述
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static string GetDescription(MemberInfo memberInfo) {
            if (memberInfo == null)
                return string.Empty;
            var attribute = GetAttribute<DescriptionAttribute>(memberInfo);
            return attribute == null ? memberInfo.Name : attribute.Description;
        }

        /// <summary>
        /// Get description
        /// 获取描述
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="field">成员</param>
        public static string GetDescription(Type type, FieldInfo field) {
            return GetDescription(type.GetTypeInfo(), field);
        }

        /// <summary>
        /// Get description
        /// 获取描述
        /// </summary>
        /// <param name="typeinfo">类型</param>
        /// <param name="field">成员</param>
        /// <returns></returns>
        public static string GetDescription(TypeInfo typeinfo, FieldInfo field) {
            if (typeinfo == null || field == null) {
                return string.Empty;
            }

            var attribute = GetAttribute<DescriptionAttribute>(field);
            return attribute == null ? field.Name : attribute.Description;
        }

        /// <summary>
        /// Get display name
        /// 获取显示名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetDisplayName<T>() {
            return GetDisplayName(typeof(T));
        }

        /// <summary>
        /// Get display name
        /// 获取显示名称
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        private static string GetDisplayName(MemberInfo memberInfo) {
            if (memberInfo == null)
                return string.Empty;
            var displayNameAttribute = GetAttribute<DisplayNameAttribute>(memberInfo);
            if (displayNameAttribute != null)
                return displayNameAttribute.DisplayName;
            var displayAttribute = GetAttribute<DisplayAttribute>(memberInfo);
            if (displayAttribute == null)
                return string.Empty;
            return displayAttribute.Description;
        }

        /// <summary>
        /// Get display name or description
        /// 获取显示名称或描述，优先获取显示名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetDescriptionOrDisplayName<T>() {
            var result = GetDisplayName<T>();
            if (string.IsNullOrWhiteSpace(result))
                result = GetDescription<T>();
            return result;
        }

        /// <summary>
        /// Get display name or description
        /// 获取显示名称或描述，优先获取显示名称
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static string GetDescriptionOrDisplayName(MemberInfo memberInfo) {
            var result = GetDisplayName(memberInfo);
            return !string.IsNullOrWhiteSpace(result) ? result : GetDescription(memberInfo);
        }

        /// <summary>
        /// Get attribute
        /// 获取特性
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(FieldInfo fieldInfo) where TAttribute : Attribute {
            return fieldInfo == null ? null : fieldInfo.GetReflector().GetCustomAttributes<TAttribute>().FirstOrDefault();
        }

        /// <summary>
        /// Get attribute
        /// 获取特性
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(MemberInfo memberInfo) where TAttribute : Attribute {
            return memberInfo == null ? null : GetAttribute<TAttribute>(memberInfo.GetType());
        }

        /// <summary>
        /// Get attribute
        /// 获取特性
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(Type type) where TAttribute : Attribute {
            return type == null ? null : GetAttribute<TAttribute>(type.GetTypeInfo());
        }

        /// <summary>
        /// Get attribute
        /// 获取特性
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(TypeInfo typeInfo) where TAttribute : Attribute {
            return typeInfo == null ? null : typeInfo.GetReflector().GetCustomAttributes<TAttribute>().FirstOrDefault();
        }

        /// <summary>
        /// Get attribute
        /// 获取特性
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(FieldInfo fieldInfo) where TAttribute : Attribute {
            return fieldInfo == null ? null : fieldInfo.GetReflector().GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// Get attribute
        /// 获取特性
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(MemberInfo memberInfo) where TAttribute : Attribute {
            return memberInfo == null ? null : GetRequiredAttribute<TAttribute>(memberInfo.GetType());
        }

        /// <summary>
        /// Get attribute
        /// 获取特性
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(Type type) where TAttribute : Attribute {
            return type == null ? null : GetRequiredAttribute<TAttribute>(type.GetTypeInfo());
        }

        /// <summary>
        /// Get attribute
        /// 获取特性
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(TypeInfo typeInfo) where TAttribute : Attribute {
            return typeInfo == null ? null : typeInfo.GetReflector().GetCustomAttribute<TAttribute>();
        }
    }
}