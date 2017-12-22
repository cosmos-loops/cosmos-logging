using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Encryption.Algorithms.Abstractions;

namespace Cosmos.Encryption.Algorithms {
    /// <summary>
    /// RowTransposition encryption algorithm
    /// for more info, please view:
    ///     https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// Author: Omar-Salem
    ///     https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/RowTransposition.cs
    /// </summary>
    public sealed class RowTransposition : IEncryptionAlgorithm {
        private int[] Key { get; }

        public RowTransposition(int[] key) => Key = key;

        public string Encrypt(string plainText) {
            int columns = 0, rows = 0;
            var rowsPositions = FillPositionsDictionary(Key, plainText, ref columns, ref rows);
            var matrix2 = new char[rows, columns];

            //Fill Mareix
            var charPosition = 0;
            for (var i = 0; i < rows; i++) {
                for (var j = 0; j < columns; j++) {
                    matrix2[i, j] = charPosition < plainText.Length
                        ? plainText[charPosition]
                        : '*';
                    charPosition++;
                }
            }

            var sbStr = new StringBuilder();

            for (var i = 0; i < columns; i++) {
                for (var j = 0; j < rows; j++) {
                    sbStr.Append(matrix2[j, rowsPositions[i + 1]]);
                }

                sbStr.Append(" ");
            }

            return sbStr.ToString();
        }

        public string Decrypt(string cipher) {
            int columns = 0, rows = 0;
            var rowsPositions = FillPositionsDictionary(Key, cipher, ref columns, ref rows);
            var matrix = new char[rows, columns];

            //Fill Matrix
            var charPositon = 0;
            for (var i = 0; i < columns; i++) {
                for (var j = 0; j < rows; j++) {
                    matrix[j, rowsPositions[i + 1]] = cipher[charPositon];
                    charPositon++;
                }
            }

            var sbStr = new StringBuilder();

            foreach (var c in matrix) {
                if (c != '*' && c != ' ') {
                    sbStr.Append(c);
                }
            }

            return sbStr.ToString();
        }

        private static Dictionary<int, int> FillPositionsDictionary(int[] key, string token, ref int columns, ref int rows) {
            var result = new Dictionary<int, int>();
            columns = key.Length;
            rows = (int) Math.Ceiling((double) token.Length / columns);
            /*  we need something to tell where to start
             *        4  3  1  2  5  6  7               Key
             *        
             *        0  1  2  3  4  5  6               Value
             */
            //attack postponed until two am xyz
            for (var i = 0; i < columns; i++) {
                result.Add(key[i], i);
            }

            return result;
        }
    }
}