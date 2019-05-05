using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.File.Formatings.Helpers {
    public static class EventInfoHelper {
        internal static bool Check(out string command, string format = null) {
            command = string.Empty;
            List<char> flash = new List<char>();
            if (format == null || string.IsNullOrWhiteSpace(format)) return false;
            var position = 0;
            while (position < format.Length) {
                var c = format[position];
                switch (c) {
                    case 'I': //EventId.Id
                    case 'N': //EventId.Name
                        flash.Add(c);
                        break;
                }

                position++;
            }

            command = string.Join("", flash.Distinct());

            return !string.IsNullOrWhiteSpace(command);
        }

        public static Func<string, Func<object, IFormatProvider, object>> Format() => FormatInternal;

        private static Func<object, IFormatProvider, object> FormatInternal(string cmdAlias2) => (value, formatProvider) => {
            switch (value) {
                case LogEvent logEvent: return Internals.InternalEventInfoHelper.GetEventInfoString(logEvent, cmdAlias2);
                case string s: return s;
                default: return string.Empty;
            }
        };
    }
}