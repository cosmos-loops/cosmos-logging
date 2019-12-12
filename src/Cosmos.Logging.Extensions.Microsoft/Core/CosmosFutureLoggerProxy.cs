using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.Extensions.Microsoft.Core {
    public class CosmosFutureLoggerProxy : FutureLoggerBase {
        public CosmosFutureLoggerProxy(
            ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
            : base(logger, memberName, filePath, lineNumber) { }
    }
}