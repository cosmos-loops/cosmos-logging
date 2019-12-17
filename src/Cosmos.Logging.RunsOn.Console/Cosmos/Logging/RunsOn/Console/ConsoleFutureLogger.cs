using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.RunsOn.Console {
    /// <summary>
    /// Console future logger
    /// </summary>
    public sealed class ConsoleFutureLogger : FutureLoggerBase {

        /// <inheritdoc />
        [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
        internal ConsoleFutureLogger(
            ILogger logger,
            [CallerMemberName] string memberName = null,
            [CallerFilePath] string filePath = null,
            [CallerLineNumber] int lineNumber = 0)
            : base(logger, memberName, filePath, lineNumber) { }
    }
}