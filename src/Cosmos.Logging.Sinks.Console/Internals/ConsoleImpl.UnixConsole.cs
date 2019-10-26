using System;
using System.Text;
using Cosmos.Logging.Core;

namespace Cosmos.Logging.Sinks.Console.Internals
{
    /// <summary>
    /// Unix console
    /// </summary>
    public class UnixConsole : IConsole
    {
        /// <summary>
        /// Default background colour
        /// </summary>
        private const string DefaultBackgroundColour = "\x1B[39m\x1B[22m";

        /// <summary>
        /// Default foreground colour
        /// </summary>
        private const string DefaultForegroundColour = "\x1B[49m";

        /// <summary>
        /// Log message holder
        /// </summary>
        private readonly StringBuilder _messageHolder = new StringBuilder();

        public void Write(string message, ConsoleColor? background, ConsoleColor? foreground)
        {
            using (ReleaseBackgroundColour(background))
            {
                using (ReleaseForegroundColour(foreground))
                {
                    _messageHolder.Append(message);
                }
            }
        }

        public void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground)
        {
            Write(message, background, foreground);
            _messageHolder.AppendLine();
        }

        public void Flush()
        {
            System.Console.Write(_messageHolder);
            _messageHolder.Clear();
        }

        private DisposableAction ReleaseBackgroundColour(ConsoleColor? background)
        {
            if (background.HasValue)
                _messageHolder.Append(GetBackgroundColour(background.Value));

            return new DisposableAction(() =>
            {
                if (background.HasValue)
                    _messageHolder.Append(DefaultBackgroundColour);
            });
        }

        private DisposableAction ReleaseForegroundColour(ConsoleColor? foreground)
        {
            if (foreground.HasValue)
                _messageHolder.Append(GetForegroundColour(foreground.Value));

            return new DisposableAction(() =>
            {
                if (foreground.HasValue)
                    _messageHolder.Append(DefaultForegroundColour);
            });
        }

        /// <summary>
        /// Get foreground colour
        /// </summary>
        /// <param name="color">颜色</param>
        private static string GetForegroundColour(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return "\x1B[30m";
                case ConsoleColor.DarkRed:
                    return "\x1B[31m";
                case ConsoleColor.DarkGreen:
                    return "\x1B[32m";
                case ConsoleColor.DarkYellow:
                    return "\x1B[33m";
                case ConsoleColor.DarkBlue:
                    return "\x1B[34m";
                case ConsoleColor.DarkMagenta:
                    return "\x1B[35m";
                case ConsoleColor.DarkCyan:
                    return "\x1B[36m";
                case ConsoleColor.Gray:
                    return "\x1B[37m";
                case ConsoleColor.Red:
                    return "\x1B[1m\x1B[31m";
                case ConsoleColor.Green:
                    return "\x1B[1m\x1B[32m";
                case ConsoleColor.Yellow:
                    return "\x1B[1m\x1B[33m";
                case ConsoleColor.Blue:
                    return "\x1B[1m\x1B[34m";
                case ConsoleColor.Magenta:
                    return "\x1B[1m\x1B[35m";
                case ConsoleColor.Cyan:
                    return "\x1B[1m\x1B[36m";
                case ConsoleColor.White:
                    return "\x1B[1m\x1B[37m";
                default:
                    return DefaultForegroundColour;
            }
        }

        /// <summary>
        /// Get background colour
        /// </summary>
        /// <param name="color">颜色</param>
        private static string GetBackgroundColour(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return "\x1B[40m";
                case ConsoleColor.Red:
                    return "\x1B[41m";
                case ConsoleColor.Green:
                    return "\x1B[42m";
                case ConsoleColor.Yellow:
                    return "\x1B[43m";
                case ConsoleColor.Blue:
                    return "\x1B[44m";
                case ConsoleColor.Magenta:
                    return "\x1B[45m";
                case ConsoleColor.Cyan:
                    return "\x1B[46m";
                case ConsoleColor.White:
                    return "\x1B[47m";
                default:
                    return DefaultBackgroundColour;
            }
        }
    }
}