using System;
using System.Threading;

namespace Cosmos.Logging.Core {
    public class LoggingScope : IDisposable {
        private static readonly AsyncLocal<LoggingScope> _current = new AsyncLocal<LoggingScope>();

        public static LoggingScope Current {
            get => _current.Value;
            private set => _current.Value = value;
        }

        public static void Push(LoggingScope scope) {
            var temp = Current;
            Current = scope;
            Current.Parent = temp;
            Current.Deep = temp.Deep + 1;
            Current.TranceId = temp.TranceId;
        }

        public static void Push(string description) {
            Push(new LoggingScope(description));
        }

        public string Description { get; }

        public string Id { get; }

        public int Deep { get; private set; }

        public string TranceId { get; private set; }

        public LoggingScope Parent { get; private set; }

        public LoggingScope(string description) {
            Description = description;
            Id = Guid.NewGuid().ToString();
            Deep = 0;
            TranceId = Id;
        }

        public void Dispose() {
            Current = Current.Parent;
        }
    }
}