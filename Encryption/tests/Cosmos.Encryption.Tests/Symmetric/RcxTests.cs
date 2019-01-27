using Xunit;

namespace Cosmos.Encryption.Tests.Symmetric
{
    public class RcxTests
    {
        [Fact]
        public void Encrypt() {
            var s = RCXEncryptionProvider.Encrypt("ABCDDDDDDDDDDDDDDDDDDDDDD", "alexinea");
            Assert.Equal("C+YxcfWRWMVCIjbX21qXcG9OXq25jJTHmw==", s);
        }
        
        [Fact]
        public void Encrypt_ThreeRCX() {
            var s = ThreeRCXEncryptionProvider.Encrypt("ABCDDDDDDDDDDDDDDDDDDDDDD", "alexinea");
            Assert.Equal("JPTCrl2N6xae4GCEXfzUiSa9YrwSa80HDg==", s);
        }

        [Fact]
        public void Decrypt() {
            var o = RCXEncryptionProvider.Decrypt("C+YxcfWRWMVCIjbX21qXcG9OXq25jJTHmw==", "alexinea");
            Assert.Equal("ABCDDDDDDDDDDDDDDDDDDDDDD", o);
        }
        
        [Fact]
        public void Decrypt_ThreeRCX() {
            var o = ThreeRCXEncryptionProvider.Decrypt("JPTCrl2N6xae4GCEXfzUiSa9YrwSa80HDg==", "alexinea");
            Assert.Equal("ABCDDDDDDDDDDDDDDDDDDDDDD", o);
        }
    }
}