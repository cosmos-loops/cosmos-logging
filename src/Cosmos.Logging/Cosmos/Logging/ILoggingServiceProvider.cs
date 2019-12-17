using System;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    /// <summary>
    /// Interface for logging service provider
    /// </summary>
    public partial interface ILoggingServiceProvider {
        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        ILogger GetLogger(string categoryName,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        ILogger GetLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        ILogger GetLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        ILogger GetLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <returns></returns>
        ILogger GetLogger(Type type, LogEventLevel minLevel,Func<string, LogEventLevel, bool> filter, 
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ILogger GetLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);

        /// <summary>
        /// Get logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="mode"></param>
        /// <param name="renderingOptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            RenderingConfiguration renderingOptions = null);
    }
}