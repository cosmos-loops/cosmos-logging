using Cosmos.Logging.Core;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Log event id
    /// </summary>
    public partial class LogEventId {
        internal static void GoIntoScope(LoggingScope loggingScope) {
            NeedUpdateCurrentValue = true;
            var scopedRootEventId = LogEventIdFactory.Create(name: loggingScope.ToString());
            scopedRootEventId.LoggingScopeTraceId = loggingScope.TranceId;
        }

        internal static void GoOutScope() {
            var current = Current;

            if (current?.Parent is null)
                return;

            UpdateRootEventId(current.Parent, UpdateStrategy.Force);
        }
    }
}