using System;
using System.Collections.Generic;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Console.Themes;

namespace Cosmos.Logging.Sinks.Console.Output
{
    public class ExtraPropertyRenderer : BaseOutputRenderer<Dictionary<string, string>>
    {
        public ExtraPropertyRenderer(Dictionary<string, string> body, ConsoleThemeStyle style, TextWriter writer)
            : base(body, style, writer) { }

        public override int Render(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}