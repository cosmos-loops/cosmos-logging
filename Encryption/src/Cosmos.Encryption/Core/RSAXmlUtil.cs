using System;
using System.Security.Cryptography;
using System.Text;
using Cosmos.Encryption.Core.Internals.Extensions;

/*
 * Reference to:
 *     https://github.com/stulzq/RSAUtil/blob/master/XC.RSAUtil/RsaXmlUtil.cs
 *     Author:Zhiqiang Li
 */

namespace Cosmos.Encryption.Core
{
    // ReSharper disable once InconsistentNaming
    public class RSAXmlUtil : RSABase
    {
        /// <summary>
        /// RSA encryption
        /// SHA256 hash algorithm to use the key length of at least 2048
        /// </summary>
        /// <param name="keySize">Key length in bits:</param>
        /// <param name="privateKey">private Key</param>
        /// <param name="publicKey">public Key</param>
        public RSAXmlUtil(string publicKey, string privateKey = null, int keySize = 2048)
            : this(Encoding.UTF8, publicKey, privateKey, keySize) { }

        /// <summary>
        /// RSA encryption
        /// SHA256 hash algorithm to use the key length of at least 2048
        /// </summary>
        /// <param name="dataEncoding">Data coding</param>
        /// <param name="keySize">Key length in bits:</param>
        /// <param name="privateKey">private Key</param>
        /// <param name="publicKey">public Key</param>
        public RSAXmlUtil(Encoding dataEncoding, string publicKey, string privateKey = null, int keySize = 2048)
        {
            if (string.IsNullOrEmpty(privateKey) && string.IsNullOrEmpty(publicKey))
            {
                throw new ArgumentException("Public and private keys must not be empty at the same time");
            }

            if (!string.IsNullOrEmpty(privateKey))
            {
                PrivateRsa = RSA.Create();
                PrivateRsa.KeySize = keySize;
                PrivateRsa.FromLvccXmlString(privateKey);
            }

            if (!string.IsNullOrEmpty(publicKey))
            {
                PublicRsa = RSA.Create();
                PublicRsa.KeySize = keySize;
                PublicRsa.FromLvccXmlString(publicKey);
            }
            
            DataEncoding = dataEncoding ?? Encoding.UTF8;
        }
    }
}