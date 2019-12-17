using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging {
    /// <summary>
    /// Interface for Futureable logger
    /// </summary>
    /// <typeparam name="TFutureLogger"></typeparam>
    public interface IFutureableLogger<out TFutureLogger> where TFutureLogger : class, IFutureLogger {
        /// <summary>
        /// To future logger
        /// </summary>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        TFutureLogger ToFuture([CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0);
    }
}