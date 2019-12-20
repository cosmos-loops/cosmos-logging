using System;
using System.Collections.Generic;

namespace Cosmos.Logging.Formattings {
    /// <summary>
    /// Custom format provider manager
    /// </summary>
    public static class CustomFormatProviderManager {
        private static readonly Dictionary<string, List<Func<string, IEnumerable<FormatEvent>>>> CustomFormatProviders;
        private static readonly List<Func<string, IEnumerable<FormatEvent>>> EmptyProviders = new List<Func<string, IEnumerable<FormatEvent>>>();

        static CustomFormatProviderManager() {
            CustomFormatProviders = new Dictionary<string, List<Func<string, IEnumerable<FormatEvent>>>>();
        }

        internal static void Add(string rendererName, Func<string, IEnumerable<FormatEvent>> provider) {
            if (!string.IsNullOrWhiteSpace(rendererName) && provider != null) {
                if (CustomFormatProviders.TryGetValue(rendererName, out var customFormatProviders)) {
                    customFormatProviders.Add(provider);
                }
                else {
                    customFormatProviders = new List<Func<string, IEnumerable<FormatEvent>>> {provider};
                    CustomFormatProviders.Add(rendererName, customFormatProviders);
                }
            }
        }

        /// <summary>
        /// Get custom format events
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyCollection<Func<string, IEnumerable<FormatEvent>>> Get(string rendererName) {
            return CustomFormatProviders.TryGetValue(rendererName.ToLowerInvariant(), out var rendererFuncProviders)
                ? rendererFuncProviders
                : EmptyProviders;
        }
    }
}