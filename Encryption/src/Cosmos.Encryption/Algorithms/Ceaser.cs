using System;
using System.Linq;
using System.Text;
using Cosmos.Encryption.Algorithms.Abstractions;
using Cosmos.Encryption.Internals;

namespace Cosmos.Encryption.Algorithms {
    /// <summary>
    /// Ceaser encryption algorithm
    /// for more info, please view:
    ///     https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// Author: Omar-Salem
    ///     https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/Ceaser.cs
    /// </summary>
    public sealed class Ceaser : IEncryptionAlgorithm {
        private int Key { get; }

        public Ceaser(int key) => Key = key;

        public string Encrypt(string plainText) => ProcessFunc()(Key)(plainText)(EncryptionAlgorithmMode.Encrypt);

        public string Decrypt(string cipher) => ProcessFunc()(Key)(cipher)(EncryptionAlgorithmMode.Decrypt);


        private static Func<int, Func<string, Func<EncryptionAlgorithmMode, string>>> ProcessFunc() => key => message => mode => {
            var sbRet = new StringBuilder();
            var alphabet = AlphabetDictionaryGenerator.Generate();

            foreach (var c in message) {
                var res = AlgorithmUtils.GetAlphabetPositionFunc()
                    (alphabet[c]) /*char position*/
                    (key)
                    (mode); /*encryption algorithm mode*/

                sbRet.Append(alphabet.Keys.ElementAt(res % 26));
            }

            return sbRet.ToString();
        };
    }
}