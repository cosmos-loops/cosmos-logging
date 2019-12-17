using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.RunsOn.AspNetCore {
    /// <summary>
    /// ASP.NET Core Future Logger
    /// </summary>
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public sealed class AspNetCoreFutureLogger : FutureLoggerBase {
        /// <inheritdoc />
        public AspNetCoreFutureLogger(ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
            : base(logger, memberName, filePath, lineNumber) { }
    }
}