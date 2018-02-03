using Cosmos.Logging.Events;
using Microsoft.Extensions.Logging;

namespace Cosmos.Logging.RunsOn.AspNetCore.Core {
    internal static class LogEventIdConvert {
        public static LogEventId ToEventId(this EventId eventId) => new LogEventId(eventId.Id, eventId.Name);
    }
}