using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.Extensions.MicrosoftSupported.Core {
    /// <summary>
    /// Proxy for Cosmos future logger
    /// </summary>
    public sealed class FutureLoggerProxy : FutureLoggerBase {
        /// <inheritdoc />
        public FutureLoggerProxy(
            ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
            : base(logger, memberName, filePath, lineNumber) { }
    }
}