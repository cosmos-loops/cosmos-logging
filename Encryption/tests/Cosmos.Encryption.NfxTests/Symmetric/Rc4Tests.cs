using Xunit;

namespace Cosmos.Encryption.Tests.Symmetric {
    public class Rc4Tests {
        [Fact]
        public void Encrypt() {
            var s = RC4EncryptionProvider.Encrypt("image", "alexinea");
            Assert.Equal("I2YRaZo=", s);
        }

        [Fact]
        public void Decrypt() {
            var o = RC4EncryptionProvider.Decrypt("I2YRaZo=", "alexinea");
            Assert.Equal("image", o);
        }
    }
}