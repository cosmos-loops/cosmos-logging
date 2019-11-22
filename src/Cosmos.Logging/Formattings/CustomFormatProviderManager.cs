using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Formattings
{
    public static class CustomFormatProviderManager
    {
        private static readonly List<Func<string, IEnumerable<FormatEvent>>> CustomFormatProviders;

        static CustomFormatProviderManager()
        {
            CustomFormatProviders = new List<Func<string, IEnumerable<FormatEvent>>>();
        }

        internal static void Add(Func<string, IEnumerable<FormatEvent>> provider)
        {
            if (provider != null)
            {
                CustomFormatProviders.Add(provider);
            }
        }

        public static IReadOnlyCollection<Func<string, IEnumerable<FormatEvent>>> Get() => CustomFormatProviders;
    }
}