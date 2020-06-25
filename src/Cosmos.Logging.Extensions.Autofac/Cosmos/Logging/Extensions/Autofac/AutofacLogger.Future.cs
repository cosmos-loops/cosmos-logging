using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Future;

namespace Cosmos.Logging.Extensions.Autofac {
    /// <summary>
    /// Autofac Future Logger
    /// </summary>
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public sealed class AutofacFutureLogger : FutureLoggerBase {
        /// <inheritdoc />
        public AutofacFutureLogger(ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0)
            : base(logger, memberName, filePath, lineNumber) { }
    }
}