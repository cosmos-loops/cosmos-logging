using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Formattings;

namespace Cosmos.Logging.Core.Extensions {
    /// <summary>
    /// Extensions for format
    /// </summary>
    public static class FormattingExtensions {
        /// <summary>
        /// TO format
        /// </summary>
        /// <param name="formattingEvents"></param>
        /// <param name="content"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static string ToFormat(this IEnumerable<FormatEvent> formattingEvents, string content, IFormatProvider formatProvider = null) {
            return formattingEvents?.OrderBy(x => x.Sort).Aggregate(content, (current, cmd) => cmd.Command(current, formatProvider) as string) ?? content;
        }

        /// <summary>
        /// TO format
        /// </summary>
        /// <param name="formattingFuncs"></param>
        /// <param name="content"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static string ToFormat(this IList<Func<object, IFormatProvider, object>> formattingFuncs, string content, IFormatProvider formatProvider = null) {
            return formattingFuncs?.Aggregate(content, (current, cmd) => cmd(current, formatProvider) as string) ?? content;
        }
    }
}