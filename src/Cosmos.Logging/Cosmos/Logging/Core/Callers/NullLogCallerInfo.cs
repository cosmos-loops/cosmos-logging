namespace Cosmos.Logging.Core.Callers {
    /// <summary>
    /// Null log caller info
    /// </summary>
    public struct NullLogCallerInfo : ILogCallerInfo {
        /// <summary>
        /// Get an instance of <see cref="NullLogCallerInfo"/>
        /// </summary>
        public static readonly NullLogCallerInfo Instance = new NullLogCallerInfo();

        /// <inheritdoc />
        public string MemberName => null;

        /// <inheritdoc />
        public string FilePath => null;

        /// <inheritdoc />
        public int LineNumber => 0;

        /// <inheritdoc />
        public dynamic ToParams() => null;
    }
}