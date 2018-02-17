using System;

namespace Cosmos.I18N.Adapters.Xml.Internals {
    internal static class InternalLogger {
        public static void WriteLine(string message, params object[] args) {
            System.Diagnostics.Debug.WriteLine($"{DateTime.UtcNow:O} {message}", args);
        }
    }
}