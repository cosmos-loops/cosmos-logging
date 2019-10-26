using System;

namespace Cosmos.Logging.Sinks.Console
{
    /// <summary>
    /// Interface of console
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Write
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="background">Background colour</param>
        /// <param name="foreground">Foreground colour</param>
        void Write(string message, ConsoleColor? background, ConsoleColor? foreground);

        /// <summary>
        /// Write with new line
        /// </summary>
        /// <param name="message">Log message</param>
        /// <param name="background">Background colour</param>
        /// <param name="foreground">Foreground colour</param>
        void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground);

        /// <summary>
        /// Flush
        /// </summary>
        void Flush();
    }
}