using Cosmos.Helpers;
using Xunit;

namespace Cosmos.Core.Tests.Helpers
{
    public class BooleanConvertHelperTests
    {
        public class One { }

        [Fact]
        public void ObjectBooleanTest()
        {
            One one = new One();
            One two = null;

            Assert.False(BooleanConvertHelper.ToBoolean(one));
            Assert.False(BooleanConvertHelper.ToBoolean(two));
        }

        [Fact]
        public void ObjectNullableBooleanTest()
        {
            One one = new One();
            One two = null;

            Assert.Null(BooleanConvertHelper.ToNullableBoolean(one));
            Assert.Null(BooleanConvertHelper.ToNullableBoolean(two));
        }

        [Theory]
        [InlineData("yes")]
        [InlineData("1")]
        public void VerbaAliasTrueBooleanTest(string alias)
        {
            Assert.True(BooleanConvertHelper.ToBoolean(alias));
        }

        [Theory]
        [InlineData("no")]
        [InlineData("0")]
        public void VerbaAliasFalseBooleanTest(string alias)
        {
            Assert.False(BooleanConvertHelper.ToBoolean(alias));
        }


        [Theory]
        [InlineData("yes")]
        [InlineData("1")]
        public void VerbaAliasTrueNullableBooleanTest(string alias)
        {
            Assert.True(BooleanConvertHelper.ToNullableBoolean(alias));
        }

        [Theory]
        [InlineData("no")]
        [InlineData("0")]
        public void VerbaAliasFalseNullableBooleanTest(string alias)
        {
            Assert.False(BooleanConvertHelper.ToNullableBoolean(alias));
        }

        [Theory]
        [InlineData("nono")]
        [InlineData("yeah")]
        public void VerbaAliasNullableBooleanTest(string alias)
        {
            Assert.Null(BooleanConvertHelper.ToNullableBoolean(alias));
        }
    }
}
