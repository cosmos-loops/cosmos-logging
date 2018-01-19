using System;
using System.Collections.Generic;
using Cosmos.Logging.Formattings.Helpers;

namespace Cosmos.Logging.Formattings {
    public static class FormatCommandFactory {
        public static IEnumerable<Func<object, IFormatProvider, object>> CreateCommandFunc(string format = null) {
            if (format == null || string.IsNullOrWhiteSpace(format)) yield break;

            if (StringHelper.Check(out var cmd0, format) && (cmd0 == 'S' || cmd0 == 's')) {
                yield return StringHelper.Format()(cmd0);
            }

            if (CasingHelper.Check(out var cmd1, format) && (cmd1 == 'U' || cmd1 == 'w')) {
                yield return CasingHelper.Format()(cmd1);
            }

            if (PaddingHelper.Check(out var cmd2, out var width, format) && (cmd2 == 'r' || cmd2 == 'l')) {
                yield return PaddingHelper.Format()(cmd2)(width);
            }

            if (JsonHelper.Check(format)) {
                yield return JsonHelper.Format;
            }
        }

        public static IEnumerable<FormatEvent> CreateCommandEvent(string format = null) {
            if (format == null || string.IsNullOrWhiteSpace(format)) yield break;

            if (StringHelper.Check(out var cmd0, format) && (cmd0 == 'S' || cmd0 == 's')) {
                yield return new FormatEvent(cmd0, 9000, StringHelper.Format()(cmd0));
            }

            if (CasingHelper.Check(out var cmd1, format) && (cmd1 == 'U' || cmd1 == 'w')) {
                yield return new FormatEvent(cmd1, 10000, CasingHelper.Format()(cmd1));
            }

            if (PaddingHelper.Check(out var cmd2, out var width, format) && (cmd2 == 'r' || cmd2 == 'l')) {
                yield return new FormatEvent(cmd2, 10001, PaddingHelper.Format()(cmd2)(width));
            }

            if (JsonHelper.Check(format)) {
                yield return new FormatEvent('j', 99999, JsonHelper.Format);
            }
        }
    }
}