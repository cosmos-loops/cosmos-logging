namespace Cosmos.Logging.Core.Callers {
    /// <summary>
    /// Interface for LogCallerInfo
    /// </summary>
    public interface ILogCallerInfo {
        /// <summary>
        /// Member name
        /// </summary>
        string MemberName { get; }

        /// <summary>
        /// File path
        /// </summary>
        string FilePath { get; }

        /// <summary>
        /// Line number
        /// </summary>
        int LineNumber { get; }

        /// <summary>
        /// To params
        /// </summary>
        /// <returns></returns>
        dynamic ToParams();
    }
}