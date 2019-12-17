using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.RunsOn.NancyFX {
    /// <summary>
    /// NancyFX future logger
    /// </summary>
    public sealed class NancyFutureLogger : FutureLoggerBase {
        /// <inheritdoc />
        [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
        public NancyFutureLogger(ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
            : base(logger, memberName, filePath, lineNumber) { }
    }
}