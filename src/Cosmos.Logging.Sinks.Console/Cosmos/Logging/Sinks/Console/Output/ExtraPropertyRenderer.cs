using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Console.Themes;

namespace Cosmos.Logging.Sinks.Console.Output {
    /// <summary>
    /// Extra property renderer
    /// </summary>
    public class ExtraPropertyRenderer : BaseOutputRenderer<Dictionary<string, string>> {
        /// <inheritdoc />
        public ExtraPropertyRenderer(Dictionary<string, string> body, ConsoleThemeStyle style, TextWriter writer)
            : base(body, style, writer) { }

        /// <inheritdoc />
        public override int Render(LogEvent logEvent) {
            throw new NotImplementedException();
        }
    }
}