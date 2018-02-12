using System;
using System.Collections.Concurrent;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
#if NET451
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
#else
using System.Threading;

#endif

namespace Cosmos.Logging.Extensions.EntityFramework.Core {
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    internal class InternalLoggingSharedContext {
#if NET451
        private const string DataKey = "__CosmosLoops.EfExtraScope_Current__";
#else
        // ReSharper disable once InconsistentNaming
        private static readonly AsyncLocal<InternalLoggingSharedContext> _current = new AsyncLocal<InternalLoggingSharedContext>();
#endif

        private readonly ConcurrentDictionary<DbCommand, DateTime> _efLoggerStartTimeDict = new ConcurrentDictionary<DbCommand, DateTime>();

#if NET451
        public static InternalLoggingSharedContext Current {
            get => (CallContext.LogicalGetData(DataKey) as ObjectHandle)?.Unwrap() as InternalLoggingSharedContext;
            private set => CallContext.LogicalSetData(DataKey, new ObjectHandle(value));
        }
#else
        public static InternalLoggingSharedContext Current {
            get => _current.Value;
            private set => _current.Value = value;
        }
#endif

        public static void AddStartTime(DbCommand command, out DateTime now) {
            now = DateTime.Now;
            Current._efLoggerStartTimeDict.TryAdd(command, now);
        }

        public static DateTime? GetStartTime(DbCommand command) {
            if (Current._efLoggerStartTimeDict.TryGetValue(command, out var ret)) {
                return ret;
            }

            return null;
        }

        public static void RemoveStartTime(DbCommand command, out DateTime time) {
            Current._efLoggerStartTimeDict.TryRemove(command, out time);
        }
    }
}