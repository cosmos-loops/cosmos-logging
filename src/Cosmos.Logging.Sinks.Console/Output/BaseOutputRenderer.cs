using System;
using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Console.Themes;

namespace Cosmos.Logging.Sinks.Console.Output
{
    public abstract class BaseOutputRenderer<TBody>
    {
        protected BaseOutputRenderer(TBody body, ConsoleThemeStyle style, TextWriter writer)
        {
            Body = body;
            Style = style;
            Writer = writer;
        }

        protected TBody Body { get; }

        public ConsoleThemeStyle Style { get; }

        protected TextWriter Writer { get; }

        /// <summary>
        /// Render, and return the length of result
        /// </summary>
        /// <returns></returns>
        public abstract int Render(LogEvent logEvent);
    }
}