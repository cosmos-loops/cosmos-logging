using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.Callers;
using Cosmos.Logging.Core.LogFields;
using Cosmos.Logging.Events;
using Cosmos.Logging.ExtraSupports;

namespace Cosmos.Logging.Future {
    /// <summary>
    /// Future logger
    /// </summary>
    public abstract class FutureLoggerBase : IFutureLogger, IDisposable {
        private readonly ILogger _internalLogger;
        private readonly ILogCallerInfo _callerInfo;
        private readonly ContextData _loggerLigetimeContextData;

        private FutureLogEventDescriptor CurrentDescriptor { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="FutureLoggerBase"/>
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        protected FutureLoggerBase(ILogger logger, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null, [CallerLineNumber] int lineNumber = 0) {
            _internalLogger = logger ?? throw new ArgumentNullException(nameof(logger));
            _loggerLigetimeContextData = new ContextData();
            _callerInfo = new LogCallerInfo(memberName, filePath, lineNumber);
            SetCurrentState(_callerInfo);
        }

        /// <inheritdoc />
        public IFutureLogger UseFields(params ILogField[] fields) {
            if (fields == null) throw new ArgumentNullException(nameof(fields));
            if (!fields.Any()) return this;
            foreach (var field in fields.OrderBy(x => x.Sort)) {
                switch (field) {
                    case LogEventLevelField levelField:
                        SetLevel(levelField.Value);
                        break;
                    case MessageTemplateField messageTemplateField:
                        if (messageTemplateField.Append) AppendMessage(messageTemplateField.Value);
                        else SetMessage(messageTemplateField.Value);
                        break;
                    case ExceptionField exceptionField:
                        SetException(exceptionField.Value);
                        break;
                    case ArgsField argsField:
                        SetParameters(argsField.Value);
                        break;
                    case TagsField tagsField:
                        SetTags(tagsField.Value);
                        break;
                    case EventIdField eventIdField:
                        SetEventId(eventIdField.Value);
                        break;
                    default:
                        throw new ArgumentException("Unknown field type.");
                }
            }

            return this;
        }

        /// <inheritdoc />
        public IFutureLogger SetLevel(LogEventLevel level) {
            CurrentDescriptor.Level = level;
            return this;
        }

        /// <inheritdoc />
        public IFutureLogger SetException(Exception exception) {
            CurrentDescriptor.Exception = exception;
            return this;
        }

        /// <inheritdoc />
        public IFutureLogger SetMessage(string message) {
            CurrentDescriptor.MessageTemplate = message;
            return this;
        }

        /// <inheritdoc />
        public IFutureLogger AppendMessage(string message) {
            CurrentDescriptor.MessageTemplate += message;
            return this;
        }

        /// <inheritdoc />
        public IFutureLogger SetParameter(object parameter) {
            CurrentDescriptor.Context.SetParameter(parameter);
            return this;
        }

        /// <inheritdoc />
        public IFutureLogger SetParameters(params object[] parameters) {
            foreach (var parameter in parameters)
                SetParameter(parameter);
            return this;
        }

        /// <inheritdoc />
        public IFutureLogger SetTags(params string[] tags) {
            CurrentDescriptor.Context.SetTags(tags);
            return this;
        }

        #region Set eventid

        /// <inheritdoc />
        public IFutureLogger SetEventId(Guid id, string name) => SetEventId(new LogEventId(id, name));

        /// <inheritdoc />
        public IFutureLogger SetEventId(int id, string name) => SetEventId(new LogEventId(id, name));

        /// <inheritdoc />
        public IFutureLogger SetEventId(long id, string name) => SetEventId(new LogEventId(id, name));

        /// <inheritdoc />
        public IFutureLogger SetEventId(string id, string name) => SetEventId(new LogEventId(id, name));

        /// <inheritdoc />
        public IFutureLogger SetEventId(LogEventId eventId) {
            CurrentDescriptor.EventId = eventId;
            return this;
        }

        #endregion

        /// <inheritdoc />
        public IFutureLogger AppendAdditionalOperation(IAdditionalOperation additionalOperation) {
            CurrentDescriptor.Context.ImportOpt(additionalOperation);
            return this;
        }

        #region Submit

        /// <inheritdoc />
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

        #endregion

        #region Dispose

        /// <inheritdoc />
        public void Dispose() {
            Dispose(true);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                SubmitCurrentState();
                CurrentDescriptor = null;
            }
        }

        #endregion

    }
}