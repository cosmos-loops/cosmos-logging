namespace Cosmos.Encryption.Core.Internals.Extensions
{
    internal static class StringExtensions
    {
        public static string ReplaceToEmpty(this string str, string oldValue)
        {
            return str.Replace(oldValue, "");
        }
    }
}