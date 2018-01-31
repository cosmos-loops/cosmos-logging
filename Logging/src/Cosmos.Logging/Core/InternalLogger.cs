using System;

namespace Cosmos.Logging.Core {
    public static class InternalLogger {
        public static void WriteLine(string message, params object[] args) {
            System.Diagnostics.Debug.WriteLine($"{DateTime.UtcNow:O} {message}", args);
        }
    }
}