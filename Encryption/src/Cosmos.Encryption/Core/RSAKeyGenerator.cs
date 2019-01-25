using System.IO;
using System.Security.Cryptography;
using Cosmos.Encryption.Core.Internals.Extensions;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

/*
 * Reference to:
 *     https://github.com/stulzq/RSAUtil/blob/master/XC.RSAUtil/RsaKeyGenerator.cs
 *     Author:Zhiqiang Li
 */

namespace Cosmos.Encryption.Core
{
    public static class RSAKeyGenerator
    {
        /// <summary>
        /// Generate XML Format RSA Key. Result: Index 0 is the private key and index 1 is the public key
        /// </summary>
        /// <param name="keySize">Key Size.Unit: bits</param>
        /// <returns></returns>
        public static RSAKey XmlKey(int keySize)
        {
            using (var rsa = new RSACryptoServiceProvider(keySize))
            {
                return new RSAKey
                {
                    PublicKey = rsa.ToLvccXmlString(false),
                    PrivateKey = rsa.ToLvccXmlString(true),
                    Exponent = rsa.ExportParameters(false).Exponent.ToHexString(),
                    Modulus = rsa.ExportParameters(false).Modulus.ToHexString()
                };
            }
        }

        public static RSAKey JsonKey(int keySize)
        {
            using (var rsa = new RSACryptoServiceProvider(keySize))
            {
                return new RSAKey
                {
                    PublicKey = rsa.ToJsonString(false),
                    PrivateKey = rsa.ToJsonString(true),
                    Exponent = rsa.ExportParameters(false).Exponent.ToHexString(),
                    Modulus = rsa.ExportParameters(false).Modulus.ToHexString()
                };
            }
        }

        /// <summary>
        /// Generate RSA key in Pkcs1 format. Result: Index 0 is the private key and index 1 is the public key
        /// </summary>
        /// <param name="keySize">Key Size.Unit: bits</param>
        /// <param name="format">Whether the format is true If it is standard pem file format</param>
        /// <returns></returns>
        public static RSAKey Pkcs1Key(int keySize, bool format)
        {
            IAsymmetricCipherKeyPairGenerator kpGen = GeneratorUtilities.GetKeyPairGenerator("RSA");
            kpGen.Init(new KeyGenerationParameters(new SecureRandom(), keySize));
            var keyPair = kpGen.GenerateKeyPair();

            StringWriter sw = new StringWriter();
            PemWriter pWrt = new PemWriter(sw);
            pWrt.WriteObject(keyPair.Private);
            pWrt.Writer.Close();
            var privateKey = sw.ToString();

            if (!format)
            {
                privateKey = privateKey
                    .ReplaceToEmpty(RSAConstants.RSA_PRIVATE_KEY_START)
                    .ReplaceToEmpty(RSAConstants.RSA_PRIVATE_KEY_END)
                    .ReplaceToEmpty(RSAConstants.R_N);
            }

            StringWriter swpub = new StringWriter();
            PemWriter pWrtpub = new PemWriter(swpub);
            pWrtpub.WriteObject(keyPair.Public);
            pWrtpub.Writer.Close();
            string publicKey = swpub.ToString();
            if (!format)
            {
                publicKey = publicKey
                    .ReplaceToEmpty(RSAConstants.PUBLIC_KEY_START)
                    .ReplaceToEmpty(RSAConstants.PUBLIC_KEY_END)
                    .ReplaceToEmpty(RSAConstants.R_N);
            }

            return new RSAKey
            {
                PublicKey = publicKey,
                PrivateKey = privateKey
            };
        }

        /// <summary>
        /// Generate Pkcs8 format RSA key. Result: Index 0 is the private key and index 1 is the public key
        /// </summary>
        /// <param name="keySize">Key Size.Unit: bits</param>
        /// <param name="format">Whether the format is true If it is standard pem file format</param>
        /// <returns></returns>
        public static RSAKey Pkcs8Key(int keySize, bool format)
        {
            IAsymmetricCipherKeyPairGenerator kpGen = GeneratorUtilities.GetKeyPairGenerator("RSA");
            kpGen.Init(new KeyGenerationParameters(new SecureRandom(), keySize));
            var keyPair = kpGen.GenerateKeyPair();

            StringWriter swpri = new StringWriter();
            PemWriter pWrtpri = new PemWriter(swpri);
            Pkcs8Generator pkcs8 = new Pkcs8Generator(keyPair.Private);
            pWrtpri.WriteObject(pkcs8);
            pWrtpri.Writer.Close();
            string privateKey = swpri.ToString();

            if (!format)
            {
                privateKey = privateKey
                    .ReplaceToEmpty(RSAConstants.PRIVATE_KEY_START)
                    .ReplaceToEmpty(RSAConstants.PRIVATE_KEY_END)
                    .ReplaceToEmpty(RSAConstants.R_N);
            }

            StringWriter swpub = new StringWriter();
            PemWriter pWrtpub = new PemWriter(swpub);
            pWrtpub.WriteObject(keyPair.Public);
            pWrtpub.Writer.Close();
            string publicKey = swpub.ToString();
            if (!format)
            {
                publicKey = publicKey
                    .ReplaceToEmpty(RSAConstants.PUBLIC_KEY_START)
                    .ReplaceToEmpty(RSAConstants.PUBLIC_KEY_END)
                    .ReplaceToEmpty(RSAConstants.R_N);
            }

            return new RSAKey
            {
                PublicKey = publicKey,
                PrivateKey = privateKey
            };
        }

    }
}