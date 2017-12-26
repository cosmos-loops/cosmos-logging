using Xunit;

namespace Cosmos.Encryption.Tests.Symmetric {
    public class AesTests {
        [Fact]
        public void Encrypt_L128_Test() {
            var key = AESEncryptionProvider.CreateKey();
            //var s0 = AESEncryptionProvider.Encrypt("image", key);
            var s1 = AESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, keySize: AESKeySizeTypes.L128);
            //Assert.Equal("en1cF/ZazqA+y3oIuJNb/Q==", s0);
            //Assert.Equal("en1cF/ZazqA+y3oIuJNb/Q==", s1);
            //var o0 = AESEncryptionProvider.Decrypt(s0, key);
            var o1 = AESEncryptionProvider.Decrypt(s1, key.Key, key.IV, keySize: AESKeySizeTypes.L128);
            //Assert.Equal("image", o0);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o1);
        }

        [Fact]
        public void Encrypt_L192_Test() {
            var key = AESEncryptionProvider.CreateKey();
            var s = AESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, keySize: AESKeySizeTypes.L192);
            var o = AESEncryptionProvider.Decrypt(s, key.Key, key.IV, keySize: AESKeySizeTypes.L192);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o);
        }

        [Fact]
        public void Encrypt_L256_Test() {
            var key = AESEncryptionProvider.CreateKey();
            var s = AESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, keySize: AESKeySizeTypes.L256);
            var o = AESEncryptionProvider.Decrypt(s, key.Key, key.IV, keySize: AESKeySizeTypes.L256);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o);
        }

        [Fact]
        public void Encrypt_L128_WithSalt_Test() {
            var key = AESEncryptionProvider.CreateKey();
            var s1 = AESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, "12345678", keySize: AESKeySizeTypes.L128);
            var o1 = AESEncryptionProvider.Decrypt(s1, key.Key, key.IV, "12345678", keySize: AESKeySizeTypes.L128);
            //Assert.Equal("image", o0);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o1);
        }

        [Fact]
        public void Encrypt_L192_WithSalt_Test() {
            var key = AESEncryptionProvider.CreateKey();
            var s = AESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, "12345678", keySize: AESKeySizeTypes.L192);
            var o = AESEncryptionProvider.Decrypt(s, key.Key, key.IV, "12345678", keySize: AESKeySizeTypes.L192);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o);
        }

        [Fact]
        public void Encrypt_L256_WithSalt_Test() {
            var key = AESEncryptionProvider.CreateKey();
            var s = AESEncryptionProvider.Encrypt("实现中华民族伟大复兴的中国梦", key.Key, key.IV, "12345678", keySize: AESKeySizeTypes.L256);
            var o = AESEncryptionProvider.Decrypt(s, key.Key, key.IV, "12345678", keySize: AESKeySizeTypes.L256);
            Assert.Equal("实现中华民族伟大复兴的中国梦", o);
        }
    }
}