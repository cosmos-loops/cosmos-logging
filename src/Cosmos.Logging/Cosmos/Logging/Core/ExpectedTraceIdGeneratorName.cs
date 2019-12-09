namespace Cosmos.Logging.Core {
    /// <summary>
    /// Expected trace id generator name
    /// </summary>
    public static class ExpectedTraceIdGeneratorName {
        public static string Value { get; set; }
        public static bool HasValue() => !string.IsNullOrWhiteSpace(Value);
    }
}