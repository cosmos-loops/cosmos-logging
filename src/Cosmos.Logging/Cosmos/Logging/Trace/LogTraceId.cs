namespace Cosmos.Logging.Trace {
    /// <summary>
    /// Log trace id helper
    /// </summary>
    public static class LogTraceId {
        /// <summary>
        /// Get current log trace id generator and create/get log trace id
        /// </summary>
        /// <returns></returns>
        public static string Get() => LogTraceIdGenerator.Current.Create();
    }
}