using System;

namespace Cosmos.Logging.Formattings {
    /// <summary>
    /// Format event
    /// </summary>
    public struct FormatEvent {
        /// <summary>
        /// Sort
        /// </summary>
        public int Sort { get; }

        /// <summary>
        /// Cmd alias
        /// </summary>
        public char CmdAlias { get; }

        /// <summary>
        /// Cmd alias2
        /// </summary>
        public string CmdAlias2 { get; }

        /// <summary>
        /// Command
        /// </summary>
        public Func<object, IFormatProvider, object> Command { get; }

        /// <summary>
        /// Create a new instance of <see cref="FormatEvent"/>.
        /// </summary>
        /// <param name="cmdAlias"></param>
        /// <param name="sort"></param>
        /// <param name="cmd"></param>
        public FormatEvent(char cmdAlias, int sort, Func<object, IFormatProvider, object> cmd) {
            CmdAlias = cmdAlias;
            CmdAlias2 = $"{cmd}";
            Sort = sort;
            Command = cmd;
        }

        /// <summary>
        /// Create a new instance of <see cref="FormatEvent"/>.
        /// </summary>
        /// <param name="cmdAlias"></param>
        /// <param name="sort"></param>
        /// <param name="cmd"></param>
        public FormatEvent(string cmdAlias, int sort, Func<object, IFormatProvider, object> cmd) {
            CmdAlias = char.MinValue;
            CmdAlias2 = cmdAlias;
            Sort = sort;
            Command = cmd;
        }
    }
}