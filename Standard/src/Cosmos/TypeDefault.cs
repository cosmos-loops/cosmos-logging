using System;

namespace Cosmos
{
    public static class TypeDefault
    {
        public static TValue Of<TValue>() => default(TValue);

        public static int Int => default(int);

        public static long Long => default(long);

        public static float Float => default(float);

        public static double Double => default(double);

        public static decimal Decimal => default(decimal);

        public static string String => default(string);

        public static string StringEmpty => string.Empty;

        public static DateTime DateTime => default(DateTime);

        public static TimeSpan TimeSpan => default(TimeSpan);
    }
}