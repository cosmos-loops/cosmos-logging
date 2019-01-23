using System.Globalization;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class BaseTypeExtensions
    {
        public static double GetNumericValue(this char c)
        {
            return char.GetNumericValue(c);
        }

        public static UnicodeCategory GetUnicodeCategory(this char c)
        {
            return char.GetUnicodeCategory(c);
        }

        public static char ToLower(this char c)
        {
            return char.ToLower(c);
        }

        public static char ToLower(this char c, CultureInfo culture)
        {
            return char.ToLower(c, culture);
        }

        public static char ToLowerInvariant(this char c)
        {
            return char.ToLowerInvariant(c);
        }

        public static bool IsUpper(this char c)
        {
            return char.IsUpper(c);
        }

        public static char ToUpper(this char c, CultureInfo culture)
        {
            return char.ToUpper(c, culture);
        }

        public static char ToUpperInvariant(this char c)
        {
            return char.ToUpperInvariant(c);
        }

        public static string ToString(this char c)
        {
            return char.ToString(c);
        }

        public static int ConvertToUtf32(this char highSurrogate, char lowSurrogate)
        {
            return char.ConvertToUtf32(highSurrogate, lowSurrogate);
        }

        public static bool IsSurrogate(this char c)
        {
            return char.IsSurrogate(c);
        }

        public static bool IsSurrogatePair(this char highSurrogate, char lowSurrogate)
        {
            return char.IsSurrogatePair(highSurrogate, lowSurrogate);
        }

        public static bool IsHighSurrogate(this char c)
        {
            return char.IsHighSurrogate(c);
        }

        public static bool IsLowSurrogate(this char c)
        {
            return char.IsLowSurrogate(c);
        }
    }
}