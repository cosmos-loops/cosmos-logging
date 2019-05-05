using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core {
    public interface IMessagePropertyValueFactory {
        MessagePropertyValue CreatePropertyValue(object value, PropertyResolvingMode mode, int positionalValue = -1);
    }
}