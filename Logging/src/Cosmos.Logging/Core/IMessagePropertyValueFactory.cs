using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core {
    public interface IMessagePropertyValueFactory {
        MessagePropertyValue CreatePropertyValue(object value, PropertyResolvingMode mode, int positionalIndex = -1);
    }
}