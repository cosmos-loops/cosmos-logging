using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cosmos.Helpers;
using Xunit;

namespace Cosmos.Core.Tests.Helpers
{
    public class GenericConvertHelperTest
    {
        class One { }

        class Two : One { }

        [Fact]
        public void NullObjTest()
        {
            One one = null;
            var one1 = GenericConvertHelper.To<One>(one);

            Assert.Equal(default(One), one1);
        }

        [Fact]
        public void NullValueTypeTest()
        {
            var i = GenericConvertHelper.To<int>(null);

            Assert.Equal(default(int), i);
        }

        [Theory]
        [InlineData(1.0001D)]
        public void ValueTypeTest(double input)
        {
            var i = GenericConvertHelper.To<int>(input);

            Assert.Equal(1, i);
        }

        [Fact]
        public void PartnetClassTest()
        {
            One one = new Two();
            var one1 = GenericConvertHelper.To<One>(one);
            var two1 = GenericConvertHelper.To<Two>(one);

            Assert.Equal(typeof(Two), one1.GetType());
            Assert.Equal(typeof(Two), two1.GetType());
        }

        [Fact]
        public void BoxedValueTypeTest()
        {
            int i = 100;
            object o = (object)i;
            var i2 = GenericConvertHelper.To<int>(o);

            Assert.Equal(100, i2);
        }

        [Fact]
        public void ObjectToListTest()
        {
            object list = new List<string> { "1", "2", "3" };
            var list2 = GenericConvertHelper.To<List<string>>(list);

            Assert.Equal(3, list2.Count);
            Assert.Equal("1", list2[0]);
        }

        [Fact]
        public void ObjectValueListFalureTest()
        {
            object list = new List<string> { "1", "2", "3" };
            var list2 = GenericConvertHelper.To<List<One>>(list);
            var def = default(List<One>);

            Assert.Equal(def, list2);
        }

        [Theory]
        [InlineData("1,2,3,4,5")]
        [InlineData("1,2,3,4,5,")]
        [InlineData("1.1D,2.2D,3.3D,4.4D,5.5D")]
        [InlineData("1.1D,2.2D,3.3D,4.4D,5.5D,")]
        public void IntegerListTest(string str)
        {
            var list = GenericConvertHelper.ToList<int>(str);

            Assert.NotNull(list);
            Assert.Equal(5, list.Count());
            Assert.Equal(1, list.First());
        }

        [Theory]
        [InlineData("1.1D,2.2D,3.3D,4.4D,5.5D")]
        [InlineData("1.1D,2.2D,3.3D,4.4D,5.5D,")]
        public void DoubleListTest(string str)
        {
            var list = GenericConvertHelper.ToList<double>(str);

            Assert.NotNull(list);
            Assert.Equal(5, list.Count());
            Assert.Equal(1, list.First());
        }

        [Theory]
        [InlineData("")]
        [InlineData(",,,,,")]
        public void EmptyListTest(string str)
        {
            var list = GenericConvertHelper.ToList<int>(str);
            var list1 = GenericConvertHelper.ToList<One>(str);

            Assert.NotNull(list);
            Assert.NotNull(list1);
            Assert.Equal(0, list.Count());
            Assert.Equal(0, list1.Count());
            Assert.Empty(list);
            Assert.Empty(list1);
        }
    }
}
