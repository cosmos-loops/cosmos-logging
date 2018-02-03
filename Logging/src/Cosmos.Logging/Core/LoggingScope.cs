using System;
#if NET451
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting;

#else
using System.Threading;
// ReSharper disable InconsistentNaming

#endif

namespace Cosmos.Logging.Core {
    public class LoggingScope {
#if NET451
        private const string DataKey = "__CosmosLoops.LoggingScope_Current__";
#else
        private static readonly AsyncLocal<LoggingScope> _current = new AsyncLocal<LoggingScope>();
#endif
        private readonly object _state;
        private readonly string _description;
        private readonly string _id;
        private readonly int _deep;

        public LoggingScope(string description, object state) : this(description, state, 0) { }

        private LoggingScope(string description, object state, int deep) {
            _description = description;
            _state = state;
            _id = Guid.NewGuid().ToString();
            _deep = deep;
            TranceId = Id;
        }

#if NET451
        public static LoggingScope Current {
            get => (CallContext.LogicalGetData(DataKey) as ObjectHandle)?.Unwrap() as LoggingScope;
            private set => CallContext.LogicalSetData(DataKey, new ObjectHandle(value));
        }
#else
        public static LoggingScope Current {
            get => _current.Value;
            private set => _current.Value = value;
        }
#endif

        public static IDisposable Push(string description, object state) {
            var temp = Current;

            if (temp == null) {
                Current = new LoggingScope(description, state);
            } else {
                Current = new LoggingScope(description, state, temp._deep + 1) {
                    Parent = temp,
                    TranceId = temp.TranceId
                };
            }

            return new DisposableScope();
        }

        public string Description => _description;

        public string Id => _id;

        public int Deep => _deep;

        public string TranceId { get; private set; }

        public LoggingScope Parent { get; private set; }

        public override string ToString() => _state?.ToString() ?? string.Empty;

        private class DisposableScope : IDisposable {
            public void Dispose() {
                Current = Current.Parent;
            }
        }
    }
}