namespace Cosmos.Logging.Core.Callers {
    public struct NullLogCallerInfo : ILogCallerInfo {
        public static readonly NullLogCallerInfo Instance = new NullLogCallerInfo();
        
        public string MemberName => null;
        public string FilePath => null;
        public int LineNumber => 0;

        public dynamic ToParams() => null;
    }
}