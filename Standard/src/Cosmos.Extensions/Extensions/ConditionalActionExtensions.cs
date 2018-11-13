using System;

namespace Cosmos.Extensions
{
    public static class ConditionalActionExtensions
    {
        public static void Ifttt(this bool condition, Action @this, Action that)
        {
            if (condition)
            {
                @this?.Invoke();
            }
            else
            {
                that?.Invoke();
            }
        }

        public static void IfTure(this bool condition, Action action)
        {
            if (condition)
            {
                action?.Invoke();
            }
        }

        public static void IfFalse(this bool condition, Action action)
        {
            if (!condition)
            {
                action?.Invoke();
            }
        }

        public static void IfNullOrWhiteSpace(this string @string, Action action)
        {
            if (string.IsNullOrWhiteSpace(@string))
            {
                action?.Invoke();
            }
        }

        public static void IfNotNullNorSpace(this string @string, Action action)
        {
            if (!string.IsNullOrWhiteSpace(@string))
            {
                action?.Invoke();
            }
        }
    }
}