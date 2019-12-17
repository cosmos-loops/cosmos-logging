using System;

namespace Cosmos.Logging.Sinks.Console.Internals {
    internal class MessageWrapper {
        public MessageWrapper(string renderedMessage, ConsoleColor? background, ConsoleColor? foreground) {
            BackgroundColour = background;
            ForegroundColour = foreground;
            RenderedMessage = renderedMessage;
        }

        /// <summary>
        /// Background colour
        /// </summary>
        public ConsoleColor? BackgroundColour { get; set; }

        /// <summary>
        /// Foreground colour
        /// </summary>
        public ConsoleColor? ForegroundColour { get; set; }

        /// <summary>
        /// Rendered message
        /// </summary>
        public string RenderedMessage { get; set; }
    }
}