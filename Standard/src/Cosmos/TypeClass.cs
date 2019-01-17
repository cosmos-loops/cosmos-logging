using System;

namespace Cosmos
{
    public static class TypeClass
    {
        public static Type Int32Class { get; } = typeof(int);

        public static Type Int32NullableClass { get; } = typeof(int?);

        public static Type Int64Class { get; } = typeof(long);

        public static Type Int64NullableClass { get; } = typeof(long?);

        public static Type IntClass => Int32Class;

        public static Type IntNullableClass => Int32NullableClass;

        public static Type LongClass => Int64Class;

        public static Type LongNullableClass => Int64NullableClass;

        public static Type FloatClass { get; } = typeof(float);

        public static Type FloatNullableClass { get; } = typeof(float?);

        public static Type DoubleClass { get; } = typeof(double);

        public static Type DoubleNullableClass { get; } = typeof(double?);

        public static Type DecimalClass { get; } = typeof(decimal);

        public static Type DecimalNullableClass { get; } = typeof(decimal?);

        public static Type StringClass { get; } = typeof(string);

        public static Type DateTimeClass { get; } = typeof(DateTime);

        public static Type DateTimeNullableClass { get; } = typeof(DateTime?);

        public static Type TimeSpanClass { get; } = typeof(TimeSpan);

        public static Type TimeSpanNullableClass { get; } = typeof(TimeSpan?);
    }
}