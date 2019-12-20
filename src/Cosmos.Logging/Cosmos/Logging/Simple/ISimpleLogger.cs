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
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogVerbose(LogTrack logTrack, string messageTemplate, params object[] args);

        /// <summary>
        /// Log verbose
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogVerbose(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogDebug(LogTrack logTrack, string messageTemplate, params object[] args);

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogDebug(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogInformation(LogTrack logTrack, string messageTemplate, params object[] args);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogInformation(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogWarning(LogTrack logTrack, string messageTemplate, params object[] args);

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogWarning(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogError(LogTrack logTrack, string messageTemplate, params object[] args);

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogError(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogFatal(LogTrack logTrack, string messageTemplate, params object[] args);

        /// <summary>
        /// Log fatal
        /// </summary>
        /// <param name="logTrack"></param>
        /// <param name="exception"></param>
        /// <param name="messageTemplate"></param>
        /// <param name="args"></param>
        void LogFatal(LogTrack logTrack, Exception exception, string messageTemplate, params object[] args);

        #endregion

    }
}