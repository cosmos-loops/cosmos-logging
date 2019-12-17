using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Simple {
    /// <summary>
    /// Interface for Simple logger
    /// </summary>
    public interface ISimpleLogger {
        /// <summary>
        /// Minimum level
        /// </summary>
        LogEventLevel MinimumLevel { get; }

        /// <summary>
        /// Is enable
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabled(LogEventLevel level);

        #region Write

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogVerbose(string messageTemplate, params object[] args);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogVerbose(Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogDebug(string messageTemplate, params object[] args);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogDebug(Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogInformation(string messageTemplate, params object[] args);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogInformation(Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogWarning(string messageTemplate, params object[] args);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogWarning(Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogError(string messageTemplate, params object[] args);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogError(Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogFatal(string messageTemplate, params object[] args);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogFatal(Exception exception, string messageTemplate, params object[] args);

        #endregion

        #region Write with EventId

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogVerbose(LogEventId eventId, string messageTemplate, params object[] args);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogVerbose(LogEventId eventId, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogDebug(LogEventId eventId, string messageTemplate, params object[] args);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogDebug(LogEventId eventId, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogInformation(LogEventId eventId, string messageTemplate, params object[] args);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogInformation(LogEventId eventId, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogWarning(LogEventId eventId, string messageTemplate, params object[] args);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogWarning(LogEventId eventId, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogError(LogEventId eventId, string messageTemplate, params object[] args);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogError(LogEventId eventId, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogFatal(LogEventId eventId, string messageTemplate, params object[] args);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogFatal(LogEventId eventId, Exception exception, string messageTemplate, params object[] args);

        #endregion

    }
}