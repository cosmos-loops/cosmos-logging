using System;

namespace Cosmos.Logging.Core {
    public static class InternalLogger {
        public static void WriteLine(string message, params object[] args) {
            Console.WriteLine($"{DateTime.UtcNow:O} {message}", args);
        }
    }
}