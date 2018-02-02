namespace Cosmos.Logging.Core.Callers {
    public interface ILogCallerInfo {
        string MemberName { get; }
        string FilePath { get; }
        int LineNumber { get; }
        dynamic ToParams();
    }
}