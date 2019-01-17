using System.Text.RegularExpressions;

namespace Cosmos
{
    /// <summary>
    /// Regex Utilities
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class Regexs
    {
        /// <summary>
        /// 验证输入与模式是否匹配
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>        
        public static bool IsMatch(string input, string pattern)
            => IsMatch(input, pattern, RegexOptions.IgnoreCase);


        /// <summary>
        /// 验证输入与模式是否匹配
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="options">筛选条件,比如是否忽略大小写</param>
        public static bool IsMatch(string input, string pattern, RegexOptions options)
            => Regex.IsMatch(input, pattern, options);
    }
}