using Cosmos.Logging.Events;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.Extensions.MicrosoftSupported {
    /// <summary>
    /// LogEventId convert
    /// </summary>
    public static class LogEventIdConvert {
        /// <summary>
        /// Convert Microsoft Event Id to Cosmos Logging Event Id
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public static LogEventId ToEventId(this EventId eventId) => LogEventIdFactory.Create(eventId.Id, eventId.Name);
        
        /// <summary>
        /// Convert Microsoft Event Id to Cosmos Logging Business Track Info
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public static LogTrack ToTrackInfo(this EventId eventId) => LogTrack.Create(eventId.Id, eventId.Name);
    }
}