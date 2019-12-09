using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Formattings {
    /// <summary>
    /// Custom format provider manager
    /// </summary>
    public static class CustomFormatProviderManager {
        private static readonly List<Func<string, IEnumerable<FormatEvent>>> CustomFormatProviders;

        static CustomFormatProviderManager() {
            CustomFormatProviders = new List<Func<string, IEnumerable<FormatEvent>>>();
        }

        internal static void Add(Func<string, IEnumerable<FormatEvent>> provider) {
            if (provider != null) {
                CustomFormatProviders.Add(provider);
            }
        }

        /// <summary>
        /// Get custom format events
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyCollection<Func<string, IEnumerable<FormatEvent>>> Get() => CustomFormatProviders;
    }
}