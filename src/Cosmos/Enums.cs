using System;
using System.Reflection;

namespace Cosmos
{
    /// <summary>
    /// Enum Utilities
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">
        /// 成员名或值,
        /// 范例:Enum1枚举有成员A=0,则传入"A"或"0"获取 Enum1.A
        /// </param>
        public static T Of<T>(object member)
        {
            var value = Conversions.ObjectConversion.ToString(member);
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(member));
            }
            return (T)Enum.Parse(Types.Of<T>(), value, true);
        }

        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">
        /// 成员名、值、实例均可,
        /// 范例:Enum1枚举有成员A=0,则传入Enum1.A或0,获取成员名"A"
        /// </param>
        public static string NameOf<T>(object member)
        {
            return NameOf(Types.Of<T>(), member);
        }

        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string NameOf(Type type, object member)
        {
            return NameOf(type.GetTypeInfo(), member);
        }

        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <param name="typeinfo">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        /// <returns></returns>
        public static string NameOf(TypeInfo typeinfo, object member)
        {
            if (typeinfo == null) return string.Empty;
            if (member == null) return string.Empty;
            if (member is string) return member.ToString();
            return !typeinfo.IsEnum ? string.Empty : Enum.GetName(typeinfo.AsType(), member);
        }

        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">
        /// 成员名、值、实例均可，
        /// 范例:Enum1枚举有成员A=0,可传入"A"、0、Enum1.A，获取值0
        /// </param>
        public static int ValueOf<T>(object member)
        {
            return ValueOf(Types.Of<T>(), member);
        }

        /// <summary>
        /// 获取成员值
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static int ValueOf(Type type, object member)
        {
            var value = Conversions.ObjectConversion.ToString(member);
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(member));
            }
            return (int)Enum.Parse(type, member.ToString(), true);
        }


        /// <summary>
        /// 获取描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription<T>(object member)
        {
            return Reflections.GetDescription<T>(NameOf<T>(member));
        }

        /// <summary>
        /// 获取描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription(Type type, object member)
        {
            return Reflections.GetDescription(type, NameOf(type, member));
        }

        /// <summary>
        /// 获取描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <param name="typeinfo">枚举类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        public static string GetDescription(TypeInfo typeinfo, object member)
        {
            return Reflections.GetDescription(typeinfo, NameOf(typeinfo, member));
        }
    }
}
