using Xunit;

namespace Cosmos.Encryption.Tests.Symmetric {
    public class TripleDesTests {
        [Fact]
        public void EncryptDecrypt_L128_Test() {
            var s = TripleDESEncryptionProvider.Encrypt("image", "alexinea&#%12!", "forerunner", keySize: TripleDESKeySizeTypes.L128);
            Assert.Equal("pG8iQQQVIQY=", s);

            var o = TripleDESEncryptionProvider.Decrypt(s, "alexinea&#%12!", "forerunner", keySize: TripleDESKeySizeTypes.L128);
            Assert.Equal("image", o);
        }

        [Fact]
        public void EncryptDecrypt_WithSalt_L128_Test() {
            var s = TripleDESEncryptionProvider.Encrypt("image", "alexinea&#%12!", "forerunner", "123412341234", keySize: TripleDESKeySizeTypes.L128);
            Assert.Equal("A1Wq2SHzNwU=", s);

            var o = TripleDESEncryptionProvider.Decrypt(s, "alexinea&#%12!", "forerunner", "123412341234", keySize: TripleDESKeySizeTypes.L128);
            Assert.Equal("image", o);
        }

        [Fact]
        public void EncryptDecrypt_L192_Test() {
            var s = TripleDESEncryptionProvider.Encrypt("image", "alexinea&#%12!", "forerunner", keySize: TripleDESKeySizeTypes.L192);
            Assert.Equal("Y6tAf/GrLx8=", s);

            var o = TripleDESEncryptionProvider.Decrypt(s, "alexinea&#%12!", "forerunner", keySize: TripleDESKeySizeTypes.L192);
            Assert.Equal("image", o);
        }

        [Fact]
        public void EncryptDecrypt_WithSalt_L192_Test() {
            var s = TripleDESEncryptionProvider.Encrypt("image", "alexinea&#%12!", "forerunner", "123412341234", keySize: TripleDESKeySizeTypes.L192);
            Assert.Equal("nmTHXan4jN8=", s);

            var o = TripleDESEncryptionProvider.Decrypt(s, "alexinea&#%12!", "forerunner", "123412341234", keySize: TripleDESKeySizeTypes.L192);
            Assert.Equal("image", o);
        }


        [Fact]
        public void EncryptDecrypt_WithAutoCreateKey_L128_Test() {
            var key = TripleDESEncryptionProvider.CreateKey(TripleDESKeySizeTypes.L128);
            var s = TripleDESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, keySize: TripleDESKeySizeTypes.L128);
            var o = TripleDESEncryptionProvider.Decrypt(s, key.Key, key.IV, keySize: TripleDESKeySizeTypes.L128);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o);
        }

        [Fact]
        public void EncryptDecrypt_WithSalt_WithAutoCreateKey_L128_Test() {
            var key = TripleDESEncryptionProvider.CreateKey(TripleDESKeySizeTypes.L128);
            var s = TripleDESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, "123412341234", keySize: TripleDESKeySizeTypes.L128);
            var o = TripleDESEncryptionProvider.Decrypt(s, key.Key, key.IV, "123412341234", keySize: TripleDESKeySizeTypes.L128);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o);
        }

        [Fact]
        public void EncryptDecrypt_WithAutoCreateKey_L192_Test() {
            var key = TripleDESEncryptionProvider.CreateKey(TripleDESKeySizeTypes.L192);
            var s = TripleDESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, keySize: TripleDESKeySizeTypes.L192);
            var o = TripleDESEncryptionProvider.Decrypt(s, key.Key, key.IV, keySize: TripleDESKeySizeTypes.L192);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o);
        }

        [Fact]
        public void EncryptDecrypt_WithSalt_WithAutoCreateKey_L192_Test() {
            var key = TripleDESEncryptionProvider.CreateKey(TripleDESKeySizeTypes.L192);
            var s = TripleDESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, "123412341234", keySize: TripleDESKeySizeTypes.L192);
            var o = TripleDESEncryptionProvider.Decrypt(s, key.Key, key.IV, "123412341234", keySize: TripleDESKeySizeTypes.L192);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o);
        }
    }
}