using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging {
    public interface IFutureableLogger<out TFutureLogger> where TFutureLogger : class, IFutureLogger {
        TFutureLogger ToFuture([CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0);
    }
}