using System.Text.RegularExpressions;

namespace Cosmos.Extensions {
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions {
        /// <summary>
        /// 根据给定的 splitCode 对字符串进行切割
        /// </summary>
        /// <param name="string"></param>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public static string[] Split(this string @string, string separator) => Regex.Split(@string, separator);
    }
}