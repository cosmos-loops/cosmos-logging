namespace Cosmos.Logging.Trace {
    /// <summary>
    /// Log trace id helper
    /// </summary>
    public static class LogTraceId {
        public static string Get() => LogTraceIdGenerator.Current.Create();
    }
}