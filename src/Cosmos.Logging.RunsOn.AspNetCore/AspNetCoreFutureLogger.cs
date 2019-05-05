using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public class AspNetCoreFutureLogger : FutureLoggerBase {
        public AspNetCoreFutureLogger(ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
            : base(logger, memberName, filePath, lineNumber) { }
    }
}