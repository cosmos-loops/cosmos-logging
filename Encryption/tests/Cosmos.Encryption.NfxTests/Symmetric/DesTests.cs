using Xunit;

namespace Cosmos.Encryption.Tests.Symmetric {
    public class DesTests {
        [Fact]
        public void EncryptDecrypt_Test() {
            var s = DESEncryptionProvider.Encrypt("image", "alexinea", "forerunner");
            Assert.Equal("fJ2yrnAPaH0=", s);

            var o = DESEncryptionProvider.Decrypt(s, "alexinea", "forerunner");
            Assert.Equal("image", o);
        }

        [Fact]
        public void EncryptDecrypt_WithSalt_Test() {
            var s = DESEncryptionProvider.Encrypt("image", "alexinea", "forerunner", "123412341234");
            Assert.Equal("s4h5u8hA/2Y=", s);

            var o = DESEncryptionProvider.Decrypt(s, "alexinea", "forerunner", "123412341234");
            Assert.Equal("image", o);
        }

        [Fact]
        public void EncryptDecrypt_WithAutoCreateKey_Test() {
            var key = DESEncryptionProvider.CreateKey();
            var s = DESEncryptionProvider.Encrypt("image", key.Key, key.IV);
            var o = DESEncryptionProvider.Decrypt(s, key.Key, key.IV);
            Assert.Equal("image", o);
        }

        [Fact]
        public void EncryptDecrypt_WithSalt_WithAutoCreateKey_Test() {
            var key = DESEncryptionProvider.CreateKey();
            var s = DESEncryptionProvider.Encrypt("image", key.Key, key.IV, "123412341234");
            var o = DESEncryptionProvider.Decrypt(s, key.Key, key.IV, "123412341234");
            Assert.Equal("image", o);
        }
    }
}