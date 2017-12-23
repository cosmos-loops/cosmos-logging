using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Core.Internals;

namespace Cosmos.Encryption.Algorithms {
    /// <summary>
    /// Monoalphabetic encryption algorithm
    /// for more info, please view:
    ///     https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// Author: Omar-Salem
    ///     https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/Monoalphabetic.cs
    /// </summary>
    public sealed class Monoalphabetic : IEncryptionAlgorithm {
        private Dictionary<char, char> AlphabetShuffled { get; }
        private Dictionary<char, char> AlphabetShuffledReverse { get; }

        public Monoalphabetic() {
            AlphabetShuffledReverse = new Dictionary<char, char>();
            AlphabetShuffled = new Dictionary<char, char>();
            ShuffleAlphabet();
        }

        public string Encrypt(string plainText) =>
            ProcessFunc()(AlphabetShuffled)(AlphabetShuffledReverse)(plainText)(EncryptionAlgorithmMode.Encrypt);

        public string Decrypt(string cipher) =>
            ProcessFunc()(AlphabetShuffled)(AlphabetShuffledReverse)(cipher)(EncryptionAlgorithmMode.Decrypt);

        private static Func<Dictionary<char, char>, Func<Dictionary<char, char>, Func<string, Func<EncryptionAlgorithmMode, string>>>> ProcessFunc()
            => alphabetShuffled => alphabetShuffledReverse => token => mode => {
                var sbRet = new StringBuilder();

                for (var i = 0; i < token.Length; i++) {
                    switch (mode) {
                        case EncryptionAlgorithmMode.Encrypt:
                            sbRet.Append(alphabetShuffled[token[i]]);
                            break;
                        case EncryptionAlgorithmMode.Decrypt:
                            sbRet.Append(alphabetShuffledReverse[token[i]]);
                            break;
                    }
                }

                return sbRet.ToString();
            };

        private void ShuffleAlphabet() {
            var r = new Random(DateTime.Now.Millisecond);
            var alphabetKeys = AlphabetDictionaryGenerator.Generate().Keys;
            var alphabetCopy = alphabetKeys.ToList();

            foreach (var character in alphabetKeys) {
                var characterPosition = r.Next(0, alphabetCopy.Count);
                var randomCharacter = alphabetCopy[characterPosition];
                AlphabetShuffled.Add(character, randomCharacter);
                AlphabetShuffledReverse.Add(randomCharacter, character);
                alphabetCopy.RemoveAt(characterPosition);
            }
        }
    }
}