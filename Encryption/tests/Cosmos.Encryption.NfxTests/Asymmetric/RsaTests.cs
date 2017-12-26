using Xunit;

namespace Cosmos.Encryption.NfxTests.Asymmetric {
    public class RsaTests {
        [Fact]
        public void EncryptDecrypt_R1024_XML_Test() {
            var key = RSAEncryptionProvider.CreateKey(RSAKeySizeTypes.R1024);
            var signature = RSAEncryptionProvider.Encrypt("image", key.PublicKey);
            var origin = RSAEncryptionProvider.Decrypt(signature, key.PrivateKey);
            Assert.Equal("image", origin);
        }

        [Fact]
        public void EncryptDecrypt_R2048_XML_Test() {
            var key = RSAEncryptionProvider.CreateKey();
            var signature = RSAEncryptionProvider.Encrypt("image", key.PublicKey);
            var origin = RSAEncryptionProvider.Decrypt(signature, key.PrivateKey);
            Assert.Equal("image", origin);
        }

        [Fact]
        public void EncryptDecrypt_R3072_XML_Test() {
            var key = RSAEncryptionProvider.CreateKey(RSAKeySizeTypes.R3072);
            var signature = RSAEncryptionProvider.Encrypt("image", key.PublicKey);
            var origin = RSAEncryptionProvider.Decrypt(signature, key.PrivateKey);
            Assert.Equal("image", origin);
        }

        [Fact]
        public void EncryptDecrypt_R4096_XML_Test() {
            var key = RSAEncryptionProvider.CreateKey(RSAKeySizeTypes.R4096);
            var signature = RSAEncryptionProvider.Encrypt("image", key.PublicKey);
            var origin = RSAEncryptionProvider.Decrypt(signature, key.PrivateKey);
            Assert.Equal("image", origin);
        }

        [Fact]
        public void EncryptDecrypt_R1024_JSON_Test() {
            var key = RSAEncryptionProvider.CreateKey(RSAKeySizeTypes.R1024, RSAKeyTypes.JSON);
            var signature = RSAEncryptionProvider.Encrypt("image", key.PublicKey, keyType: RSAKeyTypes.JSON);
            var origin = RSAEncryptionProvider.Decrypt(signature, key.PrivateKey, keyType: RSAKeyTypes.JSON);
            Assert.Equal("image", origin);
        }

        [Fact]
        public void EncryptDecrypt_R2048_JSON_Test() {
            var key = RSAEncryptionProvider.CreateKey(keyType: RSAKeyTypes.JSON);
            var signature = RSAEncryptionProvider.Encrypt("image", key.PublicKey, keyType: RSAKeyTypes.JSON);
            var origin = RSAEncryptionProvider.Decrypt(signature, key.PrivateKey, keyType: RSAKeyTypes.JSON);
            Assert.Equal("image", origin);
        }

        [Fact]
        public void EncryptDecrypt_R3072_JSON_Test() {
            var key = RSAEncryptionProvider.CreateKey(RSAKeySizeTypes.R3072, RSAKeyTypes.JSON);
            var signature = RSAEncryptionProvider.Encrypt("image", key.PublicKey, keyType: RSAKeyTypes.JSON);
            var origin = RSAEncryptionProvider.Decrypt(signature, key.PrivateKey, keyType: RSAKeyTypes.JSON);
            Assert.Equal("image", origin);
        }

        [Fact]
        public void EncryptDecrypt_R4096_JSON_Test() {
            var key = RSAEncryptionProvider.CreateKey(RSAKeySizeTypes.R4096, RSAKeyTypes.JSON);
            var signature = RSAEncryptionProvider.Encrypt("image", key.PublicKey, keyType: RSAKeyTypes.JSON);
            var origin = RSAEncryptionProvider.Decrypt(signature, key.PrivateKey, keyType: RSAKeyTypes.JSON);
            Assert.Equal("image", origin);
        }
    }
}