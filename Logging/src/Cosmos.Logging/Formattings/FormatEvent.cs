using System;

namespace Cosmos.Logging.Formattings {
    public struct FormatEvent {
        public int Sort { get; }
        public Func<object, IFormatProvider, object> Command { get; }

        public FormatEvent(int sort, Func<object, IFormatProvider, object> cmd) {
            Sort = sort;
            Command = cmd;
        }
    }
}