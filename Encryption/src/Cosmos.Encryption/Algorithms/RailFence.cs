using System;
using System.Text;
using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Core.Internals;

namespace Cosmos.Encryption.Algorithms {
    /// <summary>
    /// RailFence encryption algorithm
    /// for more info, please view:
    ///     https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// Author: Omar-Salem
    ///     https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/RailFence.cs
    /// </summary>
    public sealed class RailFence : IEncryptionAlgorithm {
        private int Key { get; }

        public RailFence(int key) => Key = key;

        public string Encrypt(string plainText) => ProcessFunc()(Key)(plainText)(EncryptionAlgorithmMode.Encrypt);

        public string Decrypt(string cipher) => ProcessFunc()(Key)(cipher)(EncryptionAlgorithmMode.Decrypt);

        private static Func<int, Func<string, Func<EncryptionAlgorithmMode, string>>> ProcessFunc() => key => message => mode => {
            var rows = key;
            var columns = (int) Math.Ceiling((double) message.Length / rows);
            var matrix = FillArrayFunc()(message)(rows)(columns)(mode);
            var sbStr = new StringBuilder();

            foreach (char c in matrix) {
                sbStr.Append(c);
            }

            return sbStr.ToString();
        };

        private static Func<string, Func<int, Func<int, Func<EncryptionAlgorithmMode, char[,]>>>> FillArrayFunc()
            => message => rowsCount => columnsCount => mode => {
                int charPosition = 0, length = 0, width = 0;
                var matrix = new char[rowsCount, columnsCount];

                switch (mode) {
                    case EncryptionAlgorithmMode.Encrypt:
                        length = rowsCount;
                        width = columnsCount;
                        break;

                    case EncryptionAlgorithmMode.Decrypt:
                        matrix = new char[columnsCount, rowsCount];
                        width = rowsCount;
                        length = columnsCount;
                        break;
                }

                for (var i = 0; i < width; i++) {
                    for (var j = 0; j < length; j++) {
                        if (charPosition < message.Length) {
                            matrix[j, i] = message[charPosition];
                        } else {
                            matrix[j, i] = '*';
                        }

                        charPosition++;
                    }
                }

                return matrix;
            };
    }
}