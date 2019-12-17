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
        public void LogVerbose(LogEventId eventId, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogDebug(LogEventId eventId, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogInformation(LogEventId eventId, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogWarning(LogEventId eventId, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogError(LogEventId eventId, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogError(LogEventId eventId, Exception exception, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogFatal(LogEventId eventId, string messageTemplate, params object[] args) { }

        /// <inheritdoc />
        public void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, params object[] args) { }

        #endregion

    }
}