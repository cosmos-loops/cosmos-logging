using System;
using Cosmos.Logging.Trace;
using Cosmos.Optionals;

namespace Cosmos.Logging.Events {
    /// <summary>
    /// Log event id factory
    /// </summary>
    public static class LogEventIdFactory {

        /// <summary>
        /// Create current event id with the given trace id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="traceId"></param>
        /// <returns></returns>
        public static LogEventId Create(string id = null, string name = null, string traceId = null) {
            return CreateOrUpdateCurrentEventId(id, name, traceId);
        }

        /// <summary>
        /// Create current event id with the given trace id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="traceId"></param>
        /// <returns></returns>
        public static LogEventId Create(int id, string name, string traceId = null) {
            return CreateOrUpdateCurrentEventId(id, name, traceId);
        }

        /// <summary>
        /// Create current event id with the given trace id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="traceId"></param>
        /// <returns></returns>
        public static LogEventId Create(long id, string name, string traceId = null) {
            return CreateOrUpdateCurrentEventId(id, name, traceId);
        }

        /// <summary>
        /// Create current event id with the given trace id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="traceId"></param>
        /// <returns></returns>
        public static LogEventId Create(Guid id, string name, string traceId = null) {
            return CreateOrUpdateCurrentEventId(id, name, traceId);
        }

        /// <summary>
        /// Create current event id with the given trace id.
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        public static LogEventId Create(LogTrack track) {
            return CreateOrUpdateCurrentEventId(track);
        }

        private static LogEventId CreateOrUpdateCurrentEventId<T>(T id, string name, string traceId) {
            return CreateOrUpdateCurrentEventId(id.ToString(), name, traceId);
        }

        private static LogEventId CreateOrUpdateCurrentEventId(LogTrack track) {
            return CreateOrUpdateCurrentEventId(track.Id, track.Name, track.BusinessTraceId);
        }

        private static LogEventId CreateOrUpdateCurrentEventId(string id, string name, string traceId) {
            /*
             * 1、 当 LogEventId.Current 为空的时候（此时 NeedUpdateCurrentValue 为 true），将压入一个新的 LogEventId 实例作为 root，NeedUpdateCurrentValue 标记为 false，并返回
             * 2、 当 LogEventId.Current 不为空，则取出 Current，并以之作为 Parent，生成一个新的 LogEventId 实例，不压如入 Current，返回
             * 3、 当 BeginScope，则将 NeedUpdateCurrentValue 标记为 true;
             *         在下一次 TouchCurrentEventId 时将第一个 eventId 压入，将原 current 作为 Parent
             */

            name ??= string.Empty;
            if (string.IsNullOrWhiteSpace(id)) id = Guid.NewGuid().ToString();

            var eventIdMaybe = Optional.From(LogEventId.Current);
            var realTraceId = MakeRealTraceId(Optional.From(eventIdMaybe.Value?.TraceId), traceId);
            var businessTraceId = MakeBusinessTraceId(Optional.From(eventIdMaybe.Value?.BusinessTraceId), traceId, realTraceId);

            LogEventId instance;
            if (eventIdMaybe.HasValue) {
                instance = new LogEventId(eventIdMaybe.Value, id, name) {BusinessTraceId = businessTraceId};
            } else {
                instance = new LogEventId(id, name, realTraceId) {BusinessTraceId = businessTraceId};
            }

            if (LogEventId.NeedUpdateCurrentValue) {
                LogEventId.Current = instance;
                LogEventId.NeedUpdateCurrentValue = false;
            }

            return instance;
        }

        private static string MakeRealTraceId(Maybe<string> traceIdFromCurrentEventId, string traceId) {
            return @return(traceIdFromCurrentEventId.ValueOr(traceId));

            string @return(string value) {
                return string.IsNullOrWhiteSpace(value) ? LogTraceId.Get() : value;
            }
        }

        private static string MakeBusinessTraceId(Maybe<string> businessTraceIdFromCurrentEventId, string traceId, string realTraceId) {
            var biz = string.IsNullOrWhiteSpace(traceId) ? businessTraceIdFromCurrentEventId.Value : traceId;
            return string.IsNullOrWhiteSpace(biz) ? realTraceId : biz;
        }
    }
}