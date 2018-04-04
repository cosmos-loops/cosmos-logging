using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Cosmos {
    public static class Reflections {
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="memberName">成员名称</param>
        public static string GetDescription<T>(string memberName) {
            return GetDescription(Types.Of<T>(), memberName);
        }

        /// <summary>
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
        /// 获取描述
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="memberName">成员名称</param>
        public static string GetDescription(Type type, string memberName) {
            return GetDescription(type.GetTypeInfo(), memberName);
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="typeinfo">类型</param>
        /// <param name="field">成员</param>
        /// <returns></returns>
        public static string GetDescription(TypeInfo typeinfo, FieldInfo field) {
            if (typeinfo == null || field == null) {
                return string.Empty;
            }

            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;
            return attribute == null ? field.Name : attribute.Description;
        }

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="field">成员</param>
        public static string GetDescription(Type type, FieldInfo field) {
            return GetDescription(type.GetTypeInfo(), field);
        }
    }
}