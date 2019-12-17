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
            var finalMessage = $"{DateTime.UtcNow:O} {message}";
            
            try {
                System.Diagnostics.Debug.WriteLine(finalMessage, args);
            }
            catch {
                WriteLineSafety(finalMessage);
            }
        }

        private static void WriteLineSafety(string finalMessage) {
            System.Diagnostics.Debug.WriteLine(finalMessage);
        }
    }
}