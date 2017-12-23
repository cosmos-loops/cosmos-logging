using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Encryption.Abstractions;
using Cosmos.Encryption.Core.Internals;

namespace Cosmos.Encryption.Algorithms {
    /// <summary>
    /// PlayFair encryption algorithm
    /// for more info, please view:
    ///     https://www.codeproject.com/Articles/63432/Classical-Encryption-Techniques
    /// Author: Omar-Salem
    ///     https://github.com/Omar-Salem/Classical-Encryption-Techniques/blob/master/EncryptionAlgorithms/Concrete/PlayFair.cs
    /// </summary>
    public sealed class PlayFair : IEncryptionAlgorithm {
        private string Key { get; }

        public PlayFair(string key) => Key = key;

        public string Encrypt(string plainText) => ProcessFunc()(Key)(plainText)(EncryptionAlgorithmMode.Encrypt);

        public string Decrypt(string cipher) => ProcessFunc()(Key)(cipher)(EncryptionAlgorithmMode.Decrypt);

        private static Func<string, Func<string, Func<EncryptionAlgorithmMode, string>>> ProcessFunc() => key => message => mode => {
            //Key:Charcater
            //Value:Position
            var characterPositionsInMatrix = new Dictionary<char, string>();

            //Key:Position
            //Value:Charcater
            var positionCharacterInMatrix = new Dictionary<string, char>();

            FillMatrixFunc()(key.Distinct().ToArray())(characterPositionsInMatrix)(positionCharacterInMatrix);

            if (mode == EncryptionAlgorithmMode.Encrypt) {
                message = RepairWordFunc()(message);
            }

            var sbStr = new StringBuilder();

            for (var i = 0; i < message.Length; i += 2) {
                var substringOf2 = message.Substring(i, 2); //get characters from text by pairs
                //get Row & Column of each character
                var rc1 = characterPositionsInMatrix[substringOf2[0]];
                var rc2 = characterPositionsInMatrix[substringOf2[1]];

                if (rc1[0] == rc2[0]) //Same Row, different Column
                {
                    int newC1 = 0, newC2 = 0;

                    switch (mode) {
                        case EncryptionAlgorithmMode.Encrypt: //Increment Columns
                            newC1 = (int.Parse(rc1[1].ToString()) + 1) % 5;
                            newC2 = (int.Parse(rc2[1].ToString()) + 1) % 5;
                            break;
                        case EncryptionAlgorithmMode.Decrypt: //Decrement Columns
                            newC1 = (int.Parse(rc1[1].ToString()) - 1) % 5;
                            newC2 = (int.Parse(rc2[1].ToString()) - 1) % 5;
                            break;
                    }

                    newC1 = RepairNegativeFunc()(newC1);
                    newC2 = RepairNegativeFunc()(newC2);

                    sbStr.Append(positionCharacterInMatrix[rc1[0].ToString() + newC1.ToString()]);
                    sbStr.Append(positionCharacterInMatrix[rc2[0].ToString() + newC2.ToString()]);
                } else if (rc1[1] == rc2[1]) {
                    //Same Column, different Row

                    int newR1 = 0, newR2 = 0;

                    switch (mode) {
                        case EncryptionAlgorithmMode.Encrypt: //Increment Rows
                            newR1 = (int.Parse(rc1[0].ToString()) + 1) % 5;
                            newR2 = (int.Parse(rc2[0].ToString()) + 1) % 5;
                            break;
                        case EncryptionAlgorithmMode.Decrypt: //Decrement Rows
                            newR1 = (int.Parse(rc1[0].ToString()) - 1) % 5;
                            newR2 = (int.Parse(rc2[0].ToString()) - 1) % 5;
                            break;
                    }

                    newR1 = RepairNegativeFunc()(newR1);
                    newR2 = RepairNegativeFunc()(newR2);

                    sbStr.Append(positionCharacterInMatrix[newR1.ToString() + rc1[1].ToString()]);
                    sbStr.Append(positionCharacterInMatrix[newR2.ToString() + rc2[1].ToString()]);
                } else {
                    //different Row & Column

                    //1st character:row of 1st + col of 2nd
                    //2nd character:row of 2nd + col of 1st
                    sbStr.Append(positionCharacterInMatrix[rc1[0].ToString() + rc2[1].ToString()]);
                    sbStr.Append(positionCharacterInMatrix[rc2[0].ToString() + rc1[1].ToString()]);
                }
            }

            return sbStr.ToString();
        };

        private static Func<string, string> RepairWordFunc() => message => {
            var trimmed = message.Replace(" ", "");
            var sbStr = new StringBuilder();

            for (var i = 0; i < trimmed.Length; i++) {
                sbStr.Append(trimmed[i]);

                if (i < trimmed.Length - 1 && message[i] == message[i + 1]) //check if two consecutive letters are the same
                {
                    sbStr.Append('x');
                }
            }

            if (sbStr.Length % 2 != 0) //check if length is even
            {
                sbStr.Append('x');
            }

            return sbStr.ToString();
        };

        private static Func<IList<char>, Func<Dictionary<char, string>, Action<Dictionary<string, char>>>> FillMatrixFunc()
            => key => characterPositionsInMatrix => positionCharacterInMatrix => {
                var matrix = new char[5, 5];
                var keyPosition = 0;
                var charPosition = 0;

                var alphabetPlayFiar = AlphabetDictionaryGenerator.Generate().Keys.ToList();
                alphabetPlayFiar.Remove('j');

                for (var i = 0; i < 5; i++) {
                    for (var j = 0; j < 5; j++) {
                        if (charPosition < key.Count) {
                            matrix[i, j] = key[charPosition]; //fill matrix with key
                            alphabetPlayFiar.Remove(key[charPosition]);
                            charPosition++;
                        } else {
                            //key finished...fill with rest of alphabet
                            matrix[i, j] = alphabetPlayFiar[keyPosition];
                            keyPosition++;
                        }

                        var position = i.ToString() + j.ToString();
                        //store character positions in dictionary to avoid searching everytime
                        characterPositionsInMatrix.Add(matrix[i, j], position);
                        positionCharacterInMatrix.Add(position, matrix[i, j]);
                    }
                }
            };

        private static Func<int, int> RepairNegativeFunc() => number => number < 0 ? number + 5 : number;
    }
}