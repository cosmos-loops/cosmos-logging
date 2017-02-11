using System;
using Cosmos.Helpers;
using Xunit;

namespace Cosmos.Core.Tests.Helpers
{
    public class ObjectConvertHelperTests
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
            var str = ObjectConvertHelper.ToString(null);

            Assert.Equal(string.Empty, str);
        }

        [Fact]
        public void ValueTypeTest()
        {
            var str1 = ObjectConvertHelper.ToString(1);
            var str2 = ObjectConvertHelper.ToString(1.1D);

            Assert.Equal("1", str1);
            Assert.Equal("1.1", str2);
        }

        [Fact]
        public void DatetimeTest()
        {
            var dt = new DateTime(2017, 10, 1, 10, 10, 12, 933);
            var str = ObjectConvertHelper.ToString(dt);

            Assert.Equal("2017/10/1 10:10:12", str);
        }

        [Fact]
        public void GuidTest()
        {
            var guid = new Guid();
            var str1 = guid.ToString();
            var str2 = ObjectConvertHelper.ToString(guid);

            Assert.Equal(str1, str2);
        }

        [Fact]
        public void ObjectTest()
        {
            var one = new One();
            var two = new Two();
            var str1 = ObjectConvertHelper.ToString(one);
            var str2 = ObjectConvertHelper.ToString(two);

            Assert.Equal("Cosmos.Core.Tests.Helpers.ObjectConvertHelperTests+One", str1);
            Assert.Equal("i'm two!", str2);
        }
    }
}
