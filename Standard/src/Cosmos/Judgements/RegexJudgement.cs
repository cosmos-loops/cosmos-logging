using System.Text.RegularExpressions;

namespace Cosmos.Judgements {
    /// <summary>
    /// Regex Judgement Utilities
    /// </summary>
    public static class RegexJudgement {
        /// <summary>
        /// Indicates whether the regular expression specified in the Regex constructor finds a match in a specified input string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <param name="options">regex options, default is RegexOptions.IgnoreCase</param>
        /// <returns></returns>
        public static bool IsMatch(string str, string pattern, RegexOptions options = RegexOptions.IgnoreCase) {
            return Regex.IsMatch(str, pattern, options);
        }
    }
}