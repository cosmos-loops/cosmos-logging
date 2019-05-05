using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.RunsOn.AspNet {
    public class AspNetFutureLogger : FutureLoggerBase {
        public AspNetFutureLogger(ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
            : base(logger, memberName, filePath, lineNumber) { }
    }
}