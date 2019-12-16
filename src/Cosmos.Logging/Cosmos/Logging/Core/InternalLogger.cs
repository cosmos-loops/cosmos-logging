using System;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Internal logger for Cosmos.Logging
    /// </summary>
    public static class InternalLogger {
        /// <summary>
        /// Write line
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void WriteLine(string message, params object[] args) {
            System.Diagnostics.Debug.WriteLine($"{DateTime.UtcNow:O} {message}", args);
        }
    }
}