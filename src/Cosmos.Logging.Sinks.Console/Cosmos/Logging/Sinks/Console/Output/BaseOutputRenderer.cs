using System.IO;
using Cosmos.Logging.Events;
using Cosmos.Logging.Sinks.Console.Themes;

namespace Cosmos.Logging.Sinks.Console.Output {
    /// <summary>
    /// Base output renderer
    /// </summary>
    /// <typeparam name="TBody"></typeparam>
    public abstract class BaseOutputRenderer<TBody> {
        /// <summary>
        /// Create a new instance of <see cref="BaseOutputRenderer{TBody}"/>
        /// </summary>
        /// <param name="body"></param>
        /// <param name="style"></param>
        /// <param name="writer"></param>
        protected BaseOutputRenderer(TBody body, ConsoleThemeStyle style, TextWriter writer) {
            Body = body;
            Style = style;
            Writer = writer;
        }

        /// <summary>
        /// Gets body
        /// </summary>
        protected TBody Body { get; }

        /// <summary>
        /// Gets style
        /// </summary>
        public ConsoleThemeStyle Style { get; }

        /// <summary>
        /// Gets writer
        /// </summary>
        protected TextWriter Writer { get; }

        /// <summary>
        /// Render, and return the length of result
        /// </summary>
        /// <returns></returns>
        public abstract int Render(LogEvent logEvent);
    }
}