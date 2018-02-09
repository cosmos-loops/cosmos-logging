using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;
using Cosmos.Logging.ExtraSupports;

namespace Cosmos.Logging.Future {
    public abstract class FutureLoggerBase : IFutureLogger, IDisposable {
        private readonly ILogger _internalLogger;
        private readonly ILogCallerInfo _callerInfo;
        private readonly ContextData _loggerLigetimeContextData;

        private FutureLogEventDescriptor CurrentDescriptor { get; set; }

        protected FutureLoggerBase(ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            _internalLogger = logger ?? throw new ArgumentNullException(nameof(logger));
            _loggerLigetimeContextData = new ContextData();
            _callerInfo = new LogCallerInfo(memberName, filePath, lineNumber);
            SetCurrentState(_callerInfo);
        }

        public IFutureLogger SetLevel(LogEventLevel level) {
            CurrentDescriptor.Level = level;
            return this;
        }

        public IFutureLogger SetException(Exception exception) {
            CurrentDescriptor.Exception = exception;
            return this;
        }

        public IFutureLogger SetMessage(string message) {
            CurrentDescriptor.MessageTemplate = message;
            return this;
        }

        public IFutureLogger AppendMessage(string message) {
            CurrentDescriptor.MessageTemplate += message;
            return this;
        }

        public IFutureLogger SetParameter(object parameter) {
            CurrentDescriptor.Context.SetParameter(parameter);
            return this;
        }

        public IFutureLogger SetTags(params string[] tags) {
            CurrentDescriptor.Context.SetTags(tags);
            return this;
        }

        public IFutureLogger SetEventId(Guid id, string name) => SetEventId(new LogEventId(id, name));
        public IFutureLogger SetEventId(int id, string name) => SetEventId(new LogEventId(id, name));
        public IFutureLogger SetEventId(string id, string name) => SetEventId(new LogEventId(id, name));

        public IFutureLogger SetEventId(LogEventId eventId) {
            CurrentDescriptor.EventId = eventId;
            return this;
        }

        public IFutureLogger AppendAdditionalOperation(IAdditionalOperation additionalOperation) {
            CurrentDescriptor.Context.ImportOpt(additionalOperation);
            return this;
        }

        public void Submit() {
            SubmitCurrentState();
            SetCurrentState(_callerInfo);
        }

        private void SubmitCurrentState() {
            _internalLogger.Write(CurrentDescriptor);
        }

        private void SetCurrentState(ILogCallerInfo callerInfo) {
            CurrentDescriptor = new FutureLogEventDescriptor(callerInfo, _loggerLigetimeContextData);
        }

        public void Dispose() {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                SubmitCurrentState();
                CurrentDescriptor = null;
            }
        }
    }
}