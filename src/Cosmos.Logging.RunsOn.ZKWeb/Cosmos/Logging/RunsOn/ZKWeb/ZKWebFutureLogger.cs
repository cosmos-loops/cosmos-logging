using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.RunsOn.ZKWeb {
    /// <summary>
    /// ZKWeb future logger
    /// </summary>
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public sealed class ZKWebFutureLogger : FutureLoggerBase {

        /// <inheritdoc />
        public ZKWebFutureLogger(ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
            : base(logger, memberName, filePath, lineNumber) { }
    }
}