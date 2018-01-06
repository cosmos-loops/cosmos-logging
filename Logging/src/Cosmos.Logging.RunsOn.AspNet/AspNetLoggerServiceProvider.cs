using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.RunsOn.AspNet {
    public class AspNetLoggerServiceProvider : ILoggingServiceProvider {
        private const string DEFAULT_LOGGER_NAME_PREFIX = "logger:CosmosLoops:roAspNet_";

        public AspNetLoggerServiceProvider() { }

        public ILogger GetLogger(LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(string name, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(string name, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, string name, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, string name, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(string name, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(string name, LogEventLevel level, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }
    }
}