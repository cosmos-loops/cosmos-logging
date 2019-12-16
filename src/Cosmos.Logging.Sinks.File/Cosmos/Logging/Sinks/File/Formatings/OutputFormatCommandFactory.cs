using System;
using System.Collections.Generic;
using Cosmos.Logging.Formattings;
using Cosmos.Logging.Sinks.File.Formatings.Helpers;

namespace Cosmos.Logging.Sinks.File.Formatings {
    /// <summary>
    /// Output format command factory
    /// </summary>
    public static class OutputFormatCommandFactory {
        public static IEnumerable<Func<object, IFormatProvider, object>> CreateCommandFunc(string format = null) {
            if (format == null || string.IsNullOrWhiteSpace(format)) yield break;

            if (CallerInfoHelper.Check(out var cmd3, format) && !string.IsNullOrWhiteSpace(cmd3)) {
                yield return CallerInfoHelper.Format()(cmd3);
            }

            if (EventInfoHelper.Check(out var cmd4, format) && !string.IsNullOrWhiteSpace(cmd4)) {
                yield return EventInfoHelper.Format()(cmd4);
            }

            if (CasingHelper.Check(out var cmd1, format) && (cmd1 == 'U' || cmd1 == 'w')) {
                yield return CasingHelper.Format()(cmd1);
            }

            if (PaddingHelper.Check(out var cmd2, out var width, format) && (cmd2 == 'r' || cmd2 == 'l')) {
                yield return PaddingHelper.Format()(cmd2)(width);
            }
        }

        public static IEnumerable<FormatEvent> CreateCommandEvent(string format = null) {
            if (format == null || string.IsNullOrWhiteSpace(format)) yield break;

            if (CasingHelper.Check(out var cmd1, format) && (cmd1 == 'U' || cmd1 == 'w')) {
                yield return new FormatEvent(cmd1, 10000, CasingHelper.Format()(cmd1));
            }

            if (PaddingHelper.Check(out var cmd2, out var width, format) && (cmd2 == 'r' || cmd2 == 'l')) {
                yield return new FormatEvent(cmd2, 10001, PaddingHelper.Format()(cmd2)(width));
            }

            if (CallerInfoHelper.Check(out var cmd3, format) && !string.IsNullOrWhiteSpace(cmd3)) {
                yield return new FormatEvent(cmd3, 9998, CallerInfoHelper.Format()(cmd3));
            }

            if (EventInfoHelper.Check(out var cmd4, format) && !string.IsNullOrWhiteSpace(cmd4)) {
                yield return new FormatEvent(cmd4, 9999, EventInfoHelper.Format()(cmd4));
            }
        }
    }
}