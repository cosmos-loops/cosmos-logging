using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Configurations;
using Cosmos.Logging.Events;
using Cosmos.Logging.Future;

namespace Cosmos.Logging {
    /// <summary>
    /// Interface for logging service provider
    /// </summary>
    public partial interface ILoggingServiceProvider {
        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        IFutureLogger GetFutureLogger(string categoryName,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        IFutureLogger GetFutureLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        IFutureLogger GetFutureLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        IFutureLogger GetFutureLogger(Type type,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        IFutureLogger GetFutureLogger(Type type, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="type"></param>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        IFutureLogger GetFutureLogger(Type type, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IFutureLogger GetFutureLogger<T>(
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IFutureLogger GetFutureLogger<T>(Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Get future logger
        /// </summary>
        /// <param name="minLevel"></param>
        /// <param name="filter"></param>
        /// <param name="renderingOptions"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IFutureLogger GetFutureLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            RenderingConfiguration renderingOptions = null,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0);
    }
}