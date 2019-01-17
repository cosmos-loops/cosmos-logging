using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cosmos.Judgements
{
    /// <summary>
    /// String Judgement Utilities
    /// </summary>
    public static class StringJudgement
    {
        static StringJudgement() { }

        /// <summary>
        /// To judge whether the string starts with the specified strings
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartWithThese(string str, params string[] values)
        {
            if (string.IsNullOrWhiteSpace(str) || values == null || values.Any(string.IsNullOrWhiteSpace))
                return false;

            return values.Any(str.StartsWith);
        }

        /// <summary>
        /// To judge whether the string starts with the specified strings
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool StartWithThese(string str, ICollection<string> values)
        {
            if (string.IsNullOrWhiteSpace(str) || values == null || !values.Any())
                return false;

            return StartWithThese(str, values.ToArray());
        }

        /// <summary>
        /// To judge whether the string ends with the specified strings
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndWithThese(string str, params string[] values)
        {
            if (string.IsNullOrWhiteSpace(str) || values == null || values.Any(string.IsNullOrWhiteSpace))
                return false;

            return values.Any(str.EndsWith);
        }

        /// <summary>
        /// To judge whether the string ends with the specified strings
        /// </summary>
        /// <param name="str"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool EndWithThese(string str, ICollection<string> values)
        {
            if (string.IsNullOrWhiteSpace(str) || values == null || !values.Any())
                return false;

            return EndWithThese(str, values.ToArray());
        }

        private static readonly Regex WebUrlExpressionSchema
            = new Regex(@"(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?",
                RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// To judge whether the string is web url or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsWebUrl(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && WebUrlExpressionSchema.IsMatch(str);
        }

        private static readonly Regex EemailExpressionSchema
            = new Regex(@"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$",
                RegexOptions.Singleline | RegexOptions.Compiled);

        /// <summary>
        /// TO judge whether the string is email or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && EemailExpressionSchema.IsMatch(str);
        }

        /// <summary>
        /// To judge whether the string contains chinese characters or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ContainsChineseCharacters(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && RegexJudgement.IsMatch(str, "[\u4e00-\u9fa5]+");
        }

        /// <summary>
        /// To judge whether the string contains number or not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ContainsNumber(string str)
        {
            return !string.IsNullOrWhiteSpace(str) && RegexJudgement.IsMatch(str, "[0-9]+");
        }
    }
}