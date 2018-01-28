using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.RunsOn.AspNet {
    public class AspNetLoggingServiceProvider : ILoggingServiceProvider {

        public AspNetLoggingServiceProvider() { }

        public ILogger GetLogger(Type type, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }
    }
}