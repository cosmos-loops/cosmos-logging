using System.Collections.Generic;
using Cosmos.Logging.Formattings.Helpers;

namespace Cosmos.Logging.Formattings {
    /// <summary>
    /// Format command factory
    /// </summary>
    public static class FormatCommandFactory {
        /// <summary>
        /// Create command event
        /// </summary>
        /// <param name="rendererName"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static IEnumerable<FormatEvent> CreateCommandEvent(string rendererName, string format = null) {
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

            if (!string.IsNullOrWhiteSpace(rendererName)) {
                foreach (var provider in CustomFormatProviderManager.Get(rendererName)) {
                    if (provider != null) {
                        var additionalFormats = provider.Invoke(format);
                        foreach (var f in additionalFormats)
                            yield return f;
                    }
                }
            }
        }
    }
}