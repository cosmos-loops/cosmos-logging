using System;

namespace Cosmos.Logging.Core.LogFields {
    /// <summary>
    /// Exception field
    /// </summary>
    public class ExceptionField : ILogField<Exception> {
        /// <summary>
        /// Create a new instance of <see cref="ExceptionField"/>.
        /// </summary>
        /// <param name="exception"></param>
        public ExceptionField(Exception exception) => Value = exception;

        /// <inheritdoc />
        public LogFieldTypes Type => LogFieldTypes.Exception;

        /// <inheritdoc />
        public Exception Value { get; }

        /// <inheritdoc />
        public int Sort { get; set; } = 1;
    }
}