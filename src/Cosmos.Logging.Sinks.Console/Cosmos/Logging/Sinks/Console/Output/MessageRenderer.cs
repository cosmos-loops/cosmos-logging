using System;
using System.IO;
using System.Text;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Console.Themes;

namespace Cosmos.Logging.Sinks.Console.Output {
    /// <summary>
    /// Message renderer
    /// </summary>
    public class MessageRenderer : BaseOutputRenderer<StringBuilder> {
        /// <inheritdoc />
        public MessageRenderer(StringBuilder body, ConsoleThemeStyle style, TextWriter writer)
            : base(body, style, writer) { }

        /// <inheritdoc />
        public override int Render(LogEvent logEvent) {
            throw new NotImplementedException();
        }
    }
}