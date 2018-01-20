using Cosmos.Logging.Events;
using Cosmos.Logging.MessageTemplates;

namespace Cosmos.Logging.Core {
    public interface IMessagePropertyFactory {
        MessageProperty CreateProperty(string name, object value, PropertyResolvingMode mode, int index = 0);
    }
}