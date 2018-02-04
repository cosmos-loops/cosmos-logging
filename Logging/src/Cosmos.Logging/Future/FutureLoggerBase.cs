using System;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Future {
    public abstract class FutureLoggerBase : IFutureLogger, IDisposable {
        private readonly ILogger _internalLogger;
        private readonly ILogCallerInfo _callerInfo;

        private FutureLogEventDescriptor CurrentState { get; set; }

        protected FutureLoggerBase(ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            _internalLogger = logger ?? throw new ArgumentNullException(nameof(logger));
            _callerInfo = new LogCallerInfo(memberName, filePath, lineNumber);
            SetCurrentState(_callerInfo);
        }

        public IFutureLogger SetLevel(LogEventLevel level) {
            CurrentState.Level = level;
            return this;
        }

        public IFutureLogger SetException(Exception exception) {
            CurrentState.Exception = exception;
            return this;
        }

        public IFutureLogger SetMessage(string message) {
            CurrentState.MessageTemplate = message;
            return this;
        }

        public IFutureLogger AppendMessage(string message) {
            CurrentState.MessageTemplate += message;
            return this;
        }

        public IFutureLogger SetParameter(object parameter) {
            CurrentState.Context.SetParameter(parameter);
            return this;
        }

        public IFutureLogger SetTags(params string[] tags) {
            CurrentState.Context.SetTags(tags);
            return this;
        }

        public IFutureLogger AppendAdditionalOperation(IAdditionalOperation additionalOperation) {
            CurrentState.Context.ImportOpt(additionalOperation);
            return this;
        }

        public void Submit() {
            SubmitCurrentState();
            SetCurrentState(_callerInfo);
        }

        private void SubmitCurrentState() {
            _internalLogger.Write(CurrentState);
        }

        private void SetCurrentState(ILogCallerInfo callerInfo) {
            CurrentState = new FutureLogEventDescriptor(callerInfo);
        }

        public void Dispose() {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                SubmitCurrentState();
                CurrentState = null;
            }
        }
    }
}