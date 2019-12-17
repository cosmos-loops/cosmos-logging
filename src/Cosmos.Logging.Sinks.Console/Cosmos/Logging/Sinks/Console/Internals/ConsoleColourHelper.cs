using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Sinks.Console.Internals {
    internal static class ConsoleColourHelper {
        public static (ConsoleColor background, ConsoleColor foreground) GetColour(LogEventLevel level) {
            switch (level) {
                case LogEventLevel.Fatal:
                    return (ConsoleColor.Magenta, ConsoleColor.Black);
                case LogEventLevel.Error:
                    return (ConsoleColor.Red, ConsoleColor.Black);
                case LogEventLevel.Warning:
                    return (ConsoleColor.Yellow, ConsoleColor.Black);
                case LogEventLevel.Information:
                    return (ConsoleColor.White, ConsoleColor.Black);
                case LogEventLevel.Debug:
                    return (ConsoleColor.Gray, ConsoleColor.Black);
                case LogEventLevel.Verbose:
                    return (ConsoleColor.Gray, ConsoleColor.Black);
                default:
                    return (ConsoleColor.White, ConsoleColor.Black);
            }
        }
    }
}