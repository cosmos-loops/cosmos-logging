using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.Encryption.Core.Internals {
    /// <summary>
    /// Algorithm Utils
    /// Author: Omar-Salem
    /// </summary>
    internal static class AlgorithmUtils {
        /// <summary>
        /// Get alphabet position
        /// Author: Omar-Salem
        /// </summary>
        /// <returns></returns>
        internal static Func<int, Func<int, Func<EncryptionAlgorithmMode, int>>> GetAlphabetPositionFunc() => textPosition => keyPosition => mode => {
            switch (mode) {
                case EncryptionAlgorithmMode.Encrypt:
                    return (textPosition + keyPosition) % 26;

                case EncryptionAlgorithmMode.Decrypt:
                    var result = textPosition - keyPosition;
                    return result < 0 ? result + 26 : result;

                default:
                    return 0;
            }
        };

        /// <summary>
        /// Shift
        /// Author: Omar-Salem
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <param name="mode"></param>
        /// <param name="alphabetSortedDict"></param>
        /// <returns></returns>
        internal static string Shift(string token, string key, EncryptionAlgorithmMode mode, Dictionary<char, int> alphabetSortedDict) {
            var sbRet = new StringBuilder();

            for (var i = 0; i < token.Length; i++) {
                var resPosition = GetAlphabetPositionFunc()
                    (alphabetSortedDict[token[i]]) /*text position*/
                    (alphabetSortedDict[key[i]]) /*key position*/
                    (mode); /*encryption algorithm mode*/
                sbRet.Append(alphabetSortedDict.Keys.ElementAt(resPosition));
            }

            return sbRet.ToString();
        }
    }
}