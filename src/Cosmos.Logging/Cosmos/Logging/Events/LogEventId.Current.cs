using System;
using System.Threading;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Log event id
    /// </summary>
    public partial class LogEventId {
        // ReSharper disable once InconsistentNaming
        private static readonly AsyncLocal<LogEventId> _currentLogEventId = new AsyncLocal<LogEventId>();
        private static readonly AsyncLocal<NeedUpdateCurrentEventId> _bool = new AsyncLocal<NeedUpdateCurrentEventId>();

        static LogEventId() {
            _bool.Value = true;
        }

        /// <summary>
        /// Gets or sets current event id
        /// </summary>
        public static LogEventId Current {
            get => _currentLogEventId.Value;
            internal set => _currentLogEventId.Value = value;
        }

        internal static bool NeedUpdateCurrentValue {
            get => _bool.Value.Value;
            set => _bool.Value = value;
        }

        /// <summary>
        /// Update root event id.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="strategy"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void UpdateRootEventId(LogEventId root, UpdateStrategy strategy = UpdateStrategy.ThrowIfError) {
            var current = Current;
            switch (strategy) {
                case UpdateStrategy.Force: {
                    Current = root ?? throw new ArgumentNullException(nameof(root), "Root log event id cannot be null.");
                    NeedUpdateCurrentValue = false;
                    break;
                }

                case UpdateStrategy.Safety: {
                    if (root != null) {
                        Current = root;
                        NeedUpdateCurrentValue = false;
                    }

                    break;
                }

                case UpdateStrategy.ThrowIfError: {
                    if (root is null)
                        throw new ArgumentNullException(nameof(root), "Root log event id cannot be null.");
                    if (current != null)
                        throw new InvalidOperationException("Current event id has been set, you cannot set another EventId right now");
                    Current = root;
                    NeedUpdateCurrentValue = false;
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(strategy), strategy, null);
            }
        }

        /// <summary>
        /// Strategy to update root event id
        /// </summary>
        public enum UpdateStrategy {
            /// <summary>
            /// Throw exception if root current log event id has been set.
            /// </summary>
            ThrowIfError,

            /// <summary>
            /// Force update
            /// </summary>
            Force,

            /// <summary>
            /// Safety update
            /// </summary>
            Safety,
        }

        private struct NeedUpdateCurrentEventId {
            public bool Value { get; }

            public NeedUpdateCurrentEventId(bool value) {
                Value = value;
            }

            public static implicit operator bool(NeedUpdateCurrentEventId value) {
                return value.Value;
            }

            public static implicit operator NeedUpdateCurrentEventId(bool value) {
                return new NeedUpdateCurrentEventId(value);
            }
        }
    }
}