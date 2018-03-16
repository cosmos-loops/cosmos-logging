using System;

namespace Cosmos.Logging.Formattings {
    public struct FormatEvent {
        public int Sort { get; }
        public char CmdAlias { get; }
        public string CmdAlias2 { get; }
        public Func<object, IFormatProvider, object> Command { get; }

        public FormatEvent(char cmdAlias, int sort, Func<object, IFormatProvider, object> cmd) {
            CmdAlias = cmdAlias;
            CmdAlias2 = $"{cmd}";
            Sort = sort;
            Command = cmd;
        }

        public FormatEvent(string cmdAlias, int sort, Func<object, IFormatProvider, object> cmd) {
            CmdAlias = char.MinValue;
            CmdAlias2 = cmdAlias;
            Sort = sort;
            Command = cmd;
        }
    }
}