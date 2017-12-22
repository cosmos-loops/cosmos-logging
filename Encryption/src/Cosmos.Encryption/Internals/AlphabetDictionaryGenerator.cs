using System;
using System.Collections.Generic;

namespace Cosmos.Encryption.Internals {
    internal static class AlphabetDictionaryGenerator {
        private static Dictionary<char, int> AlphabetCache { get; }

        static AlphabetDictionaryGenerator() {
            AlphabetCache = GenerateFunc()();
        }

        public static Dictionary<char, int> Generate() => AlphabetCache;

        public static Dictionary<char, int> GenerateNewInstance() => GenerateFunc()();

        private static Func<Dictionary<char, int>> GenerateFunc() => () => {
            var alphabet = new Dictionary<char, int>();
            var c = 'a';

            for (var i = 0; i < 26; c++, i++) {
                alphabet.Add(c, i);
            }

            return alphabet;
        };
    }
}