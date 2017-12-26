using Xunit;

namespace Cosmos.Encryption.Tests.Hash {
    public class Md5Tests {
        [Fact]
        public void Md5_bit16() {
            var signature = MD5HashingProvider.Signature("image", MD5BitTypes.L16);
            Assert.Equal("1A988E79EF3F42D7", signature);
        }

        [Fact]
        public void Md5_bit32() {
            var signature = MD5HashingProvider.Signature("image", MD5BitTypes.L32);
            Assert.Equal("78805A221A988E79EF3F42D7C5BFD418", signature);
        }

        [Fact]
        public void Md5_bit64() {
            var signature = MD5HashingProvider.Signature("image", MD5BitTypes.L64);
            var signature2 = MD5HashingProvider.Signature("kaka123", MD5BitTypes.L64);

            Assert.Equal("eIBaIhqYjnnvP0LXxb/UGA==", signature);
            Assert.Equal("XQUvHjKvTkrCVEpfwqm5kg==", signature2);
        }
    }
}