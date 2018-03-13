using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Logging.Events;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Sinks.File.Core.Extensions {
    internal static class FormattingExtensions {
        public static string ToFormat(this IEnumerable<FormatEvent> formattingEvents, string content, IFormatProvider formatProvider = null) {
            return formattingEvents?.OrderBy(x => x.Sort).Aggregate(content, (current, cmd) => cmd.Command(current, formatProvider) as string) ?? content;
        }

        public static string ToFormat(this IList<Func<object, IFormatProvider, object>> formattingFuncs, string content, IFormatProvider formatProvider = null) {
            return formattingFuncs?.Aggregate(content, (current, cmd) => cmd(current, formatProvider) as string) ?? content;
        }

        public static string ToFormat(this IEnumerable<FormatEvent> formattingEvents, LogEvent logEvent, IFormatProvider formatProvider = null) {
            if (formattingEvents == null || !formattingEvents.Any()) return string.Empty;
            var stringBuilder = new StringBuilder();
            foreach (var formattingEvent in formattingEvents.OrderBy(x => x.Sort)) {
                stringBuilder.Append(formattingEvent.Command(logEvent, formatProvider) as string ?? string.Empty);
            }

            return stringBuilder.Length > 0 ? stringBuilder.ToString() : string.Empty;
        }

        public static string ToFormat(this IList<Func<object, IFormatProvider, object>> formattingFuncs, LogEvent logEvent, IFormatProvider formatProvider = null) {
            if (formattingFuncs == null || !formattingFuncs.Any()) return string.Empty;
            var stringBuilder = new StringBuilder();
            foreach (var fun in formattingFuncs) {
                stringBuilder.Append(fun.Invoke(logEvent, formatProvider) as string ?? string.Empty);
            }

            return stringBuilder.Length > 0 ? stringBuilder.ToString() : string.Empty;
        }
    }
}