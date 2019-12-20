using System;
using Cosmos.Logging.Events;
#if NET451
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting;

#else
using System.Threading;
// ReSharper disable InconsistentNaming

#endif

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Logging scope manager
    /// </summary>
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

        /// <summary>
        /// Create a new instance of <see cref="LoggingScope"/>.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="state"></param>
        public LoggingScope(string description, object state) : this(description, state, 0) { }

        private LoggingScope(string description, object state, int deep) {
            _description = description;
            _state = state;
            _id = Guid.NewGuid().ToString();
            _deep = deep;
            TranceId = Id;
        }

#if NET451
        /// <summary>
        /// Gets current <see cref="LoggingScope"/>
        /// </summary>
        public static LoggingScope Current {
            get => (CallContext.LogicalGetData(DataKey) as ObjectHandle)?.Unwrap() as LoggingScope;
            private set => CallContext.LogicalSetData(DataKey, new ObjectHandle(value));
        }
#else
        /// <summary>
        /// Gets current <see cref="LoggingScope"/>
        /// </summary>
        public static LoggingScope Current {
            get => _current.Value;
            private set => _current.Value = value;
        }
#endif

        /// <summary>
        /// Push
        /// </summary>
        /// <param name="description"></param>
        /// <param name="state"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets Description
        /// </summary>
        public string Description => _description;

        /// <summary>
        /// Gets id
        /// </summary>
        public string Id => _id;

        /// <summary>
        /// Gets deep
        /// </summary>
        public int Deep => _deep;

        /// <summary>
        /// Gets trace id
        /// </summary>
        public string TranceId { get; private set; }

        /// <summary>
        /// Gets parent
        /// </summary>
        public LoggingScope Parent { get; private set; }

        /// <inheritdoc />
        public override string ToString() => _state?.ToString() ?? string.Empty;

        private class DisposableScope : IDisposable {
            public DisposableScope() {
                LogEventId.GoIntoScope(Current);
            }

            public void Dispose() {
                Current = Current.Parent;
                LogEventId.GoOutScope();
            }
        }
    }
}