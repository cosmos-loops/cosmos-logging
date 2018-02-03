namespace Cosmos.Logging.Core.Callers {
    public struct LogCallerInfo : ILogCallerInfo {
        public LogCallerInfo(string memberName, string filePath = null, int lineNumber = 0) {
            MemberName = memberName;
            FilePath = filePath;
            LineNumber = lineNumber;
        }

        public string MemberName { get; }
        public string FilePath { get; }
        public int LineNumber { get; }

        public dynamic ToParams() => new {MemberName, FilePath, LineNumber};
    }
}