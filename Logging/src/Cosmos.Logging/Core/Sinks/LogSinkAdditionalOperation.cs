using System;

namespace Cosmos.Logging.Core.Sinks {
    public class LogSinkAdditionalOperation : IAdditionalOperation {

        private dynamic AdditionalAction { get; set; }

        public LogSinkAdditionalOperation(Type flagType, dynamic additionalAction) {
            Flag = flagType ?? throw new ArgumentNullException(nameof(flagType));
            AdditionalAction = additionalAction ?? throw new ArgumentNullException(nameof(additionalAction));
        }

        public AdditionalOperationTypes Type => AdditionalOperationTypes.ForLogSink;
        public Type Flag { get; }

        public dynamic GetOpt() => AdditionalAction;
    }
}