using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Sinks.File.Core.Extensions {
    internal static class FormattingExtensions {
        public static string ToFormat(this IEnumerable<FormatEvent> formattingEvents, string content, IFormatProvider formatProvider = null) {
            return formattingEvents?.OrderBy(x => x.Sort).Aggregate(content, (current, cmd) => cmd.Command(current, formatProvider) as string) ?? content;
        }

        public static string ToFormat(this IList<Func<object, IFormatProvider, object>> formattingFuncs, string content, IFormatProvider formatProvider = null) {
            return formattingFuncs?.Aggregate(content, (current, cmd) => cmd(current, formatProvider) as string) ?? content;
        }
    }
}