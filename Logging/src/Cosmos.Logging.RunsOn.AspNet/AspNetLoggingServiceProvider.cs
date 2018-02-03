using System;
using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.RunsOn.AspNet {
    public class AspNetLoggingServiceProvider : ILoggingServiceProvider {

        public AspNetLoggingServiceProvider() { }

        public ILogger GetLogger(string categoryName, LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(string categoryName, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(string categoryName, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(string categoryName, LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger(Type type, Func<string, LogEventLevel, bool> filter, LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }

        public ILogger GetLogger<T>(LogEventLevel minLevel, Func<string, LogEventLevel, bool> filter,
            LogEventSendMode mode = LogEventSendMode.Customize,
            MessageTemplateRenderingOptions renderingOptions = null) {
            throw new NotImplementedException();
        }
    }
}