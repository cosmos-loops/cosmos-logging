using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class BaseTypeExtensions
    {
        /// <summary>
        /// 判断指定字符串是否为 Guid
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsGuid(this string @string) => Judgements.GuidJudgement.IsValid(@string);

        /// <summary>
        /// 检查字符串是 null 还是 System.String.Empty 字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string @string) => string.IsNullOrEmpty(@string);

        /// <summary>
        /// 检查字符串不是 null 或 System.String.Empty 字符串
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNotNullNorEmpty(this string @string) => !@string.IsNullOrEmpty();

        /// <summary>
        /// 检查字符串是 null、空还是仅由空白字符组成
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string @string) => string.IsNullOrWhiteSpace(@string);

        /// <summary>
        /// 检查字符串不是 null、空或由空白字符串组成
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNotNullNorWhiteSpace(this string @string) => !@string.IsNullOrWhiteSpace();

        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string @string, params string[] values)
            => Judgements.StringJudgement.StartWithThese(@string, values);

        /// <summary>
        /// 确定此字符串实例的开头是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartsWith(this string @string, ICollection<string> values)
            => Judgements.StringJudgement.StartWithThese(@string, values);

        /// <summary>
        /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWith(this string @string, params string[] values)
            => Judgements.StringJudgement.EndWithThese(@string, values);

        /// <summary>
        /// 确定此字符串实例的结尾是否与指定的字符串数组中的某一个成员匹配。
        /// <para>只要有一个匹配，则返回 True，不然则返回 False</para>
        /// </summary>
        /// <param name="string"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndsWith(this string @string, ICollection<string> values)
            => Judgements.StringJudgement.EndWithThese(@string, values);

        /// <summary>
        /// 指示指定的字符串是否为 Int 类型
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsInt(this string @string) => Judgements.NumericJudgement.IsInt32(@string);

        /// <summary>
        /// 指示指定的字符串是否为数字
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNumberic(this string @string) => Judgements.NumericJudgement.IsNumeric(@string);

        /// <summary>
        /// 判断是否为 Url 路径
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsWebUrl(this string target) => Judgements.StringJudgement.IsWebUrl(target);

        /// <summary>
        /// 判断是否为 Email 地址
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsEmail(this string target) => Judgements.StringJudgement.IsEmail(target);

        /// <summary>
        /// 是否包含中文
        /// </summary>
        /// <param name="text"></param>
        public static bool ContainsChinese(string text) => Judgements.StringJudgement.ContainsChineseCharacters(text);

        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="text">文本</param>
        public static bool ContainsNumber(string text) => Judgements.StringJudgement.ContainsNumber(text);

    }
}