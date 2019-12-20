using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Simple {
    /// <summary>
    /// Null simple logger
    /// </summary>
    public sealed class NullSimpleLogger : ISimpleLogger {
        private static readonly NullSimpleLogger NullSimpleLoggerCache;

        static NullSimpleLogger() {
            NullSimpleLoggerCache = new NullSimpleLogger();
        }

        /// <summary>
        /// Gets an instance of <see cref="NullSimpleLogger"/>.
        /// </summary>
        public static NullSimpleLogger Instance => NullSimpleLoggerCache;

        /// <inheritdoc />
        public LogEventLevel MinimumLevel { get; } = LogEventLevel.Off;

        /// <inheritdoc />
        public bool IsEnabled(LogEventLevel level) => false;

        #region Write

        /// <inheritdoc />
        public void LogVerbose(string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogVerbose(Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogDebug(string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogDebug(Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogInformation(string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogInformation(Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogWarning(string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogWarning(Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogError(string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogError(Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogFatal(string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogFatal(Exception exception, string messageTemplate, params object[] args) { }

        #endregion

        #region Write with EventId

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack logTrack, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogDebug(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack logTrack, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogInformation(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack logTrack, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogWarning(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogError(LogTrack logTrack, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogError(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogFatal(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args) { }

        #endregion

    }
}