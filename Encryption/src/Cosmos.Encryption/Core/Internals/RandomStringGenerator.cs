using System;
using System.Text;

namespace Cosmos.Encryption.Core.Internals {
    /// <summary>
    /// Author: Seay Xu
    ///     https://github.com/godsharp/GodSharp.Encryption/blob/master/src/GodSharp.Shared/Encryption/Util/Util.cs
    /// Editor: AlexLEWIS
    /// </summary>
    internal static class RandomStringGenerator {
        static RandomStringGenerator() {
            StringDictionaryLength = StringDictionary.Length;
        }

        private const string StringDictionary = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

        private static readonly int StringDictionaryLength;

        public static string Generate(int bits = 8) {
            var builder = new StringBuilder();

            var b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            var random = new Random(BitConverter.ToInt32(b, 0));

            for (var i = 0; i < bits; i++) {
                builder.Append(StringDictionary.Substring(random.Next(0, StringDictionaryLength), 1));
            }

            return builder.ToString();
        }
    }
}