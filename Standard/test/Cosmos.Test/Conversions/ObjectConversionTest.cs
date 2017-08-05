using System;
using Cosmos.Conversions;
using Xunit;

namespace Cosmos.Test.Conversions
{
    public class ObjectConversionTest
    {
        class One { }

        class Two
        {
            public override string ToString()
            {
                return "i'm two!";
            }
        }

        [Fact]
        public void NullObjectTest()
        {
            var str = ObjectConversion.ToString(null);

            Assert.Equal(string.Empty, str);
        }

        [Fact]
        public void ValueTypeTest()
        {
            var str1 = ObjectConversion.ToString(1);
            var str2 = ObjectConversion.ToString(1.1D);

            Assert.Equal("1", str1);
            Assert.Equal("1.1", str2);
        }

        [Fact]
        public void DatetimeTest()
        {
            var dt = new DateTime(2017, 10, 1, 10, 10, 12, 933);
            var str = ObjectConversion.ToString(dt);
            var expectedStr = dt.ToString();

            Assert.Equal(expectedStr, str);
        }

        [Fact]
        public void GuidTest()
        {
            var guid = new Guid();
            var str1 = guid.ToString();
            var str2 = ObjectConversion.ToString(guid);

            Assert.Equal(str1, str2);
        }

        [Fact]
        public void ObjectTest()
        {
            var one = new One();
            var two = new Two();
            var str1 = ObjectConversion.ToString(one);
            var str2 = ObjectConversion.ToString(two);

            Assert.Equal("Ryui.Converters.Tests.ObjectConvertTests+One", str1);
            Assert.Equal("i'm two!", str2);
        }
    }
}
