using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Future {
    public interface IFutureLogger {
        IFutureLogger SetLevel(LogEventLevel level);
        IFutureLogger SetException(Exception exception);
        IFutureLogger SetMessage(string message);
        IFutureLogger AppendMessage(string message);
        IFutureLogger SetParameter(object parameter);
        IFutureLogger SetTags(params string[] tags);
        IFutureLogger AppendAdditionalOperation(IAdditionalOperation additionalOperation);
        void Submit();
    }
}