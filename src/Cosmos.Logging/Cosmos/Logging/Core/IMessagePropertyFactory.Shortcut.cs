using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core
{
    public interface IShortcutPropertyFactory
    {
        MessageProperty CreateProperty(string name, object value, bool destructureObject = false);
    }
}