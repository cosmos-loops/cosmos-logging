using System;
using System.Threading;

namespace Cosmos.Logging.Core {
    internal class LoggingScope {
        private static readonly AsyncLocal<LoggingScope> _current = new AsyncLocal<LoggingScope>();

        public static LoggingScope Current {
            get => _current.Value;
            private set => _current.Value = value;
        }

        public static void Push(LoggingScope scope) {
            var temp = Current;
            Current = scope;
            Current.Parent = temp;
        }

        public string Description { get; }

        public string Id { get; }

        public LoggingScope Parent { get; private set; }

        public LoggingScope(string description) {
            Description = description;
            Id = Guid.NewGuid().ToString();
        }

        public void Dispose() {
            Current = Current.Parent;
        }
    }
}