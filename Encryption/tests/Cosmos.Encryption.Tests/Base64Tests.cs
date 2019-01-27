using System.Text;
using Xunit;

namespace Cosmos.Encryption.Tests {
    public class Base64Tests {
        [Fact]
        public void Base64EncodeTest() {
            Assert.Equal("aW1hZ2U=", Base64ConvertProvider.ToBase64String("image", Encoding.UTF8));
            Assert.Equal("5Lit5Zu9", Base64ConvertProvider.ToBase64String("中国", Encoding.UTF8));
        }
        
        [Fact]
        public void Base64DecodeTest() {
            Assert.Equal("image", Base64ConvertProvider.FromBase64String("aW1hZ2U=", Encoding.UTF8));
            Assert.Equal("中国", Base64ConvertProvider.FromBase64String("5Lit5Zu9", Encoding.UTF8));
        }
    }
}