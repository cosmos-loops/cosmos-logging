using System;
using System.Collections.Generic;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {
    /// <summary>
    /// Interface for logging options
    /// </summary>
    public interface ILoggingOptions {

        #region Append log minimum level

        /// <summary>
        /// Use minimum level for type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="level"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        LoggingOptions UseMinimumLevelForType<T>(LogEventLevel level);

        /// <summary>
        /// Use minimum level for type <paramref name="type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        LoggingOptions UseMinimumLevelForType(Type type, LogEventLevel level);

        /// <summary>
        /// Use minimum level for category name <typeparamref name="T"/>.
        /// </summary>
        /// <param name="level"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        LoggingOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level);

        /// <summary>
        /// Use minimum level for category name <paramref name="type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        LoggingOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level);

        /// <summary>
        /// Use minimum level for category name <paramref name="categoryName"/>.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        LoggingOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level);

        /// <summary>
        /// Use minimum level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        LoggingOptions UseMinimumLevel(LogEventLevel? level);

        #endregion

        #region Append log level alias

        /// <summary>
        /// Use alias for given log event level.
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        LoggingOptions UseAlias(string alias, LogEventLevel level);

        #endregion

        #region Append output

        /// <summary>
        /// Enable display caller info
        /// </summary>
        /// <param name="displayingCallerInfoEnabled"></param>
        /// <returns></returns>
        LoggingOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled);

        /// <summary>
        /// Enable display event-id
        /// </summary>
        /// <param name="displayingEventIdInfoEnabled"></param>
        /// <returns></returns>
        LoggingOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled);

        /// <summary>
        /// Enable display new-line at the end of message (EOM)
        /// </summary>
        /// <param name="displayingNewLineEomEnabled"></param>
        /// <returns></returns>
        LoggingOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled);

        #endregion

        #region Append scan renderers

        /// <summary>
        /// Automatic scan renderers
        /// </summary>
        /// <returns></returns>
        LoggingOptions AutomaticScanRenderers();

        /// <summary>
        /// Manually renderer configure
        /// </summary>
        /// <param name="preferencesRendererTypes"></param>
        /// <returns></returns>
        LoggingOptions ManuallyRendererConfigure(params Type[] preferencesRendererTypes);

        #endregion

        /// <summary>
        /// Gets or sets all sinks
        /// </summary>
        Dictionary<string, ILoggingSinkOptions> Sinks { get; set; }
    }
}