using Xunit;

namespace Cosmos.Encryption.NfxTests.Hash {
    public class Md4Tests {
        [Fact]
        public void Md5_bit16() {
            var signature = MD4HashingProvider.Signature("image");
            Assert.Equal("0849E54FDE86FE2091E1B8FB5713BE65", signature);
        }
    }
}