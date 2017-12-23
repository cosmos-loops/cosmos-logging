using System;
using System.Linq;
using System.Text;
using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Core;
using Cosmos.Encryption.Core.Internals;

namespace Cosmos.Encryption.Algorithms {
    /// <summary>
    /// Hill encryption algorithm
    /// for more info, please view:
    ///     https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// Author: Omar-Salem
    ///     https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/Hill.cs
    /// </summary>
    public sealed class Hill : IEncryptionAlgorithm {
        private int[,] Key { get; }

        public Hill(int[,] matrix) => Key = matrix;

        public string Encrypt(string plainText) => ProcessFunc()(Key)(plainText)(EncryptionAlgorithmMode.Encrypt);

        public string Decrypt(string cipher) => ProcessFunc()(Key)(cipher)(EncryptionAlgorithmMode.Decrypt);

        private static Func<int[,], Func<string, Func<EncryptionAlgorithmMode, string>>> ProcessFunc() => key => message => mode => {
            var sbRet = new StringBuilder();
            var matrix = new MatrixClass(key);
            var alphabet = AlphabetDictionaryGenerator.Generate();

            if (mode == EncryptionAlgorithmMode.Decrypt) {
                matrix = matrix.Inverse();
            }

            var pos = 0;
            var matrixSize = key.GetLength(0);

            while (pos < message.Length) {
                for (var i = 0; i < matrixSize; i++) {
                    var charPosition = 0;

                    for (var j = 0; j < matrixSize; j++) {
                        charPosition += (int) matrix[j, i].Numerator * alphabet[message.Substring(pos, matrixSize)[j]];
                    }

                    sbRet.Append(alphabet.Keys.ElementAt(charPosition % 26));
                }

                pos += matrixSize;
            }

            return sbRet.ToString();
        };
    }
}