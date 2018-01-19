using System;

namespace Cosmos.Logging.Formattings {
    public struct FormatEvent {
        public int Sort { get; }
        public char CmdAlias { get; }
        public Func<object, IFormatProvider, object> Command { get; }

        public FormatEvent(char cmdAlias, int sort, Func<object, IFormatProvider, object> cmd) {
            CmdAlias = cmdAlias;
            Sort = sort;
            Command = cmd;
        }
    }
}