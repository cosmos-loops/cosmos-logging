namespace Cosmos.Logging.Core {
    /// <summary>
    /// Expected trace id generator name
    /// </summary>
    public static class ExpectedTraceIdGeneratorName {
        /// <summary>
        /// Gets or sets value of expected trace id generator name
        /// </summary>
        public static string Value { get; set; }

        /// <summary>
        /// Has value or not
        /// </summary>
        /// <returns></returns>
        public static bool HasValue() => !string.IsNullOrWhiteSpace(Value);
    }
}