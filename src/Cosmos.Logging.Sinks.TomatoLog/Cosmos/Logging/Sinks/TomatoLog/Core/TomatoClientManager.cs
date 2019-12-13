using System;
using TomatoLog.Common.Interface;

namespace Cosmos.Logging.Sinks.TomatoLog.Core {
    internal static class TomatoClientManager {
        private static ITomatoLogClient CachedClient { get; set; }
        private static LogFlowTypes? FlowType { get; set; }

        public static ITomatoLogClient Get()
            => CachedClient;

        public static LogFlowTypes? GetCurrentFlowType => FlowType;

        public static void Set(ITomatoLogClient client, LogFlowTypes flowType) {
            CachedClient = client ?? throw new ArgumentNullException(nameof(client));
            FlowType = flowType;
        }

        public static bool HasClient() => CachedClient != null;
    }
}