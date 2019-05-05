using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core {
    public interface IMessagePropertyFactory {
        MessageProperty CreateProperty(string name, object value, PropertyResolvingMode mode, int positionalValue = 0);
    }
}