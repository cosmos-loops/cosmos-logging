namespace Cosmos.Logging.Core.Callers {
    /// <summary>
    /// Log caller info
    /// </summary>
    public struct LogCallerInfo : ILogCallerInfo {
        /// <summary>
        /// Create a new instance of <see cref="LogCallerInfo"/>
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public LogCallerInfo(string memberName, string filePath = null, int lineNumber = 0) {
            MemberName = memberName;
            FilePath = filePath;
            LineNumber = lineNumber;
        }

        /// <inheritdoc />
        public string MemberName { get; }

        /// <inheritdoc />
        public string FilePath { get; }

        /// <inheritdoc />
        public int LineNumber { get; }

        /// <inheritdoc />
        public dynamic ToParams() => new {MemberName, FilePath, LineNumber};
    }
}