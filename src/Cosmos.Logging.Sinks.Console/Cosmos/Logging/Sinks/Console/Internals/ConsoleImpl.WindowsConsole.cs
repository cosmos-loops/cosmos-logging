using System;
using Cosmos.Disposables;

namespace Cosmos.Logging.Sinks.Console.Internals {
    /// <summary>
    /// Windows console
    /// </summary>
    public class WindowsConsole : IConsole {
        private readonly DisposableAction _disposableAct;

        /// <summary>
        /// Create a new instance of <see cref="WindowsConsole"/>.
        /// </summary>
        public WindowsConsole() {
            _disposableAct = new DisposableAction(ResetColour);
        }

        /// <inheritdoc />
        public void Write(string message, ConsoleColor? background, ConsoleColor? foreground) {
            using (ReleaseColour(background, foreground)) {
                System.Console.Out.Write(message);
            }
        }

        /// <inheritdoc />
        public void WriteLine(string message, ConsoleColor? background, ConsoleColor? foreground) {
            using (ReleaseColour(background, foreground)) {
                System.Console.Out.WriteLine(message);
            }
        }

        /// <inheritdoc />
        public void Flush() { }

        private DisposableAction ReleaseColour(ConsoleColor? background, ConsoleColor? foreground) {
            SetColour(background, foreground);
            return _disposableAct;
        }

        /// <summary>
        /// Set colour
        /// </summary>
        /// <param name="background"></param>
        /// <param name="foreground"></param>
        private void SetColour(ConsoleColor? background, ConsoleColor? foreground) {
            if (background.HasValue)
                System.Console.BackgroundColor = background.Value;
            if (foreground.HasValue)
                System.Console.ForegroundColor = foreground.Value;
        }

        /// <summary>
        /// Reset colour
        /// </summary>
        private void ResetColour() => System.Console.ResetColor();
    }
}