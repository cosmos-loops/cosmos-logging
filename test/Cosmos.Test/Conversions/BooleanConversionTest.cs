using Cosmos.Conversions;
using Xunit;

namespace Cosmos.Test.Conversions
{
    public class BooleanConversionTest
    {

        public class One { }

        [Fact]
        public void ObjectBooleanTest()
        {
            One one = new One();
            One two = null;

            Assert.False(BooleanConversion.ToBoolean(one));
            Assert.False(BooleanConversion.ToBoolean(two));
        }

        [Fact]
        public void ObjectNullableBooleanTest()
        {
            One one = new One();
            One two = null;

            Assert.Null(BooleanConversion.ToNullableBoolean(one));
            Assert.Null(BooleanConversion.ToNullableBoolean(two));
        }

        [Theory]
        [InlineData("yes")]
        [InlineData("1")]
        public void VerbaAliasTrueBooleanTest(string alias)
        {
            Assert.True(BooleanConversion.ToBoolean(alias));
        }

        [Theory]
        [InlineData("no")]
        [InlineData("0")]
        public void VerbaAliasFalseBooleanTest(string alias)
        {
            Assert.False(BooleanConversion.ToBoolean(alias));
        }


        [Theory]
        [InlineData("yes")]
        [InlineData("1")]
        public void VerbaAliasTrueNullableBooleanTest(string alias)
        {
            Assert.True(BooleanConversion.ToNullableBoolean(alias));
        }

        [Theory]
        [InlineData("no")]
        [InlineData("0")]
        public void VerbaAliasFalseNullableBooleanTest(string alias)
        {
            Assert.False(BooleanConversion.ToNullableBoolean(alias));
        }

        [Theory]
        [InlineData("nono")]
        [InlineData("yeah")]
        public void VerbaAliasNullableBooleanTest(string alias)
        {
            Assert.Null(BooleanConversion.ToNullableBoolean(alias));
        }
    }
}
