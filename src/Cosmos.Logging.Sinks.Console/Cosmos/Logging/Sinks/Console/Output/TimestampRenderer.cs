using System;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Console.Themes;

namespace Cosmos.Logging.Sinks.Console.Output {
    /// <summary>
    /// Timestamp renderer
    /// </summary>
    public class TimestampRenderer : BaseOutputRenderer<DateTimeOffset> {
        /// <inheritdoc />
        public TimestampRenderer(DateTimeOffset body, ConsoleThemeStyle style, TextWriter writer)
            : base(body, style, writer) { }

        /// <inheritdoc />
        public override int Render(LogEvent logEvent) {
            throw new NotImplementedException();
        }
    }
}