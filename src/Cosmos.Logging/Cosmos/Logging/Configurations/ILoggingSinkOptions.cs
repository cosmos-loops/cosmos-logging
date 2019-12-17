using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Configurations {

    /// <summary>
    /// Interface for logging sink options
    /// </summary>
    public interface ILoggingSinkOptions {
        /// <summary>
        /// Key
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Get rendering options
        /// </summary>
        /// <returns></returns>
        RenderingConfiguration GetRenderingOptions();
    }

    /// <summary>
    /// Interface for logging sink options
    /// </summary>
    /// <typeparam name="TOptions"></typeparam>
    public interface ILoggingSinkOptions<out TOptions> where TOptions : class, ILoggingSinkOptions, new() {

        #region Append log minimum level

        /// <summary>
        /// Use minimum level for type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="level"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        TOptions UseMinimumLevelForType<T>(LogEventLevel level);

        /// <summary>
        /// Use minimum level for type <paramref name="type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        TOptions UseMinimumLevelForType(Type type, LogEventLevel level);

        /// <summary>
        /// Use minimum level for category name <typeparamref name="T"/>.
        /// </summary>
        /// <param name="level"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        TOptions UseMinimumLevelForCategoryName<T>(LogEventLevel level);

        /// <summary>
        /// Use minimum level for category name <paramref name="type"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        TOptions UseMinimumLevelForCategoryName(Type type, LogEventLevel level);

        /// <summary>
        /// Use minimum level for category name <paramref name="categoryName"/>.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        TOptions UseMinimumLevelForCategoryName(string categoryName, LogEventLevel level);

        /// <summary>
        /// Use minimum level
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        TOptions UseMinimumLevel(LogEventLevel? level);

        #endregion

        #region Append log level alias

        /// <summary>
        /// Use alias for the given log event level
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        TOptions UseAlias(string alias, LogEventLevel level);

        #endregion

        #region Append output

        /// <summary>
        /// Enable display caller info
        /// </summary>
        /// <param name="displayingCallerInfoEnabled"></param>
        /// <returns></returns>
        TOptions EnableDisplayCallerInfo(bool? displayingCallerInfoEnabled);

        /// <summary>
        /// Enable display event-id
        /// </summary>
        /// <param name="displayingEventIdInfoEnabled"></param>
        /// <returns></returns>
        TOptions EnableDisplayEventIdInfo(bool? displayingEventIdInfoEnabled);

        /// <summary>
        /// Enable display new-line at the end of message (EOM).
        /// </summary>
        /// <param name="displayingNewLineEomEnabled"></param>
        /// <returns></returns>
        TOptions EnableDisplayNewLineEom(bool? displayingNewLineEomEnabled);

        #endregion

    }
}