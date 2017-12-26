using System.Text;
using Xunit;

namespace Cosmos.Encryption.NfxTests {
    public class Base64Tests {
        [Fact]
        public void Base64EncodeTest() {
            Assert.Equal("aW1hZ2U=", Base64ConvertProvider.Encode("image", Encoding.UTF8));
            Assert.Equal("5Lit5Zu9", Base64ConvertProvider.Encode("中国", Encoding.UTF8));
        }
        
        [Fact]
        public void Base64DecodeTest() {
            Assert.Equal("image", Base64ConvertProvider.Decode("aW1hZ2U=", Encoding.UTF8));
            Assert.Equal("中国", Base64ConvertProvider.Decode("5Lit5Zu9", Encoding.UTF8));
        }
    }
}