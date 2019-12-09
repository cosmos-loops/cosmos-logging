using System;
using System.Collections.Generic;
using Cosmos.Logging.Formattings.Helpers;

namespace Cosmos.Logging.Formattings {
    /// <summary>
    /// Format command factory
    /// </summary>
    public static class FormatCommandFactory {
        /// <summary>
        /// Create command func
        /// </summary>
        /// <param name="format"></param>
        /// <param name="customFormatProvider"></param>
        /// <returns></returns>
        public static IEnumerable<Func<object, IFormatProvider, object>> CreateCommandFunc(
            string format = null,
            Func<string, IEnumerable<Func<object, IFormatProvider, object>>> customFormatProvider = null) {
            if (format == null || string.IsNullOrWhiteSpace(format)) yield break;

            if (CasingHelper.Check(out var cmd1, format) && (cmd1 == 'U' || cmd1 == 'w')) {
                yield return CasingHelper.Format()(cmd1);
            }

            if (PaddingHelper.Check(out var cmd2, out var width, format) && (cmd2 == 'r' || cmd2 == 'l')) {
                yield return PaddingHelper.Format()(cmd2)(width);
            }

            if (JsonHelper.Check(format)) {
                yield return JsonHelper.Format;
            }

            if (customFormatProvider != null) {
                var additionalFormatFuncs = customFormatProvider.Invoke(format);
                foreach (var f in additionalFormatFuncs)
                    yield return f;
            }
        }

        /// <summary>
        /// Create command event
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static IEnumerable<FormatEvent> CreateCommandEvent(string format = null) {
            if (format == null || string.IsNullOrWhiteSpace(format)) yield break;

            if (CasingHelper.Check(out var cmd1, format) && (cmd1 == 'U' || cmd1 == 'w')) {
                yield return new FormatEvent(cmd1, 10000, CasingHelper.Format()(cmd1));
            }

            if (PaddingHelper.Check(out var cmd2, out var width, format) && (cmd2 == 'r' || cmd2 == 'l')) {
                yield return new FormatEvent(cmd2, 10001, PaddingHelper.Format()(cmd2)(width));
            }

            if (JsonHelper.Check(format)) {
                yield return new FormatEvent('j', 99999, JsonHelper.Format);
            }

            foreach (var provider in CustomFormatProviderManager.Get()) {
                if (provider != null) {
                    var additionalFormats = provider.Invoke(format);
                    foreach (var f in additionalFormats)
                        yield return f;
                }
            }
        }
    }
}