using System;
using Cosmos.Logging.Events;

namespace Cosmos.Logging {
    public class EmptyLogger : ILogger {
        private readonly static EmptyLogger _emptyLoggerCache;

        static EmptyLogger() {
            _emptyLoggerCache = new EmptyLogger();
        }

        public static EmptyLogger Instance => _emptyLoggerCache;

        public string Name { get; }
        public LogEventLevel MinimumLevel { get; }
        public LogEventSendMode SendMode { get; }

        public bool IsEnabled(LogEventLevel level) {
            throw new NotImplementedException();
        }

        public void Write(LogEventLevel level, Exception exception, string messageTemplate, LogEventSendMode sendMode) {
            throw new NotImplementedException();
        }

        public void Write(LogEvent logEvent) {
            throw new NotImplementedException();
        }

        public void SubmitLogger() {
            throw new NotImplementedException();
        }

        public void Verbose(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Verbose(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Debug(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Debug(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Information(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Information(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Warning(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Warning(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Error(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Fatal(string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }

        public void Fatal(Exception exception, string messageTemplate, LogEventSendMode mode = LogEventSendMode.Customize) {
            throw new NotImplementedException();
        }
    }
}