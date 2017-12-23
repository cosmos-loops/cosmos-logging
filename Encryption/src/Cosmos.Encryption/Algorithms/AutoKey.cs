using System;
using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Core.Internals;

namespace Cosmos.Encryption.Algorithms {
    /// <summary>
    /// AutoKey encryption algorithm
    /// for more info, please view:
    ///     https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// Author: Omar-Salem
    ///     https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/AutoKey.cs
    /// </summary>
    public sealed class AutoKey : IEncryptionAlgorithm {
        private string Key { get; }

        public AutoKey(string key) => Key = key;

        public string Encrypt(string plainText) => ProcessFunc()(Key)(plainText)(EncryptionAlgorithmMode.Encrypt);

        public string Decrypt(string cipher) => ProcessFunc()(Key)(cipher)(EncryptionAlgorithmMode.Decrypt);

        private static Func<string, Func<string, Func<EncryptionAlgorithmMode, string>>> ProcessFunc() => key => message => mode => {
            var k = DuplicateKeyFunc()(key)(message);
            return AlgorithmUtils.Shift(message, k, mode, AlphabetDictionaryGenerator.Generate());
        };

        private static Func<string, Func<string, string>> DuplicateKeyFunc() => key => message => {
            if (key.Length < message.Length) {
                var len = message.Length - key.Length;
                for (var i = 0; i < len; i++) {
                    key += message[i];
                }
            }

            return key;
        };
    }
}