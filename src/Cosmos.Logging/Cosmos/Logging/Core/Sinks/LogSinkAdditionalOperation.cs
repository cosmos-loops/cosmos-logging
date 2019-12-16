using System;

namespace Cosmos.Logging.Core.Sinks {
    /// <summary>
    /// Log sink additional operaton
    /// </summary>
    public class LogSinkAdditionalOperation : IAdditionalOperation {

        private dynamic AdditionalAction { get; set; }

        /// <summary>
        /// Create a new instance of <see cref="LogSinkAdditionalOperation"/>
        /// </summary>
        /// <param name="flagType"></param>
        /// <param name="additionalAction"></param>
        public LogSinkAdditionalOperation(Type flagType, dynamic additionalAction) {
            Flag = flagType ?? throw new ArgumentNullException(nameof(flagType));
            AdditionalAction = additionalAction ?? throw new ArgumentNullException(nameof(additionalAction));
        }

        /// <inheritdoc />
        public AdditionalOperationTypes Type => AdditionalOperationTypes.ForLogSink;

        /// <inheritdoc />
        public Type Flag { get; }

        /// <inheritdoc />
        public dynamic GetOpt() => AdditionalAction;
    }
}