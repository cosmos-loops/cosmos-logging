using System;
using System.Reflection;
using Cosmos.Judgements;
using Xunit;

namespace Cosmos.Test.Judgements
{
    public class TypeJudgementTest
    {
        [Fact]
        public void IsNumericTest()
        {
            Assert.True(TypeJudgement.IsNumericType(1.GetType()));
            Assert.True(TypeJudgement.IsNumericType(1D.GetType()));
            Assert.True(TypeJudgement.IsNumericType(1F.GetType()));
            Assert.True(TypeJudgement.IsNumericType(1M.GetType()));
            Assert.True(TypeJudgement.IsNumericType(1.001M.GetType()));
            Assert.True(TypeJudgement.IsNumericType(1L.GetType()));

            Assert.True(TypeJudgement.IsNumericType(1.GetType().GetTypeInfo()));
            Assert.True(TypeJudgement.IsNumericType(1D.GetType().GetTypeInfo()));
            Assert.True(TypeJudgement.IsNumericType(1F.GetType().GetTypeInfo()));
            Assert.True(TypeJudgement.IsNumericType(1M.GetType().GetTypeInfo()));
            Assert.True(TypeJudgement.IsNumericType(1.001M.GetType().GetTypeInfo()));
            Assert.True(TypeJudgement.IsNumericType(1L.GetType().GetTypeInfo()));
        }

        [Fact]
        public void IsNullableType()
        {
            Assert.True(TypeJudgement.IsNullableType(typeof(int?)));
            Assert.True(TypeJudgement.IsNullableType(typeof(Nullable<System.Int32>)));

            Assert.True(TypeJudgement.IsNullableType(typeof(int?).GetTypeInfo()));
        }
    }
}
