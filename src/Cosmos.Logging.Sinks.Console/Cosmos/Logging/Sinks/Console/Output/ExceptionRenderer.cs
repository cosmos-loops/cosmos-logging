using System;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Console.Themes;

namespace Cosmos.Logging.Sinks.Console.Output {
    /// <summary>
    /// Exception renderer
    /// </summary>
    /// <typeparam name="TException"></typeparam>
    public class ExceptionRenderer<TException> : BaseOutputRenderer<TException> where TException : Exception {
        /// <inheritdoc />
        public ExceptionRenderer(TException body, ConsoleThemeStyle style, TextWriter writer)
            : base(body, style, writer) { }

        /// <inheritdoc />
        public override int Render(LogEvent logEvent) {
            throw new NotImplementedException();
        }
    }
}