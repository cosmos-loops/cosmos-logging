using System;
using Cosmos.Encryption.Algorithms.Abstractions;
using Cosmos.Encryption.Internals;

namespace Cosmos.Encryption.Algorithms {
    /// <summary>
    /// Vigenere encryption algorithm
    /// for more info, please view:
    ///     https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// Author: Omar-Salem
    ///     https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/Vigenere.cs
    /// </summary>
    public sealed class Vigenere : IEncryptionAlgorithm {
        private string Key { get; }

        public Vigenere(string key) => Key = key;

        public string Encrypt(string plainText) => ProcessFunc()(Key)(plainText)(EncryptionAlgorithmMode.Encrypt);

        public string Decrypt(string cipher) => ProcessFunc()(Key)(cipher)(EncryptionAlgorithmMode.Decrypt);

        private static Func<string, Func<string, Func<EncryptionAlgorithmMode, string>>> ProcessFunc() => key => message => mode => {
            key = key.ToString().ToLower().Replace(" ", "");
            key = DuplicateKeyFunc()(key)(message);
            return AlgorithmUtils.Shift(message, key, mode, AlphabetDictionaryGenerator.Generate());
        };

        private static Func<string, Func<string, string>> DuplicateKeyFunc() => key => message => {
            if (key.Length < message.Length) {
                var length = message.Length - key.Length;

                for (var i = 0; i < length; i++) {
                    key += key[i % key.Length];
                }
            }

            return key;
        };
    }
}