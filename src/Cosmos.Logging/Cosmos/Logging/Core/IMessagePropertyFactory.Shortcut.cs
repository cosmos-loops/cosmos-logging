using Cosmos.Logging.Events;

namespace Cosmos.Logging.Core {
    /// <summary>
    /// Interface shortcut property factory
    /// </summary>
    public interface IShortcutPropertyFactory {
        /// <summary>
        /// Create property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="destructureObject"></param>
        /// <returns></returns>
        MessageProperty CreateProperty(string name, object value, bool destructureObject = false);
    }
}