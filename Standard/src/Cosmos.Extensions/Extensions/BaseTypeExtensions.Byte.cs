using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class BaseTypeExtensions
    {
        public static byte Max(this byte val1, byte val2)
        {
            return Math.Max(val1, val2);
        }

        public static byte Min(this byte val1, byte val2)
        {
            return Math.Min(val1, val2);
        }
    }
}