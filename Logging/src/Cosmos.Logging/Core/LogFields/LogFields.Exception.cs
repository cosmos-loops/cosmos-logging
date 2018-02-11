using System;

namespace Cosmos.Logging.Core.LogFields {
    public class ExceptionField : ILogField<Exception> {
        public ExceptionField(Exception exception) => Value = exception;
        public LogFieldTypes Type => LogFieldTypes.Exception;
        public Exception Value { get; }
    }
}