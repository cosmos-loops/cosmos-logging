using System;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Console.Themes;

namespace Cosmos.Logging.Sinks.Console.Output
{
    public class ExceptionRenderer<TException> : BaseOutputRenderer<TException> where TException : Exception
    {
        public ExceptionRenderer(TException body, ConsoleThemeStyle style, TextWriter writer)
            : base(body, style, writer) { }

        public override int Render(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}