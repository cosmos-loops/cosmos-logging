using System;
using Cosmos.Logging.Core;
using Cosmos.Logging.Core.LogFields;
using Cosmos.Logging.Events;

namespace Cosmos.Logging.Future {
    public interface IFutureLogger {
        IFutureLogger UseFields(params ILogField[] fields);
        IFutureLogger SetLevel(LogEventLevel level);
        IFutureLogger SetException(Exception exception);
        IFutureLogger SetMessage(string message);
        IFutureLogger AppendMessage(string message);
        IFutureLogger SetParameter(object parameter);
        IFutureLogger SetTags(params string[] tags);
        IFutureLogger SetEventId(LogEventId eventId);
        IFutureLogger SetEventId(Guid id, string name);
        IFutureLogger SetEventId(int id, string name);
        IFutureLogger SetEventId(string id, string name);
        IFutureLogger AppendAdditionalOperation(IAdditionalOperation additionalOperation);
        void Submit();
    }
}