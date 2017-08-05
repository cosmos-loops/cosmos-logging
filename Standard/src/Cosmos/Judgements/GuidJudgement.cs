using System;
using System.Text.RegularExpressions;

namespace Cosmos.Judgements
{
    /// <summary>
    /// Guid Judgement Utilities
    /// </summary>
    public static class GuidJudgement
    {
        /// <summary>
        /// To judge whether the <see cref="Guid"/> is null or empty
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(Guid guid)
        {
            return guid == Guid.Empty;
        }

        /// <summary>
        /// To judge whether the <see cref="Guid"/> is null or empty
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(Guid? guid)
        {
            return guid == null || IsNullOrEmpty(guid.Value);
        }

        /// <summary>
        /// To judge whether the string is <see cref="Guid"/> or not
        /// </summary>
        /// <param name="guidStr"></param>
        /// <returns></returns>
        public static bool IsValid(string guidStr)
        {
            if (string.IsNullOrWhiteSpace(guidStr))
                return false;

            var format = new Regex("^[A-Fa-f0-9]{32}$|" +
                                   "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
                                   "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2},{0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$");
            var match = format.Match(guidStr);
            return match.Success;
        }
    }
}
